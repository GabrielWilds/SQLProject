using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLproj
{
    public class Customer
    {
        public string FirstName
        {
            get;
            private set;
        }

        public string LastName
        {
            get;
            private set;
        }

        public Customer(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }
    }
}
