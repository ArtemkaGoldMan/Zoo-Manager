using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace WPFZooManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager
                                      .ConnectionStrings["WPFZooManager.Properties.Settings.TestDbConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection (connectionString);

            ShowZoos();

        }

        private void ShowZoos()
        {
            try
            {
                string query = "select * from Zoo";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();

                    sqlDataAdapter.Fill(zooTable);

                    listZoos.DisplayMemberPath = "Location";
                    listZoos.SelectedValuePath = "Id";
                    listZoos.ItemsSource = zooTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
