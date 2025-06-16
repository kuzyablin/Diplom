using System;
using System.Collections.Generic;
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
using DiplomWpf2.API;
using DiplomWpf2.DTO;
using Microsoft.Win32;

namespace DiplomWpf2
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public UserDTO User { get; set; }
        public string NameUser { get; set; }
        public string ParolUser { get; set; }
        public string EmailUser { get; set; }

        
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void SignIn(object sender, RoutedEventArgs e)
        {
            try
            {
                    var user = await Client.Instance.Login(NameUser, ParolUser, EmailUser);
                    // user получает null данных(проверь если не получает)
                    MainLogin mainLogin = new MainLogin(user);
                    mainLogin.Show();
                    Close();              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            new RegisterWindow().Show();
            Close();
        }
    }
}
