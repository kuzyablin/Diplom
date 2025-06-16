using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window, INotifyPropertyChanged
    {
        private UserDTO user;

        public UserDTO User { get => user; set { user = value; Signal(); } }

        public AccountWindow(UserDTO User)
        {
            InitializeComponent();
            DataContext = this;

            GetData();
            
        }

        private async void GetData()
        {
            User = await Client.Instance.GetUserById();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null) =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void ChangePassword(object sender, RoutedEventArgs e)
        {

        }

        private void EditProfile(object sender, RoutedEventArgs e)
        {

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
