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

using System.Xml.Linq;
using Diplom2.DTO;
using DiplomWpf2.API;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace DiplomWpf2
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window, INotifyPropertyChanged
    {
        public RegistUser registUser { get; set; }
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null) =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private async void SendCode(object sender, RoutedEventArgs e)
        {
            var registUser = new RegistUser
            {
                NameUser = LoginTextBox.Text,
                EmailUser = EmailTextBox.Text,
                ParolUser = PasswordBox.Password,
                NumberUser = NumberTextBox.Text
            };

            bool result = false;
            try
            {
                //result = await Client.Instance.RegisterUserAsync(RegistUser registUser);
                result = await Client.RegisterUserAsync(registUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return;
            }

            if (result)
            {
                MessageBox.Show("Регистрация успешно отправлена. Проверьте почту для подтверждения.");
            }
            else
            {
                MessageBox.Show("Ошибка при регистрации. Попробуйте снова.");
            }
        }

        private async void VerifyCode(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string code = CodeTextBox.Text;

            bool result = false;
            try
            {
                result = await Client.VerifyCodeAsync(email, code);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return;
            }

            if (result)
            {
                MessageBox.Show("Верификация прошла успешно. Регистрация завершена.");
                new LoginWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный код или ошибка.");
            }
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
        
    }
}
