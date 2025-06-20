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
    /// Логика взаимодействия для SalesWindow.xaml
    /// </summary>
    public partial class SalesWindow : Window, INotifyPropertyChanged
    {
        private SkidkaDTO skidka;
        private ObservableCollection<SkidkaDTO> skidkas { get; set; }
        public ObservableCollection<SkidkaDTO> Skidkas
        {
            get => skidkas;
            set { skidkas = value; Signal(nameof(Skidkas)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null) =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public SkidkaDTO Skidka { get => skidka; set { skidka = value; Signal(); } }
        public SalesWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadSkidka();
        }
        private void LoadSkidka()
        {
            Task.Run(async () =>
            {
                await LoadSkidka(Client.Instance);
            });
        }

        private async Task LoadSkidka(Client client)
        {
            Skidkas = new ObservableCollection<SkidkaDTO>(await client.GetSkidka());            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Skidkas)));
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
