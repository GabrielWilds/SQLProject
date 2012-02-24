using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLproj
{
    class OrdersWindowViewModel
    {
        public order[] Orders
        {
            get;
            private set;
        }

        public order Order
        {
            get;
            set;
        }

        public OrdersWindowViewModel(order[] _orders)
        {
            Orders = _orders;
            if(Orders.Length > 0)
                Order = Orders[0];
        }

        public void GetOrderDetails()
        {
            OrderDetail[] details = DataAccess.GetOrderDetails(Order);
            OrderDetailWindow detailWindow = new OrderDetailWindow(details);
            detailWindow.Show();
        }
    }
}
