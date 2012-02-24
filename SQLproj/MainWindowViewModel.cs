using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SQLproj
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Customer[] _customers;
        private order[] _orders;
        private Customer _customer;


        public Customer[] Customers
        {
            get { return _customers; }
            private set { _customers = value; OnPropertyChanged("Customers"); }
        }

        public order[] Orders
        {
             get { return _orders; }
            private set { _orders = value; OnPropertyChanged("Orders"); }
        }

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }


        public MainWindowViewModel()
        {
            Customers = DataAccess.GetCustomers();
            Customer = Customers[0];
        }

      
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GetOrders()
        {
            Orders = DataAccess.GetOrders(Customer);
            OrdersWindow orderWindow = new OrdersWindow(Orders);
            orderWindow.ShowDialog();
        }

        public void NewUser()
        {
            NewUserWindow newUser = new NewUserWindow();
            newUser.ShowDialog();
            Customers = DataAccess.GetCustomers();
        }
    }
}
