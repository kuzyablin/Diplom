using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для AddBuketWindow.xaml
    /// </summary>
    public partial class AddBuketWindow : Window, INotifyPropertyChanged
    {
        
        public AddBuketWindow(UserDTO user)
        {
            InitializeComponent();
            DataContext = this;
            LoadOrders();
            User = user;         
            
        }
        public Buket SelectedFrt { get; set; }
        public OrderDTO order;
        public UserDTO User { get; set; }
        public AddBuketWindow(bool user)
        {
            this.user = user;
        }
        private bool user;
        //public int Count { get => Frt.Sum(s => s.Count); }
        //public decimal? Price { get => Frt.Sum(s => s.Price); }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public TovarDTO SelectedTovar { get; set; }

        private List<TovarDTO> tovars;
        public List<TovarDTO> Tovars { get => tovars; set { tovars = value; Signal(); } }
        private List<TovarDTO> uio;
        public List<TovarDTO> FilteredProducts { get => uio; set { uio = value; Signal(); } }
        private List<TypeTovarDTO> typetovars;
        public List<TypeTovarDTO> TypeTovars { get => typetovars; set { typetovars = value; Signal(); } }
        private List<BuketDTO> bg;
        public List<BuketDTO> Bukets { get => bg; set { bg = value; Signal(); } }
        private string  hj;
        public string NameBuket { get => hj; set { hj = value; Signal(); } }
        private decimal lo;
        public decimal TotalSum { get => lo; set { lo = value; Signal(nameof(TotalSum)); } }
        private decimal ki;
        public decimal Kolvo { get => ki; set { ki = value; Signal(nameof(Kolvo)); } }

        private List<TovarDTO> _allTovars;
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
        private void LoadOrders()
        {
            Task.Run(async () =>
            {
                await LoadOrders(Client.Instance);
            });
        }
        private async Task LoadOrders(Client client)
        {
            //Client client = Client.Instance();
            TypeTovars = new List<TypeTovarDTO>(await client.GetTypeTovar());
            TypeTovars.Insert(0, new TypeTovarDTO { IdTypeTovar = 0, NameType = "Все товары" });
            // Сохраняем полный список отдельно
            _allTovars = new List<TovarDTO>(await client.GetTovar());
            Tovars = new List<TovarDTO>(_allTovars); // Инициализируем отображаемый список
        }
        
        private async void ProductsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsListView.SelectedItem != null)
            {
                SelectedTovar = (TovarDTO)ProductsListView.SelectedItem;
                var quantityInputWindow = new Kolvo();
                if (quantityInputWindow.ShowDialog() == true) // Если пользователь нажал ОК
                {
                    int quantity = quantityInputWindow.Quantity;
                    TovarDTO productName = SelectedTovar;
                    MessageBox.Show($"Вы выбрали {quantity} единиц {SelectedTovar.NameTovar}.", "Информация", MessageBoxButton.OK);
                    if (quantity > SelectedTovar.StockTovar)
                    {
                        MessageBox.Show($"Недостаточно товара '{SelectedTovar.NameTovar}' на складе. Доступно: {SelectedTovar.StockTovar}, требуется: {quantity}");
                    }
                    else
                    {

                        var newBuket = new Buket
                        {
                            
                            NameTovar = productName.NameTovar,
                            IdTovar = productName.IdTovar,
                            Kolvo = quantity,
                            PriceTovar = quantity * productName.PriceTovar,
                            IdTypeTovar = productName.IdTypeTovar,

                        };



                        Buket.Instance.Add(newBuket);
                        LoadBuket();
                    }
                }

            }
        }
        private List<Buket> yu;
        public List<Buket> Frt { get => yu; set { yu = value; Signal(); } }

        public async Task LoadBuket()
        {
            TotalSum = 0;

            Kolvo = 0;
            Frt = new List<Buket>(Buket.Instance.GetAllBukets());
            foreach (var product in Frt)
            {
                TotalSum += product.PriceTovar;
            }
            foreach (var ji in Frt)
            {
                Kolvo += ji.Kolvo;
            }
        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            Buket.Instance.Delete(SelectedFrt);
            LoadBuket();
        }

        private async void Soxr(object sender, RoutedEventArgs e)
        {
            if (Frt == null)
            {
                MessageBox.Show("Букет не может быть пустым");
            }
            else
            {

                TotalSum = 0;

                foreach (var product in Frt)
                {
                    TotalSum += product.PriceTovar;
                }
                

                BuketDTO newBuketDto = new BuketDTO
                {
                   NameBuket = NameBuket,
                   
                    PriceBuket = TotalSum,

                };
                //var createdBuket = await Client.Instance.AddBuketAsync(newBuketDto);
                await Client.Instance.AddBuketAsync(newBuketDto);
                foreach (var buket in Frt)
                {
                    var dto = new KrossBuketDTO
                    {

                        IdBuket = newBuketDto.IdBuket,
                        IdTovar = buket.IdTovar,
                        Kolvo = buket.Kolvo,
                        IdBuketNavigation = new BuketDTO
                        {
                            IdBuket = newBuketDto.IdBuket,
                            PriceBuket = TotalSum,
                            ImageBuket = newBuketDto.ImageBuket,
                            NameBuket = newBuketDto.NameBuket,
                        },
                        IdTovarNavigation = new TovarDTO
                        {
                            IdTovar = buket.IdTovar,
                            PriceTovar = buket.PriceTovar,
                            NameTovar = buket.NameTovar,
                            IdTypeTovar = buket.IdTypeTovar,
                            ImageTovar = null,
                            StockTovar = 0,
                            IdTypeTovarNavigation = new TypeTovarDTO
                            {
                                IdTypeTovar = buket.IdTypeTovar,
                                NameType = null,
                            }

                        }
                    };

                    await Client.Instance.AddKrossBuket(dto);

                    //if (order == null)
                    //{
                    //    order = new OrderDTO { IdUserNavigation = User, IdUser = User.IdUser, CreatedAt = DateTime.Now, IdSkidkaNavigation = new SkidkaDTO { IdSkidka = 1, PriceOrder = 0 } };
                    //    try
                    //    {
                    //        await Client.Instance.AddOrderAsync(order);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show(ex.Message);
                    //        return;
                    //    }
                    //}

                    //order.Bukets.Add(SelectedBuket);
                    //await Client.Instance.AddBuketToOrder(order, SelectedBuket, 1);

                }

                Close();
            }
        }

        //private async Task AddBuketToOrder(BuketDTO buketDTO)
        //{
        //    SelectedBuket = Tag as BuketDTO;
        //    // Получаем текущего пользователя (предполагается, что он доступен)
        //    var user = User; // Замените на ваш способ получения текущего пользователя

        //    // Создаем новый заказ, если его нет
        //    if (order == null)
        //    {
        //        order = new OrderDTO { IdUserNavigation = User, IdUser = User.IdUser, CreatedAt = DateTime.Now, IdSkidkaNavigation = new SkidkaDTO { IdSkidka = 1, PriceOrder = 0 } };
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
            

        //    // Добавляем букет в заказ
        //    order.Bukets.Add(SelectedBuket);
        //    await Client.Instance.AddBuketToOrder(order, SelectedBuket, 1);

        //    // Если нужно открыть окно заказа, раскомментируйте следующую строку
        //    // new OrderWindow(order).ShowDialog();
        //}

        private TypeTovarDTO _selectedProductType;
        public TypeTovarDTO SelectedProductType
        {
            get => _selectedProductType;
            set
            {
                _selectedProductType = value;
                Signal();
                FilterProducts(); // При изменении выбранного типа применяем фильтр
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                Signal(nameof(SearchText));
                FilterProducts(); // При изменении текста поиска применяем фильтры
            }
        }

        // Метод фильтрации товаров
        private void FilterProducts()
        {
            if (_allTovars == null) return;

            IEnumerable<TovarDTO> result = _allTovars;

            // Фильтрация по типу
            if (SelectedProductType != null && SelectedProductType.IdTypeTovar != 0)
            {
                result = result.Where(p => p.IdTypeTovar == SelectedProductType.IdTypeTovar);
            }

            // Фильтрация по поиску
            if (!string.IsNullOrEmpty(SearchText))
            {
                result = result.Where(a =>
                    a.NameTovar?.ToLower().Contains(SearchText.ToLower()) ?? false);
            }

            Tovars = new List<TovarDTO>(result);
        }

        private async void Nazad(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
    //public class Shit

    //{
    //    public int Count { get; internal set; }
    //    public BuketDTO Buket { get; internal set; }
    //    public decimal? Price { get; internal set; }
    //}
}
