using CoffeeHouseProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouseProject
{
    public interface IRegistrationController
    {
        public bool RegisterUser(string login,string name,string password);
    }
    public class RegistrationController: IRegistrationController
    {
        private readonly CoffeeHouseContext _context;
       public RegistrationController(CoffeeHouseContext context)
        {
            _context = context;
        }
        public bool RegisterUser(string login, string name, string password)
        {
            DbUserTableAccess dbUserTableAccess = new DbUserTableAccess(_context);
            if (dbUserTableAccess.GetUser(login) == null)
            {
                dbUserTableAccess.Create(login, name, password);
                return true;
            }
            return false;
        }

    }
}
