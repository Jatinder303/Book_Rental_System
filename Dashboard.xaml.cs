using System.Windows;

namespace Book_Rental_System
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public string UserName;
        public Dashboard(string userName)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            UserName = userName;
            lblName.Content = "Hi " + UserName;

        }
    }
}
