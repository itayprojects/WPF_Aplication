using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp1.models
{
    /// <summary>
    /// Interaction logic for StorePage.xaml
    /// </summary>
    public partial class StorePage : Page
    {
        IBLL_User BllUser;
        IBLL_Product BllProduct;
        IBLL_PurchaseSummary BllPurchase;
        PurchaseSummary newPurchase;
        DataTable dataTablePurch = new DataTable();
        bool dataEntry = false;


        static int proId = -1;
        static int userId = -1;

        public StorePage()
        {
            InitializeComponent();
            BllUser = FactoryBLL_User.GetBllUser();
            BllProduct = FactoryBLL_User.GetBllProduct();
            newPurchase=new PurchaseSummary();
            BllPurchase = FactoryBLL_User.GetBllPurchaseSummary();
        }

        
        

        private void SearchUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            string KeyWord = SearchUser.Text;

            if (KeyWord != null)
            {
                DataTable dt = BllUser.SearchUser(KeyWord);
                UserData.ItemsSource = dt.DefaultView;
            }
            else
            {
                DataTable dt = BllUser.SelectUser();
                UserData.ItemsSource = dt.DefaultView;
            }
        }

        private void UserData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dgr = UserData.SelectedItem as DataRowView;

            userId =Int32.Parse(dgr["Id"].ToString());
            
            FirstName.Text = dgr["First_Name"].ToString();
            LastName.Text = dgr["Last_Name"].ToString();
            Phone.Text = dgr["Phone"].ToString();
            Email.Text = dgr["Email"].ToString();
            
            Address.Text = dgr["Address"].ToString();

            dataEntry = true;

            dataPurchase.ItemsSource = null;
            dataPurchase.Items.Refresh();
        }

        private void SearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            string KeyWord = SearchProduct.Text;

            if (KeyWord != null)
            {
                DataTable dt = BllProduct.SearcProduct(KeyWord);
                ProductData.ItemsSource = dt.DefaultView;
            }
            else
            {
                DataTable dt = BllProduct.SelectProduct();
                ProductData.ItemsSource = dt.DefaultView;
            }
        }
        
        private void ProductData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dgr = ProductData.SelectedItem as DataRowView;
            proId = Int32.Parse( dgr["Id"].ToString());
            Name.Text = dgr["Name"].ToString();
            Price.Text = dgr["Price"].ToString();
            Quantity.Text = dgr["Quantity"].ToString();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int row = dataTablePurch.Rows.Count;
            dataTablePurch.Columns["Id"].AutoIncrement = true;
            dataTablePurch.Columns["id"].AutoIncrementSeed = 1;
            dataTablePurch.Columns["id"].AutoIncrementStep = 1;
            if ((userId == -1) || (!selectDate.SelectedDate.HasValue))
            {
                MessageBox.Show("please select user and time");
            }
            else
            {
                
                if (dataEntry && (dataTablePurch = BllPurchase.SearchByDate(userId, selectDate.SelectedDate.Value)).Rows.Count > 0)
                {
                    row = dataTablePurch.Rows.Count;
                }
                row++;
                dataEntry = false;
                if (dataTablePurch.Rows.Count>0)//dataPurchase.ItemsSource is DataView
                {
                    foreach (DataRowView drv in dataTablePurch.DefaultView)  //foreach (DataRowView drv in (DataView)dataPurchase.ItemsSource)
                        if ((int)drv["Product_Id"] == proId)
                        {
                            MessageBox.Show("product already exist");
                            return;
                            // This is the data row view record you want...
                            //dataGrid1.SelectedItem = drv;
                        }
                }
                //row,
                dataTablePurch.Rows.Add(
                    null,
                    userId,
                    Name.Text,
                    decimal.Parse(Price.Text),
                    decimal.Parse(Quantity.Text),
                    decimal.Parse(Quantity.Text),
                    selectDate.SelectedDate.Value,
                    Int32.Parse(MainWindow.LogUserID),
                    proId);
                
                dataPurchase.ItemsSource = dataTablePurch.DefaultView;

                

            }
        }

        private void dataPurchase_Loaded(object sender, RoutedEventArgs e)
        {

           // dataPurchase.Columns[0].Visibility = Visibility.Hidden;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            dataTablePurch.Columns.Add("Id");
            dataTablePurch.Columns.Add("User_Id");
            dataTablePurch.Columns.Add("Product_Name");
            dataTablePurch.Columns.Add("Price");
            dataTablePurch.Columns.Add("Quantity");
            dataTablePurch.Columns.Add("Total");
            dataTablePurch.Columns.Add("Added_Date");
            dataTablePurch.Columns.Add("Added_By");
            dataTablePurch.Columns.Add("Product_Id");
        }

        private void selectDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dataEntry = true;
            dataPurchase.ItemsSource = null;
            dataPurchase.Items.Refresh();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;
            BllPurchase.DeleteByDate(userId, selectDate.SelectedDate.Value);
            for (int i = 0; i < dataTablePurch.Rows.Count; i++)
            {
                PurchaseSummary Purchase = new PurchaseSummary();
                //userId, Name.Text, Price.Text, Quantity.Text, Quantity.Text, selectDate.SelectedDate.Value, Int32.Parse(MainWindow.LogUserID), proId
                Purchase.User_Id = userId;
                Purchase.Product_Name = dataTablePurch.Rows[i]["Product_Name"].ToString();
                Purchase.Price = decimal.Parse( dataTablePurch.Rows[i]["Price"].ToString());
                Purchase.Quantity = decimal.Parse(dataTablePurch.Rows[i]["Quantity"].ToString());
                Purchase.Total = decimal.Parse(dataTablePurch.Rows[i]["Total"].ToString());
                Purchase.Added_Date =DateTime.Parse( dataTablePurch.Rows[i]["Added_Date"].ToString());
                Purchase.AddBy = Int32.Parse(dataTablePurch.Rows[i]["Added_By"].ToString());
                Purchase.Product_Id =Int32.Parse( dataTablePurch.Rows[i]["Product_Id"].ToString());

                success = BllPurchase.Add(Purchase);
                if (!success)
                {
                    MessageBox.Show("update didnt work");
                    break;
                    
                    //clear();
                }
                

                //DataTable dt = BllCategory.Select();
                //DataOut.ItemsSource = dt.DefaultView;
            }
            if (success)
                MessageBox.Show("update successful");
            dataPurchase.ItemsSource = null;
            dataPurchase.Items.Refresh();
            dataPurchase.ItemsSource = BllPurchase.Select().DefaultView;

        }
    }
}
