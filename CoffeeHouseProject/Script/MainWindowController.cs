using CoffeeHouseProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouseProject.Script
{
    public interface IMainWindowController
    {
        public void HandleAddToCart(object sender, CustomOrderLine orderLine)
    }

    public class MainWindowController : IMainWindowController
    {
        public void HandleAddToCart(object sender, CustomOrderLine orderLine)
        {

        }
    }
}
