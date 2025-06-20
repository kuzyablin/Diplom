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

namespace DiplomWpf2
{
    /// <summary>
    /// Логика взаимодействия для Kolvo.xaml
    /// </summary>
    public partial class Kolvo : Window
    {
        public int Quantity { get; private set; }
        public Kolvo()
        {
            InitializeComponent();
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                Quantity = quantity;
                DialogResult = true; // Устанавливаем результат диалога как успешный
                Close(); // Закрываем окно
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное количество.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
