using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLproj
{
    class OrderDetailWindowViewModel
    {
        public OrderDetail[] OrderDetails
        {
            get;
            private set;
        }

        public OrderDetailWindowViewModel(OrderDetail[] details)
        {
            OrderDetails = details;
        }
    }
}
