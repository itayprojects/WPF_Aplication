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
using static BE.ProjectEnums;

namespace WpfApp1.models
{
    /// <summary>
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        Category newCategory;
        IBLL_Category BllCategory;

        public CategoryPage()
        {
            InitializeComponent();
            newCategory = new Category();
            BllCategory = FactoryBLL_User.GetBllCategory();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            newCategory.Title = Title.Text;
            newCategory.Description = Description.Text;

            newCategory.AddDate = DateTime.Now;
            newCategory.AddBy = Int32.Parse(MainWindow.LogUserID);

            bool success = BllCategory.Add(newCategory);
            if (success)
            {
                MessageBox.Show("Add is successful");
                clear();
            }
            else
            {
                MessageBox.Show("Add didnt work");
            }
            DataTable dt = BllCategory.Select();
            DataOut.ItemsSource = dt.DefaultView;
        }

        private void DataOut_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = BllCategory.Select();
            DataOut.ItemsSource = dt.DefaultView;
        }
        private void clear()
        {
            CategoryID.Text = "";
            Title.Text = "";
            Description.Text = "";

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (!CategoryID.Text.ToString().Equals(""))
            {
                newCategory.CategoryID = Convert.ToInt32(CategoryID.Text);
                newCategory.Title = Title.Text;
                newCategory.Description = Description.Text;
                newCategory.AddDate = DateTime.Now;
                newCategory.AddBy = Int32.Parse(MainWindow.LogUserID);

                bool success = BllCategory.Update(newCategory);
                if (success)
                {
                    MessageBox.Show("update successful");
                    clear();
                }
                else
                {
                    MessageBox.Show("update didnt work");
                }
                DataTable dt = BllCategory.Select();
                DataOut.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show(" not selected");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!CategoryID.Text.ToString().Equals(""))
            {


                newCategory.CategoryID = Convert.ToInt32(CategoryID.Text);

                bool success = BllCategory.Delete(newCategory);
                if (success)
                {
                    MessageBox.Show("delete successful");
                    clear();
                }
                else
                {
                    MessageBox.Show("delete didnt work");
                }
                DataTable dt = BllCategory.Select();
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
            CategoryID.Text = dgr["Id"].ToString();
            Title.Text = dgr["Title"].ToString();
            Description.Text = dgr["Description"].ToString();

        }

        private void SearchData_TextChanged(object sender, TextChangedEventArgs e)
        {
            string KeyWord = SearchData.Text;

            if (KeyWord != null)
            {
                DataTable dt = BllCategory.Search(KeyWord);
                DataOut.ItemsSource = dt.DefaultView;
            }
            else
            {
                DataTable dt = BllCategory.Select();
                DataOut.ItemsSource = dt.DefaultView;
            }

        }
        private void deleteGrid_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dgr = DataOut.SelectedItem as DataRowView;
            newCategory.CategoryID = Convert.ToInt32(dgr["Id"].ToString());
            //dgr.Delete();
            //DataOut.SelectedItem = dgr;



            bool success = BllCategory.Delete(newCategory);
            if (success)
            {
                MessageBox.Show("delete successful");
                clear();
            }
            else
            {
                MessageBox.Show("delete didnt work");
            }
            DataTable dt = BllCategory.Select();
            DataOut.ItemsSource = dt.DefaultView;


        }
    }
}
