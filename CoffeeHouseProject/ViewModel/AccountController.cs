using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Ninject.Planning.Targets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CoffeeHouseProject.ViewModel
{
    public interface IAccountController
    {
       public ObservableCollection<OrderTable> GetOrders(int userid);
       public ObservableCollection<OrderLineTable> GetOrderLines(int orderid);
       public void ExportOrdersToCsv(ObservableCollection<OrderTable> orders);
       public void ExportLinesToCsv(ObservableCollection<OrderLineTable> orders);
       public void UpdateUserData(UserTable user,string name = null, string phonenumber = null);
    }

    public class AccountController : IAccountController
    {
        CoffeeHouseContext context = new CoffeeHouseContext();
        public ObservableCollection<OrderTable> GetOrders(int userid)
        {
            var _ordertables = new ObservableCollection<OrderTable>();
            var orderTables = context.OrderTables.Where(record => record.UserId == userid).ToList();

            foreach (var record in orderTables)
            {
                _ordertables.Add(record);
            }
            return _ordertables;
        }

        public ObservableCollection<OrderLineTable> GetOrderLines(int orderid)
        {
            var _orderlines = new ObservableCollection<OrderLineTable>();
            var orderLines = context.OrderLineTables.Where(record => record.OrderId == orderid).ToList();

            foreach (var record in orderLines)
            {
                _orderlines.Add(record);
            }
            return _orderlines;
        }

        public  void ExportOrdersToCsv(ObservableCollection<OrderTable> orders)
            {
                // Вызываем диалоговое окно выбора пути файла
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    Title = "Save CSV File"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    
                    string filePath = saveFileDialog.FileName;

                    
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        
                        writer.WriteLine("Order ID,Order time,Value,Order status,UserId");

                        
                        foreach (var order in orders)
                        {
                            writer.WriteLine($"{order.OrderId},{order.OrderTime},{order.Value},{order.OrderStatus},{order.UserId}");
                        }
                    }
                }
            }

        public void ExportLinesToCsv(ObservableCollection<OrderLineTable> lines)
            {
                // Вызываем диалоговое окно выбора пути файла
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    Title = "Save CSV File"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("OrderLineId,Amount,ProductId,OrderId");

                        foreach (var line in lines)
                        {
                            writer.WriteLine($"{line.OrderLineId},{line.Amount},{line.ProductId},{line.OrderId}");
                        }
                    }
                }
            }

        public void UpdateUserData(UserTable user, string name = null, string phonenumber = null)
        {
            UserTable usertoupdate= context.UserTables.FirstOrDefault(item => item.UserId == user.UserId);
            if (name != null) usertoupdate.Name = name;
            if (phonenumber != null) usertoupdate.Phonenumber = phonenumber;
            context.SaveChanges();
        }
    }
    }

