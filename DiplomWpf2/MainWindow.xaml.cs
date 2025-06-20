using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Diplom2.DTO;
using DiplomWpf2.API;


namespace DiplomWpf2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<BuketDTO> Bukets
        {
            get => bukets;
            set { bukets = value; Signal(nameof(Bukets)); }
        }
        public BuketDTO selectedBuket { get; set; }

        public BuketDTO SelectedBuket
        {
            get => selectedBuket;
            set
            {
                selectedBuket = value;
                LoadBuket();
            }
        }
        private ObservableCollection<BuketDTO> bukets { get; set; }
        public OrderDTO order;
        public UserDTO User { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadBuket();
            LoadDefaultImage();
        }
        public MainWindow(UserDTO user)
        {
            InitializeComponent();
            DataContext = this;
            LoadBuket();
            LoadDefaultImage();
            User = user;
        }
        //public MainWindow(UserDTO user)
        //{
        //    InitializeComponent();
        //    DataContext = this;
        //    LoadBuket();
        //}
        private void LoadBuket()
        {
            Task.Run(async () =>
            {
                await LoadBuket(Client.Instance);
            });
        }

        private async Task LoadBuket(Client client)
        {
            Bukets = new ObservableCollection<BuketDTO>(await client.GetBuket());
            foreach (var d in Bukets)
                if (d.ImageBuket == null)
                    d.ImageBuket = defaultImage;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bukets)));
        }

        byte[] defaultImage;

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        //private async void AddOrder(object sender, RoutedEventArgs e)
        //{
        //    Button b = sender as Button;
        //    SelectedBuket = b.Tag as BuketDTO;
        //    if (order == null)
        //    {
        //        order = new OrderDTO();
        //        try
        //        {
        //            await Client.Instance.AddOrderAsync(order);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return;
        //        }
        //    }

        //    order.Bukets.Add(SelectedBuket);
        //    await Client.Instance.AddBuketToOrder(order, SelectedBuket, 1);

        //    new OrderWindow(order).ShowDialog();
        //    LoadBuket();
        //}
        private void LoadDefaultImage()
        {
            var stream = Application.GetResourceStream(new Uri("Img\\picturee.png", UriKind.Relative));
            defaultImage = new byte[stream.Stream.Length];
            stream.Stream.Read(defaultImage, 0, defaultImage.Length);
        }
        //private void More(object sender, RoutedEventArgs e)
        //{
        //    Button b = sender as Button;
        //    SelectedBuket = b.Tag as BuketDTO;
        //    new MoreWindow(SelectedBuket).ShowDialog();
        //    LoadBuket();
        //}
        
        private void buttonBuket(object sender, RoutedEventArgs e)
        {
            new MainWindow(User).Show();
            Close();
        }

        private void buttonTovar(object sender, RoutedEventArgs e)
        {
            new TovarWindow(User).Show();
            Close();
        }

        private void Basket(object sender, RoutedEventArgs e)
        {
            new OrderWindow(order).Show();
        }
        private void Login(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
    }
}