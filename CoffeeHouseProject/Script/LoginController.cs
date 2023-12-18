using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CoffeeHouseProject.DataAccess;
using CoffeeHouseProject.ViewModel;

namespace CoffeeHouseProject
{
    public interface ILoginController
{
        public UserTable TryLogin(string login, string password);
    }
    public class LoginController:ILoginController
    {
        private readonly CoffeeHouseContext _context;
        public LoginController(CoffeeHouseContext context)
        {
            _context = context;
        }

        public UserTable TryLogin(string login, string password)
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
    }
}
