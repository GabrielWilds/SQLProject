using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SQLproj
{
    public class NewUserWindowViewModel
    {
        public int _zip = 0;

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string ZIP
        {
            get;
            set;
        }

        public int ZIPCode
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string Phone
        {
            get;
            set;
        }

        public bool CheckCustomerInfo()
        {
            bool valid = false;
            if (FirstName == null)
                MessageBox.Show("Enter a first name for the customer.", "Empty first name field");
            else if (LastName == null)
                MessageBox.Show("Enter a last name for the customer.", "Empty last name field");
            else if (Address == null)
                MessageBox.Show("Enter an address for the customer.", "Empty address field");
            else if (City == null)
                MessageBox.Show("Enter a city for the customer.", "Empty city field");
            else if (State == null)
                MessageBox.Show("Enter a two letter state code for the customer.", "Empty state field");
            else if (State.Length > 2)
                MessageBox.Show("Enter state as a two letter code, for example PA or NY.", "Invalid state field");
            else if (ZIP == null)
                MessageBox.Show("Enter a five digit ZIP code", "Empty ZIP field");
            else if (!int.TryParse(ZIP, out _zip))
                MessageBox.Show("Use only digits in the ZIP value", "Invalid ZIP code");
            else if (ZIP.Length < 5 || ZIP.Length > 5)
                MessageBox.Show("Enter a five digit ZIP code", "Wrong number of digits in ZIP field");
            else if (Phone == null)
                MessageBox.Show("Enter a phone number for the customer", "Empty phone field");
            else if (Phone.Length < 7)
                MessageBox.Show("Insufficient length for phone number value. Include all digits, including area code and extension if neccesary.", "Invalid phone field");
            else
                valid = true;


            return valid;
        }

        public bool AddCustomerToDatabase()
        {
            int.TryParse(ZIP, out _zip);
            bool valid = CheckCustomerInfo();

            if (valid)
                DataAccess.AddNewCustomer(FirstName, LastName, Address, City, State, ZIPCode, Phone);

            return valid;
        }
    }
}
