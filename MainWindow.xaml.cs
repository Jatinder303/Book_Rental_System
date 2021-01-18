using System;
using System.Data.SqlClient;
using System.Windows;

namespace Book_Rental_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        public string UserName, FullName;
        public string Password, UserType;
        SqlConnection SqlConn = new SqlConnection("Data Source=DPKASTG-05\\SQLEXPRESS;Initial Catalog=LibrarySystem;Integrated Security=True");

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserName = txtUserName.Text;
            Password = password.Text;
            LoginCheck();

        }

        private void LoginCheck()
        {
            SqlCommand SqlStr = new SqlCommand();
            SqlDataReader SqlReader;
            string SqlStmt;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Select FullName, usertype from Users u Inner Join Login l  on u.Username = l.username where l.username = @UserName and l.password = @Password";

                using (SqlCommand cmd = new SqlCommand(SqlStmt, SqlConn))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    SqlConn.Open();
                    SqlReader = cmd.ExecuteReader();
                }


                if (SqlReader.HasRows)
                {
                    MessageBox.Show("Login Successful");
                    SqlReader.Read();
                    FullName = SqlReader[0].ToString();
                    UserType = SqlReader[1].ToString();



                    if (UserType == "Admin")

                    {

                        AdminDashboard admin = new AdminDashboard(FullName);
                        admin.FullName = FullName;
                        admin.Show();

                    }

                    else

                    {

                        Dashboard dash = new Dashboard(FullName);
                        dash.FullName = FullName;
                        dash.Show();

                    }

                    SqlConn.Close();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Check Username/Password");
                    txtUserName.Clear();
                    password.Clear();
                    SqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                SqlConn.Close();
            }
        }
    }
}

