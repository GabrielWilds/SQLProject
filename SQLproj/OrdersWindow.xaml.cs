using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SQLproj
{
    /// <summary>
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow(order[] _orders)
        {
            this.DataContext = new OrdersWindowViewModel(_orders);
            InitializeComponent();
        }

        private void GetDetails(object sender, RoutedEventArgs e)
        {
            ((OrdersWindowViewModel)this.DataContext).GetOrderDetails();
        }
    }
}
