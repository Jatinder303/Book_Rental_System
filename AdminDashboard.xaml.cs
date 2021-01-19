using System.Windows;

namespace Book_Rental_System
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public string FullName;
        DatabaseManager objDb = new DatabaseManager();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DGV_Books.ItemsSource = objDb.ListBooks("%").DefaultView;
        }

        private void btn_AddBook_Click(object sender, RoutedEventArgs e)
        {
            if (txt_BookName.Text != "" && txt_Author.Text != "")
            {
                bool bookadd = objDb.AddBooks(txt_BookName.Text, txt_Author.Text);
                if (bookadd == true)
                {
                    MessageBox.Show("Book Added");
                    txt_Author.Clear();
                    txt_BookName.Clear();
                    DGV_Books.ItemsSource = objDb.ListBooks("%").DefaultView;
                }
            }
            else
            {
                MessageBox.Show("Please insert the book data");
            }
        }
    }
}
