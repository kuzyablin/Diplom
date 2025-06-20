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
    /// Логика взаимодействия для MoreWindow.xaml
    /// </summary>
    public partial class MoreWindow : Window, INotifyPropertyChanged
    {
        public UserDTO User { get; set; }
        private BuketDTO selectedBuket;

        private ObservableCollection<TovarDTO> selectedTovar;
        private List<KrossBuketDTO> buket;
        public List<KrossBuketDTO> Bukets { get => buket; set { buket = value; Signal(); } }
      

        public List<TovarDTO> Tovars { get; set; }
        public ObservableCollection<TovarDTO> SelectedTovar
        {
            get => selectedTovar;
            set
            {
                selectedTovar = value;
                Signal();
            }
        }
        public BuketDTO SelectedBuket
        {
            get => selectedBuket;
            set
            {
                selectedBuket = value;
                Signal();
            }
        }

        public KrossBuketDTO KrossBuketDTO 
        {
            get => KrossBuketDTO;
            set
            {
                KrossBuketDTO = value;
                Signal();
            }
        }
        public MoreWindow(BuketDTO buket)
        {
            InitializeComponent();
            SelectedBuket = buket;

            
            LoadTovar();            
            DataContext = this;
            this.User = User;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null) =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private async Task LoadTovar()
        {
            await GHP();
            Bukets = new List<KrossBuketDTO>(Bukets.Where(e => e.IdBuketNavigation.IdBuket == SelectedBuket.IdBuket));

            //Tovars = await Client.Instance.GetTovar();
            SelectedTovar = new ObservableCollection<TovarDTO>(SelectedBuket.Tovars);

            //sostavBuket.ItemsSource = SelectedTovar.ToList(); 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tovars)));
        }

        private async Task GHP()
        {
            Bukets = await Client.Instance.GetKrossBukets();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
