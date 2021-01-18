using System.Windows;

namespace Book_Rental_System
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public string FullName;
        public AdminDashboard(string fullName)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            FullName = fullName;
            lblName.Content = "Hi " + FullName;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainObj = new MainWindow();
            MainObj.Show();
            this.Close();
        }


    }
}
