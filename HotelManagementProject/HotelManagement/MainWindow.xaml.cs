using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Repositories;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICustomerRepository _repo = new CustomerRepository();
        private readonly string _defaultEmail;
        private readonly string _defaultPassword;
        public MainWindow()
        {
            InitializeComponent();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();

            _defaultEmail = config["account:defaultAccount:email"];
            _defaultPassword = config["account:defaultAccount:password"];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Password;

            // Check against default admin account
            if (username.Equals(_defaultEmail, StringComparison.OrdinalIgnoreCase) && password == _defaultPassword)
            {

                Management admin = new Management();
                admin.Show();
                this.Close();

                return;
            }

            // Check against repository
            var temp = _repo.CheckLogin(username, password);
            if (temp != null && temp.CustomerStatus == 1)
            {

                var customerInterface = new CustomerInterface(temp);
                customerInterface.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login. Please check your username and password.");
            }
        }
    }

}