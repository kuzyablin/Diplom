﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Diplom2.DTO;
using DiplomWpf2.API;


namespace DiplomWpf2
{
    /// <summary>
    /// Логика взаимодействия для TovarLogin.xaml
    /// </summary>
    public partial class TovarLogin : Window, INotifyPropertyChanged
    {
        public UserDTO User { get; set; }
        public TovarDTO selectedTovar { get; set; }
        public TovarDTO SelectedTovar
        {
            get => selectedTovar;
            set
            {
                selectedTovar = value;
                LoadTovar();
            }
        }
        public ObservableCollection<TovarDTO> Tovars
        {
            get => tovars;
            set { tovars = value; Signal(nameof(Tovars)); }
        }

        public OrderDTO order;

        public TypeTovarDTO selectedTypeTovar { get; set; }
        public List<TypeTovarDTO> TypeTovars { get; set; }

        public TypeTovarDTO SelectedTypeTovars
        {
            get => selectedTypeTovar;
            set
            {
                selectedTypeTovar = value;
                LoadTovar(SelectedTypeTovars);
            }
        }

        private ObservableCollection<TovarDTO> tovars;

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public TovarLogin(UserDTO User)
        {
            InitializeComponent();
            DataContext = this;
            this.User = User;
            LoadTovar();
            //LoadTypeTovar();
            LoadDefaultImage();
        }
        private void LoadTovar()
        {
            Task.Run(async () =>
            {
                await LoadTovar(Client.Instance);
            });
        }

        private async Task LoadTovar(Client client)
        {
            Tovars = new ObservableCollection<TovarDTO>(await client.GetTovar());
            foreach (var d in Tovars)
                if (d.ImageTovar == null)
                    d.ImageTovar = defaultImage;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tovars)));
        }

        private async Task LoadTovar(TypeTovarDTO typeTovar)
        {
            if (typeTovar == null || typeTovar.IdTypeTovar == 0)
            {
                LoadTovar(Client.Instance);
                return;
            }
            Tovars = new ObservableCollection<TovarDTO>(await Client.Instance.GetTovar1(typeTovar.IdTypeTovar));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tovars)));
        }

        private async Task LoadTypeTovar()
        {
            try
            {
                var client = Client.Instance;
                TypeTovars = await client.GetType();
                TypeTovars.Insert(0, new TypeTovarDTO { NameType = "Все типы товара" });
                SelectedTypeTovars = TypeTovars.First();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TypeTovars)));
            }
            catch { }
        }

        byte[] defaultImage;
        private async void AddOrder(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            SelectedTovar = b.Tag as TovarDTO;
            if (SelectedTovar == null) // Добавьте проверку
            {
                MessageBox.Show("Товар не выбран или данные повреждены");
                return;
            }
            if (order == null)
            {
                order = new OrderDTO { IdUserNavigation = User, IdUser = User.IdUser, CreatedAt = DateTime.Now, IdSkidkaNavigation = new SkidkaDTO { IdSkidka = 1, PriceOrder = 0 } };
                try
                {
                    await Client.Instance.AddOrderAsync(order);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }


            
            await Client.Instance.AddTovarToOrder(order, SelectedTovar, 1);

            new OrderWindow(order).ShowDialog();
            LoadTovar();
        }
        private void LoadDefaultImage()
        {
            var stream = Application.GetResourceStream(new Uri("Img\\picturee.png", UriKind.Relative));
            defaultImage = new byte[stream.Stream.Length];
            stream.Stream.Read(defaultImage, 0, defaultImage.Length);
        }        
        private void buttonBuket(object sender, RoutedEventArgs e)
        {
            new MainLogin(User).Show();
            Close();
        }

        private void buttonTovar(object sender, RoutedEventArgs e)
        {
            new TovarLogin(User).Show();
            Close();
        }
        private void Basket(object sender, RoutedEventArgs e)
        {
            new OrderWindow(order).Show();
        }
        private void Account(object sender, RoutedEventArgs e)
        {
            new AccountWindow(User).Show();
        }
    }
}
