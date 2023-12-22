using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoffeeHouseProject.View
{
    /// <summary>
    /// Логика взаимодействия для PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : UserControl
    {
        public string CardNumber { get; set; }
        public string MM { get; set; }
        public PaymentPage()
        {
            InitializeComponent();
            DataContext = this;
            CardNumber ="Номер карты";
            MM = "ММ";
        }
    }
}
