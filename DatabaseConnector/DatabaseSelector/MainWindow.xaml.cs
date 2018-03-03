using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace DatabaseSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        


        //private string dbConnectionString = @"Data Source=SZYMON\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //string dbConnectionString = @"datasource=localhost; port=3306; Database=ksiegarnia; username=root; Password=;";

        public void Polacz()
        {
           

            StringBuilder b1 = new StringBuilder();
            string dbConnectionString = (b1.Append(@"datasource=").Append(tDbSource.Text.ToString()).Append("; port=").Append(tDbPort.Text.ToString()).Append("; Database=").Append(tDbName.Text.ToString()).Append("; username=").Append(tDbUserName.Text.ToString()).Append("; Password=").Append(tDbPassword.Text.ToString()).Append(";")).ToString();
            //  string dbConnectionString = string.Join(@"Data Source =", tDbSource.Text.ToString(), "; port=",tDbPort.Text.ToString(), "; Database",tDbName.Text.ToString(), "; username=", tDbUserName.Text.ToString(), "; Password", tDbPassword.Text.ToString());
      
           
            try
              {
                MySqlConnection connectionMySql = new MySqlConnection(dbConnectionString);
                connectionMySql.Open();
                MessageBox.Show("Udalo sie polaczyc");
                string query = tDbQuery.Text.ToString();
                MySqlCommand quer = new MySqlCommand(query, connectionMySql);
                DataTable dt = new DataTable();
                dt.Load(quer.ExecuteReader());                
                dataGrid1.ItemsSource = dt.DefaultView;

            }
              catch(Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
             
           
                

            //MSSQL connection


            /* SqlConnection connection = new SqlConnection(dbConnectionString);
                 try
                 {              
                     connection.Open();
                     MessageBox.Show("Udalo sie polaczyc");
                 }
                 catch(Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }

                 SqlCommand quer = new SqlCommand("select * from ksiegarnia.zamowienia", connection);
                 DataTable dt = new DataTable();
                 dt.Load(quer.ExecuteReader());
                 connection.Close();

                 dataGrid1.ItemsSource = dt.DefaultView;      */

        }
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void bConnectSet_Click(object sender, RoutedEventArgs e)
        {
            gp1.Visibility = Visibility.Visible;
            gp2.Visibility = Visibility.Visible;
            gr1.Visibility = Visibility.Hidden;

        }


        private void bRefresh_Click(object sender, RoutedEventArgs e)
        {
            Polacz();
        }

        private void bAccept_Click(object sender, RoutedEventArgs e)
        {
            Polacz();
        }

        private void bHome_Click(object sender, RoutedEventArgs e)
        {
            gr1.Visibility = Visibility.Visible;
            gp1.Visibility = Visibility.Hidden;
            gp2.Visibility = Visibility.Hidden;
        }
    }
}
