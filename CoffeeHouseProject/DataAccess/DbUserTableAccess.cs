using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouseProject.DataAccess
{
    interface IDbUserTableAccess
    {
        public UserTable GetUser(string login);
        public void Create(string login, string name, string password);
        public void Update();
        public void Delete();
    }
    class DbUserTableAccess : IDbUserTableAccess
    {
        private readonly CoffeeHouseContext _context;
        public DbUserTableAccess(CoffeeHouseContext context)
        {
            _context = context;
        }
        public void Create(string login,string name,string password)
        {
            _context.UserTables.Add(new UserTable { Login=login, Name = name, Password = password,Usertype="CLIENT"});
            _context.SaveChanges();
        }
        
        public void Update()
        {
            
        }
        public void Delete()
        {

        }

        public UserTable GetUser(string login)
        {
            var usertable = _context.UserTables.FirstOrDefault(m => m.Login == login);
            return usertable;
        }
    }
}
