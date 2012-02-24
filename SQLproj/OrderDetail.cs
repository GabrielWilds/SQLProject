using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLproj
{
    public class OrderDetail
    {
        public string Product
        {
            get;
            private set;
        }

        public int Quantity
        {
            get;
            private set;
        }

        public OrderDetail(int count, string name)
        {
            Product = name;
            Quantity = count;
        }
    }
}
