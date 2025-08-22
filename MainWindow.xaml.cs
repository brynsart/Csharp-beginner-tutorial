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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
//using Microsoft.Data.SqlClient;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["WpfApp1.Properties.Settings.BRYNSDBConnectionString"].ConnectionString;

            // Initialize connection
            sqlConnection = new SqlConnection(connectionString);

            //have to call methods in mainwindow
            DisplayStores();
            DisplayAllProducts();
        }

        private void DisplayStores()
        {
            try
            {
                string query = "SELECT * FROM Store";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    // Acts as an interface between DB and this code
                    DataTable storeTable = new DataTable();

                    sqlDataAdapter.Fill(storeTable);

                    // Define the column we are displaying in listbox
                    storeList.DisplayMemberPath = "Name";

                    // Define what is unique about each item in the list
                    storeList.SelectedValuePath = "Id";

                    // The content we will use to populate the list
                    storeList.ItemsSource = storeTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                // Handle exception here
                MessageBox.Show(ex.ToString());
            }
        }

        private void DisplayStoreInventory()
        {
            try
            {
                // Find shoes that match for the specific product
                // by using the store id clicked in the listbox
                string query = "SELECT * FROM Product p inner join StoreInventory si ON p.Id = si.ProductId WHERE si.StoreId = @StoreId";

                // To use the passed variable we must use SqlCommand
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // Connect to DB, run query and then close DB
                // connection
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Use our query and connection to populate the list
                // with store names
                using (sqlDataAdapter)
                {
                    // We need the ID clicked to perform our query
                    sqlCommand.Parameters.AddWithValue("@StoreId", storeList.SelectedValue);

                    // Acts as an interface between DB and this code
                    DataTable inventoryTable = new DataTable();

                    sqlDataAdapter.Fill(inventoryTable);

                    // Define the column we are displaying in listbox
                    storeInventory.DisplayMemberPath = "Brand";

                    // Define what is unique about each item in the list
                    storeInventory.SelectedValuePath = "Id";

                    // The content we will use to populate the list
                    storeInventory.ItemsSource = inventoryTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                // Handle exception here
                MessageBox.Show(ex.ToString());
            }
        }

        private void storeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayStoreInventory();
        }

        private void DisplayAllProducts()
        {
                try
                {
                    string query = "SELECT * FROM Product";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                    using (sqlDataAdapter)
                    {
                        DataTable productTable = new DataTable();

                        sqlDataAdapter.Fill(productTable);

                        productList.DisplayMemberPath = "Brand";

                        productList.SelectedValuePath = "Id";

                        productList.ItemsSource = productTable.DefaultView;
                    }
                }
            catch (Exception ex)
            {
                // Handle exception here
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddStoreClick(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("AddStoreClicked");
            try
            {
                // Add list of parameters using textbox names
                // You also have to define data type
                List<SqlParameter> parameters = new List<SqlParameter>(){
                    new SqlParameter("@Name", SqlDbType.NVarChar) {Value = storeName.Text},
                    new SqlParameter("@Street", SqlDbType.NVarChar) {Value = storeStreet.Text},
                    new SqlParameter("@City", SqlDbType.NVarChar) {Value = storeCity.Text},
                    new SqlParameter("@State", SqlDbType.NChar) {Value = storeState.Text},
                    new SqlParameter("@Zip", SqlDbType.Int) {Value = storeZip.Text}
                };

                // Make sure they are in the same order as the DB
                string query = "INSERT INTO Store VALUES (@Name, @Street, @City, @State, @Zip)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                // Used to add a range of values
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                DataTable storeTable = new DataTable();

                // Abbreviated way to use adapter
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand)) adapter.Fill(storeTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                DisplayStores();
            }
        }

        private void AddInventoryClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "INSERT INTO StoreInventory VALUES (@StoreId, @ProductId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@StoreId",storeList.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@ProductId",productList.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                DisplayStoreInventory();
            }
        }

        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("AddProductClicked");
            try
            {
                // Add list of parameters using textbox names
                // You also have to define data type
                List<SqlParameter> parameters = new List<SqlParameter>(){
                    new SqlParameter("@Manufacturer", SqlDbType.NVarChar) {Value = prodManu.Text},
                    new SqlParameter("@Brand", SqlDbType.NVarChar) {Value = prodBrand.Text}
                };

                // Make sure they are in the same order as the DB
                string query = "INSERT INTO Product VALUES (@Manufacturer, @Brand)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                // Used to add a range of values
                sqlCommand.Parameters.AddRange(parameters.ToArray());

                DataTable productTable = new DataTable();

                // Abbreviated way to use adapter
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand)) adapter.Fill(productTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                DisplayAllProducts();
            } 
        }

        private void DeleteStoreClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM Store WHERE Id = @StoreId";

                // Simple way to execute a query without adapter
                // Open and close on our own
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                // Pass value for query
                sqlCommand.Parameters.AddWithValue("@StoreId", storeList.SelectedValue);

                // Execute query
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // This throws an error because the store inventory
                // list expects a default store selection
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                // Update the store listbox
                DisplayStores();
            }
        }
        //ON DELETE CASCADE used to automatically update tables like Store Inventory
        private void DeleteInventoryClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM StoreInventory WHERE ProductId = @ProductId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ProductId", storeInventory.SelectedValue);

                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                DisplayStoreInventory();
            }
        }

        private void DeleteProductClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM Product WHERE Id = @ProductId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ProductId", productList.SelectedValue);

                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                DisplayAllProducts();
            }
        }
    }
}