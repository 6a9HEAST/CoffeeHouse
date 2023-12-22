using CoffeeHouseProject.Script;

using System.Collections.ObjectModel;

using System.Windows;
using CoffeeHouseProject.View;


namespace CoffeeHouseProject.ViewModel
{

    

    public partial class MainWindow : Window
    {
        private UserTable _user;
        public OrderTable order { get; set; }
        public IMainWindowController _controller { get; set; }
        public ObservableCollection<OrderLineTable> OrderLines { get; set; }

        


        public MainWindow(UserTable user,IMainWindowController controller)
        {
            _controller = controller;
            InitializeComponent();
            OpenMenu();
            DataContext = this;
            _user = user;
            order = new OrderTable();
            order.Value = 0;
            OrderLines = new ObservableCollection<OrderLineTable>();
            
            WindowState= WindowState.Maximized;


        }

        public void OpenCart()
        {
            mainFrame.Navigate(new CartPage(this));
        }

        public void OpenMenu()
        {
            mainFrame.Navigate(new MenuPage(this));
            
        }

        public void OpenPayment()
        {
            PaymentFrame.Navigate(new PaymentPage());
        }
        

        
    }
}
