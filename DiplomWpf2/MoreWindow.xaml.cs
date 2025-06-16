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
using DiplomWpf2.API;
using DiplomWpf2.DTO;

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
        public List<TovarDTO> Tovars { get; set; }
        //public ObservableCollection<TovarDTO> SelectedTovars
        //{
        //    get => selectedTovar;
        //    set
        //    {
        //        selectedTovar = value;
        //        Signal();
        //    }
        //}
        public BuketDTO SelectedBuket
        {
            get => selectedBuket;
            set
            {
                selectedBuket = value;
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
            Tovars = await Client.Instance.GetTovar();
            //SelectedTovars = new ObservableCollection<TovarDTO>(SelectedBuket.Tovars);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tovars)));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
