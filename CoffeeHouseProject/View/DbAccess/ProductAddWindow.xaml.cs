using Microsoft.Win32;
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

namespace CoffeeHouseProject.View.DbAccess
{
    /// <summary>
    /// Логика взаимодействия для ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        private DbAccessWindow _parent;
        public ProductAddWindow(DbAccessWindow parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Все файлы (*.*)|*.*"; // Можно указать другие фильтры

            if (openFileDialog.ShowDialog() == true)
            {
                FilePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _parent._controller.AddProduct(NameTextBox.Text, FilePathTextBox.Text, PriceTextBox.Text);
            this.Close();
        }
    }
}
