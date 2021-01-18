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
        public string UserName;
        public string Password;
        SqlConnection SqlConn = new SqlConnection("Data Source=DPKASTG-05\\SQLEXPRESS;Initial Catalog=LibrarySystem;Integrated Security=True");


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
                SqlStmt = "Select * from Login where username = '" + UserName + "' and password = '" + Password + "'";
                SqlStr.CommandText = SqlStmt;
                SqlConn.Open();
                SqlReader = SqlStr.ExecuteReader();

                if (SqlReader.HasRows)
                {
                    MessageBox.Show("Login Successful");

                    Dashboard dash = new Dashboard(UserName);
                    dash.UserName = UserName;
                    dash.Show();
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

