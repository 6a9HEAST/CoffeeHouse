using CoffeeHouseProject.DataAccess;
using CoffeeHouseProject.Script;
using CoffeeHouseProject.ViewModel;
using Ninject;
using Ninject.Parameters;

namespace CoffeeHouseProject
{
    public interface ILoginController
{
        public UserTable GetUser(string login, string password);
        public bool TryLogin(string login, string password, LoginWindow loginWindow);
    }
    public class LoginController:ILoginController
    {
        private readonly CoffeeHouseContext _context;
        public LoginController(CoffeeHouseContext context)
        {
            _context = context;
        }

        public UserTable GetUser(string login, string password)
        {
        var dbUserTableAccess = new DbUserTableAccess(_context);
            var user = dbUserTableAccess.GetUser(login);
            string userpassword = user.Password;
            for (int i=0; i<userpassword.Length;i++)
                if (userpassword[i]==' ') userpassword=userpassword.Remove(i);
            if (user != null && userpassword== password)
                return user;
            else return null;
        }

        public bool TryLogin(string login, string password,LoginWindow loginWindow)
        {
            UserTable user;
            if (login != "" && password != "")
            {

                user = GetUser(login, password);
                if (user != null)
                {
                    IKernel kernel = new StandardKernel(new DependencyModule());
                    MainWindow mainWindow = kernel.Get<MainWindow>(new ConstructorArgument("user",user));
                    mainWindow.Show();
                    loginWindow.Close();
                    return true;
                }
                else return false;
            }
            else return default;
        }
    }
}
