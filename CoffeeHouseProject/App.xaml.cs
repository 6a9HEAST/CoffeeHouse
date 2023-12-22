using Ninject;
using System.Windows;
using CoffeeHouseProject.Script;


namespace CoffeeHouseProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
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
        }

        private void ComposeObjects()
        {
            IKernel kernel = new StandardKernel(new DependencyModule());
            Current.MainWindow = kernel.Get<LoginWindow>();
            //Current.MainWindow.Title = "DI with Ninject";
        }
    }

}
