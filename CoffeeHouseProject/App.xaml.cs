using CoffeeHouseProject.ViewModel;
using Ninject;
using System.Configuration;
using System.Data;
using System.Windows;


namespace CoffeeHouseProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
            //LoginWindow loginWindow = new LoginWindow();
            //loginWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<ILoginController>().To<LoginController>().InTransientScope();
            container.Bind<IRegistrationController>().To<RegistrationController>().InTransientScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<LoginWindow>();
            //Current.MainWindow.Title = "DI with Ninject";
        }
    }

}
