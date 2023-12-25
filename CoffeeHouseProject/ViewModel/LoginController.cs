using CoffeeHouseProject.DataAccess;
using CoffeeHouseProject.Script;
using CoffeeHouseProject.ViewModel;
using Ninject;
using Ninject.Parameters;
using System.IO;
using System.Windows;


namespace CoffeeHouseProject
{
    public interface ILoginController
{
        public UserTable GetUser(string login, string password);
        public bool TryLogin(string login, string password, LoginWindow loginWindow,bool savefile=false);
        public Tuple<string, string> CheckForFile();
}
    public class LoginController:ILoginController
    {
        private readonly CoffeeHouseContext _context;
        private LoginWindow _parent;
        public LoginController(CoffeeHouseContext context)
        {
            _context = context;
        }

        public UserTable GetUser(string login, string password)
        {
        var dbUserTableAccess = new DbUserTableAccess(_context);
            var user = dbUserTableAccess.GetUser(login);
            TextProcessor textProcessor= new TextProcessor();
            if (user != null)
            {
                if (textProcessor.DeleteSpaces(user.Password) == password) return user;
                else return null;
            }
            else return null;
        }

        public Tuple<string, string> CheckForFile()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open)))
                {

                    string item1 = reader.ReadString();
                    string item2 = reader.ReadString();
                    Tuple<string, string> tuple = new Tuple<string, string>(item1, item2);
                    return tuple;
                }
            }
            catch (Exception ex)
            {
                return default;
            }
            
        }

        public void SaveLoginPassword(string login,string password)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("data.bin",FileMode.Create)))
            {
                writer.Write(login);
                writer.Write(password);
            }
        }
        public bool TryLogin(string login, string password,LoginWindow loginWindow,bool savefile=false)
        {
            UserTable user;
            if (login != "" && password != "")
            {

                user = GetUser(login, password);
                if (user != null)
                {
                    if (savefile) SaveLoginPassword(login,password);
                    IKernel kernel = new StandardKernel(new DependencyModule());
                    MainWindow mainWindow = kernel.Get<MainWindow>(new ConstructorArgument("user",user)
                        ,new ConstructorArgument("window",loginWindow));
                    mainWindow.Show();
                    loginWindow.Close();
                    //MessageBox.Show(loginWindow.IsActive.ToString());
                    return true;
                }
                else return false;
            }
            else return default;
        }
    }
}
