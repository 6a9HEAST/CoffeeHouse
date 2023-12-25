using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using CoffeeHouseProject.Script;
using Ninject;

namespace CoffeeHouseProject.ViewModel
{

    public partial class MenuPage : UserControl, INotifyPropertyChanged
    {
        public ObservableCollection<ProductTable> _products;
        public ObservableCollection<ProductTable> Products {
            get
            {
                return _products;
            }
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow _mainwindow { get; set; }

        public MenuPage(MainWindow mainwindow)
        {
            InitializeComponent();
            _mainwindow = mainwindow;
            DataContext = this;
            FillMenu();
            
        }

        public void FillMenu()
        {
            Products = null; 
            Products = _mainwindow._controller.GetProductsForMenu();
            foreach (var product in Products)
            {
                product.AddToCartRequested += _mainwindow._controller.HandleAddToCart;
            }
        }

        private void CartButton_onclick(object sender, RoutedEventArgs e)
        {
            _mainwindow.OpenCart();
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountPopup.IsOpen = !AccountPopup.IsOpen;
            if (_mainwindow._user.Usertype != "ADMIN") DbAccessButton.Visibility = Visibility.Collapsed;
        }

        private void MyAccButton_Click(object sender, RoutedEventArgs e)
        {
            _mainwindow.OpenAccount();
        }

        private void DbAccessButton_Click(object sender, RoutedEventArgs e)
        {
            _mainwindow.OpenDbAccess();
            FillMenu();
        }

        private void ChangeAccButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = (MessageBoxResult.Yes==MessageBox.Show("Вы действительно хотите выйти из аккаунта?", "Выйти из аккаунта", MessageBoxButton.YesNo, MessageBoxImage.Question));
            if (result)
            {
                try
                {
                    File.Delete("data.bin");
                }
                catch{}
                IKernel kernel = new StandardKernel(new DependencyModule());
                LoginWindow loginWindow = kernel.Get<LoginWindow>();
                loginWindow.Show();
                _mainwindow.Close();
            }
        }

        private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите закрыть приложение?", "", MessageBoxButton.YesNo));
            if (result) Application.Current.Shutdown();
        }
    }
}

