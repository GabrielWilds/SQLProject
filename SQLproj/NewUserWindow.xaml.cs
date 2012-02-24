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
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        public NewUserWindow()
        {
            this.DataContext = new NewUserWindowViewModel();
            InitializeComponent();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            if (((NewUserWindowViewModel)this.DataContext).AddCustomerToDatabase())
                this.Close();
        }
    }
}
