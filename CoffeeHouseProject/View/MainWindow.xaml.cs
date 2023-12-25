using CoffeeHouseProject.Script;

using System.Collections.ObjectModel;

using System.Windows;
using CoffeeHouseProject.View;
using CoffeeHouseProject.View.Account;
using CoffeeHouseProject.View.DbAccess;
using Ninject;
using Ninject.Parameters;
using System.Windows.Media.Imaging;


namespace CoffeeHouseProject.ViewModel
{

    

    public partial class MainWindow : Window
    {
        public UserTable _user { get; set; }
        public IMainWindowController _controller { get; set; }
        private LoginWindow _window;
        


        public MainWindow(UserTable user,LoginWindow window,IMainWindowController controller)
        {
            _controller = controller;
            InitializeComponent();
            OpenMenu();
            DataContext = this;
            _user = user;
            WindowState= WindowState.Maximized;
            _window = window;
            Uri iconUri = new Uri("./Images/zerno.png", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
            //window.Close();
        }

        

        public void OpenCart()
        {
            mainFrame.Navigate(new CartPage(this));
        }

        public void OpenMenu(bool clear=false)
        {
            mainFrame.Navigate(new MenuPage(this));
            PaymentFrame.Content= null;
            if (clear)
            {
                _controller.ClearCart();
            }

        }

        public void OpenPayment()
        {
            PaymentFrame.Navigate(new PaymentPage(this));
        }

        public void OpenAccount()
        {
            IKernel kernel = new StandardKernel(new DependencyModule());
            AccountWindow accountwindow= kernel.Get<AccountWindow>(new ConstructorArgument("user", _user));
            accountwindow.Show();
        }

        public void OpenDbAccess()
        {
            IKernel kernel = new StandardKernel(new DependencyModule());
            DbAccessWindow dbAccessWindow = kernel.Get<DbAccessWindow>();
            dbAccessWindow.ShowDialog();
        }

        public void TryPay(string CardNumber, string ExpiryDate, string CVV)
        {
            if (CardNumber.Length == 19 && ExpiryDate.Length == 5 && CVV.Length == 3)
            {
                _controller.Pay(CardNumber, ExpiryDate, CVV, _user.UserId);
                MessageBox.Show("Оплата прошла успешно");
            }
            else MessageBox.Show("Оплата не удалась");
        }

        
    }
}
