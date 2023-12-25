using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouseProject.ViewModel
{
    public interface IDbAccessController
    {
        public ObservableCollection<ProductTable> GetProductTable();

        public ObservableCollection<UserTable> GetUsersTable();

        public void AddProduct(string name,string image,string price);

        public void SaveTableChanges(ObservableCollection<ProductTable> products = null, ObservableCollection<UserTable> users = null);
    }

    public class DbAccessController : IDbAccessController
    {
        CoffeeHouseContext context= new CoffeeHouseContext();
        public ObservableCollection<ProductTable> GetProductTable()
        {
            var _producttables = new ObservableCollection<ProductTable>();
            var productTables = context.ProductTables.ToList();

            foreach (var record in productTables)
            {
                _producttables.Add(record);
            }
            return _producttables;
        }

        public ObservableCollection<UserTable> GetUsersTable()
        {
            var _usertables = new ObservableCollection<UserTable>();
            var userTables = context.UserTables.ToList();

            foreach (var record in userTables)
            {
                _usertables.Add(record);
            }
            return _usertables;
        }

        public void AddProduct(string name, string image, string stringprice)
        {
            int price;
            //if (!File.Exists(image)) throw new Exception("File not found");
            try
            {
                 price = int.Parse(stringprice);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid price");
            }
            if (price < 0) throw new Exception("Invalid price");
            using (var CoffeeHouseContext = new CoffeeHouseContext())
            {
                ProductTable product = new ProductTable { Name = name, Image = image, Price = price };
                context.ProductTables.Add(product);
                context.SaveChanges();
            }
        }

        public void SaveTableChanges(ObservableCollection<ProductTable> products=null,ObservableCollection<UserTable>users=null)
        {
            using (var context = new CoffeeHouseContext())
            {
                if (users != null)
                    foreach (var user in users)
                    {
                        context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                if (products != null)
                    foreach (var product in products)
                    {
                        context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }

                context.SaveChanges();
            }
        }
    }

    
}
