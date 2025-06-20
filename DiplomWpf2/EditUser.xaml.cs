using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window/*, INotifyPropertyChanged*/
    {
        public EditUser(UserDTO User)
        {
            InitializeComponent();
            //SelectedUser = User;
            DataContext = this;
        }
        //private UserDTO select;
        //public UserDTO SelectedUser
        //{
        //    get => select;
        //    set
        //    {
        //        select = value;
        //        if (select != null)
        //        {
        //            // Обновляем локальные свойства для отображения в UI
        //            NameUser = select.NameUser;
        //            EmailUser = select.EmailUser;
        //            NumberUser = select.NumberUser;
        //            // Предположим, что у вас есть свойство SelectedType, которое связывается с выбранным типом

        //        }
        //        Signal();
        //    }
        //}
        //private string nameuser;
        //public string NameUser { get => nameuser; set { nameuser = value; Signal(); } }
        //private string email;
        //public string EmailUser { get => email; set { email = value; Signal(); } }
        //private string number;
        //public string NumberUser { get => number; set { number = value; Signal(); } }

        //public event PropertyChangedEventHandler? PropertyChanged;
        //public void Signal([CallerMemberName] string prop = null) =>
        // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        //private async void Back(object sender, RoutedEventArgs e)
        //{          
        //    Close();
        //}
        //private async void Save(object sender, RoutedEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(NameUser))
        //    {
        //        MessageBox.Show("Введите логин!", "Ошибка",
        //                       MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    if (string.IsNullOrWhiteSpace(EmailUser))
        //    {
        //        MessageBox.Show("Введите почту!", "Ошибка",
        //                       MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    if (string.IsNullOrWhiteSpace(NumberUser))
        //    {
        //        MessageBox.Show("Введите номер телефона!", "Ошибка",
        //                       MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }            
        //    else
        //    {
        //        Client client = Client.Instance();
        //        //await Client.Instance();
        //        SelectedUser.NameUser = NameUser;
        //        SelectedUser.EmailUser = EmailUser;
        //        SelectedUser.NumberUser = NumberUser;               
        //        await Client.Instance.EditUser(SelectedUser.User.IdUser);
        //        Close();
        //    }
        //}
    }
}
