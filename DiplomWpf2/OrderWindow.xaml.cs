using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window, INotifyPropertyChanged
    {
        private OrderDTO selectedOrder;

        private NewShit selectedShit;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public OrderDTO SelectedOrder
        {
            get => selectedOrder;
            set
            {
                selectedOrder = value;
            }
        }

        public NewShit SelectedShit
        {
            get => selectedShit;
            set
            {
                selectedShit = value;
                Signal();
            }

        }

        public ObservableCollection<NewShit> Items { get; set; }

        public int Count { get => Items.Sum(s => s.Count); }
        public decimal? Price { get => Items.Sum(s => s.Price); }
        public OrderWindow(OrderDTO order)
        {
            InitializeComponent();
            SelectedOrder = order;
            DataContext = this;
            if (order == null)
            {
                Items = new();
                return;
            }
            GetItems();
        }
        private List<OrderDTO> orders;
        public List<OrderDTO> Orders { get => orders; set { orders = value; Signal(); } }

        public async Task GetItems()
        {
            Items = new ObservableCollection<NewShit>(SelectedOrder.Bukets.GroupBy(s => s.NameBuket).Select(s => new NewShit { Count = s.Count(), Buket = s.First(), Price = s.Sum(d => d.PriceBuket) }));
        
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Order(object sender, RoutedEventArgs e)
        {
            if (Items.Count() == 0)
            {
                MessageBox.Show("Заказ не оформлен! Выберите позиции!");
                return;
            }
            else
            {
                MessageBox.Show("Заказ оформлен");
                Close();
            }
        }

        private async void AddBuket(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            SelectedShit = b.Tag as NewShit;
            await Client.Instance.AddBuketToOrder(SelectedOrder, SelectedShit.Buket, Count);
            SelectedOrder.Bukets.Add(SelectedShit.Buket);

            GetItems();
            Signal(nameof(Price));
            Signal(nameof(Count));
            Signal(nameof(Items));
        }

        private async void DeleteBuket(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            SelectedShit = b.Tag as NewShit;
            try
            {
                await Client.Instance.DeleteBuketInOrder(SelectedShit.Buket.IdBuket);
                SelectedOrder.Bukets.Remove(SelectedShit.Buket);
                Items.Remove(SelectedShit);

                GetItems();
                Signal(nameof(Count));
                Signal(nameof(Price));
                Signal(nameof(Items));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
    public class NewShit
     
        {
            public int Count { get; internal set; }
            public BuketDTO Buket { get; internal set; }
            public decimal? Price { get; internal set; }
        }
    
}

