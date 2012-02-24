using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SQLproj
{
    class DataAccess
    {
        static SqlDataReader reader;

        private static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=JSL-PC\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;");
            return conn;
        }

        private static SqlCommand CreateCommand(string commandText)
        {
            SqlCommand command = new SqlCommand(commandText, GetConnection());
            command.CommandType = CommandType.Text;
            return command;
        }

        public static Customer[] GetCustomers()
        {
            SqlCommand command = CreateCommand("SELECT * FROM Customers");
            command.Connection.Open();
            reader = command.ExecuteReader();
            List<Customer> customerList = new List<Customer>();

            while (reader.Read())
            {
                customerList.Add(new Customer((string)reader["FirstName"], (string)reader["LastName"]));
            }

            Customer[] customers = customerList.ToArray();
            return customers;
        }

        public static order[] GetOrders(Customer customer)
        {
            SqlCommand command = CreateCommand("SELECT * FROM Customers WHERE FirstName = \'" + customer.FirstName + "\' AND LastName = \'" + customer.LastName + "\'");

            command.Connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            string userID = reader["CustomerID"].ToString();
            command.Connection.Close();

            command.CommandText = "SELECT * FROM Orders WHERE CustomerID = \'" + userID + "\'";
            command.Connection.Open();
            reader = command.ExecuteReader();

            List<order> orderList = new List<order>();

            while (reader.Read())
            {
                orderList.Add(new order((int)reader["OrderID"], (DateTime)reader["OrderDate"]));
            }

            order[] orders = orderList.ToArray();
            return orders;
        }

        public static OrderDetail[] GetOrderDetails(order selectedOrder)
        {
            List<OrderDetail> detailList = new List<OrderDetail>();
            SqlCommand command = CreateCommand("SELECT * FROM OrderInfo WHERE OrderID = \'" + selectedOrder.OrderID.ToString() + "\'");
            command.Connection.Open();

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                detailList.Add(new OrderDetail((int)reader["Quantity"], (string)reader["Product"]));
            }

            OrderDetail[] details = detailList.ToArray();
            return details;
        }

        public static void AddNewCustomer(string first, string last, string address, string city, string state, int zip, string phone)
        {
            SqlCommand command = CreateCommand("INSERT INTO Customers (FirstName, LastName, Address, City, State, ZIP, Phone) VALUES ('" + first + "', '" + last + "', '" + address + "', '" + city + "', '" + state + "', '" + zip + "', '" + phone + "')");
            command.Connection.Open();
            reader = command.ExecuteReader();
            command.Connection.Close();
        }

    }
}
