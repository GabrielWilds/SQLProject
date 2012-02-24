using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLproj
{
    public class order
    {
        public int OrderID
        {
            get;
            private set;
        }

        public DateTime OrderDate
        {
            get;
            private set;
        }

        public order(int id, DateTime date)
        {
            OrderID = id;
            OrderDate = date;
        }
    }
}
