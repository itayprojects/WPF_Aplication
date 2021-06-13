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
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        Product newProduct;
        IBLL_Product BllProduct;

        public ProductPage()
        {
            InitializeComponent();
            newProduct = new Product();
            BllProduct = FactoryBLL_User.GetBllProduct();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            newProduct.Name = Name.Text;
            newProduct.Category = Category.Text;
            newProduct.Description = Description.Text;
            newProduct.Price = decimal.Parse(Price.Text);
            newProduct.Quantity = decimal.Parse(Quantity.Text);
            newProduct.AddDate = DateTime.Now;
            newProduct.AddBy = Int32.Parse(MainWindow.LogUserID);

            bool success = BllProduct.Add(newProduct);
            if (success)
            {
                MessageBox.Show("Add is successful");
                clear();
            }
            else
            {
                MessageBox.Show("Add didnt work");
            }
            DataTable dt = BllProduct.Select();
            DataOut.ItemsSource = dt.DefaultView;
        }

        private void DataOut_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = BllProduct.Select();
            DataOut.ItemsSource = dt.DefaultView;
        }
        private void clear()
        {
            ProductID.Text = "";
            Name.Text = "";
            Category.Text = "";
            Description.Text = "";
            Price.Text = "";
            Quantity.Text = "";
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (!ProductID.Text.ToString().Equals(""))
            {
                newProduct.ProductID = Convert.ToInt32(ProductID.Text);
                newProduct.Name = Name.Text;
                newProduct.Category = Category.Text;
                newProduct.Description = Description.Text;
                newProduct.Price = decimal.Parse(Price.Text);
                newProduct.Quantity = decimal.Parse(Quantity.Text);

                newProduct.AddDate = DateTime.Now;
                newProduct.AddBy = Int32.Parse(MainWindow.LogUserID);

                bool success = BllProduct.Update(newProduct);
                if (success)
                {
                    MessageBox.Show("update successful");
                    clear();
                }
                else
                {
                    MessageBox.Show("update didnt work");
                }
                DataTable dt = BllProduct.Select();
                DataOut.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show("User was not selected");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!ProductID.Text.ToString().Equals(""))
            {


                newProduct.ProductID = Convert.ToInt32(ProductID.Text);

                bool success = BllProduct.Delete(newProduct);
                if (success)
                {
                    MessageBox.Show("delete successful");
                    clear();
                }
                else
                {
                    MessageBox.Show("delete didnt work");
                }
                DataTable dt = BllProduct.Select();
                DataOut.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show("User was not selected");
            }
        }

        private void DataOut_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dgr = DataOut.SelectedItem as DataRowView;
            ProductID.Text = dgr["Id"].ToString();
            Name.Text = dgr["Name"].ToString();
            Category.Text = dgr["Category"].ToString();
            Description.Text = dgr["Description"].ToString();
            Price.Text = dgr["Price"].ToString();
            Quantity.Text = dgr["Quantity"].ToString();
        }

        private void SearchData_TextChanged(object sender, TextChangedEventArgs e)
        {
            string KeyWord = SearchData.Text;

            if (KeyWord != null)
            {
                DataTable dt = BllProduct.Search(KeyWord);
                DataOut.ItemsSource = dt.DefaultView;
            }
            else
            {
                DataTable dt = BllProduct.Select();
                DataOut.ItemsSource = dt.DefaultView;
            }

        }

        IBLL_Category AllCategory= FactoryBLL_User.GetBllCategory();

        private void Category_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable CategoryTt = AllCategory.Select();
            Category.ItemsSource = CategoryTt.DefaultView;
            Category.DisplayMemberPath = "Title";
            Category.SelectedValuePath = "Title";


        }
        private void deleteGrid_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dgr = DataOut.SelectedItem as DataRowView;
            newProduct.ProductID = Convert.ToInt32(dgr["Id"].ToString());
            //dgr.Delete();
            //DataOut.SelectedItem = dgr;



            bool success = BllProduct.Delete(newProduct);
            if (success)
            {
                MessageBox.Show("delete successful");
                clear();
            }
            else
            {
                MessageBox.Show("delete didnt work");
            }
            DataTable dt = BllProduct.Select();
            DataOut.ItemsSource = dt.DefaultView;


        }

        
    }
}
