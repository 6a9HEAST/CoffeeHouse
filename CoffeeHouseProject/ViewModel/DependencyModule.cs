using CoffeeHouseProject.ViewModel;
using Ninject.Modules;

namespace CoffeeHouseProject.Script
{
    public class DependencyModule: NinjectModule
    {
        public override void Load()
        {
            Bind<ILoginController>().To<LoginController>().InTransientScope();
            Bind<IRegistrationController>().To<RegistrationController>().InTransientScope();
            Bind<IMainWindowController>().To<MainWindowController>().InTransientScope();
            Bind<MainWindow>().ToSelf();
        }
    }
}
