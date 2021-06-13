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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        User newUser;
        IBLL_User BllUser;

        public UserPage()
        {
            InitializeComponent();
            newUser = new User();
            BllUser = FactoryBLL_User.GetBllUser();
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < 1000; i++)
            {
                newUser.FirstName = "no"+i;
                newUser.LasttName = "no" + i;
                newUser.Email = "no" + i + "@gmail.com";
                newUser.Password = "no" + i;
                newUser.Phone = "0508888" + i;
                newUser.address = "no" + i;
                newUser.User_Type = (UserType)UserType.SelectedIndex;
                newUser.AddDate = DateTime.Now;
                newUser.AddBy = 1;
                BllUser.Add(newUser);
            }
        }


        private void AddUser_Click(object sender, RoutedEventArgs e)
        {

            newUser.FirstName = FirstName.Text;
            newUser.LasttName = LastName.Text;
            newUser.Email = Email.Text;
            newUser.Password = Password.Text;
            newUser.Phone = Phone.Text;
            newUser.address = Address.Text;
            newUser.User_Type = (UserType)UserType.SelectedIndex;
            newUser.AddDate = DateTime.Now;
            newUser.AddBy = Int32.Parse(MainWindow.LogUserID);

            bool success = BllUser.Add(newUser);
            if (success)
            {
                MessageBox.Show("Add is successful");
                clear();
            }
            else
            {
                MessageBox.Show("Add didnt work");
            }
            DataTable dt = BllUser.Select();
            DataOut.ItemsSource = dt.DefaultView;
        }

        private void DataOut_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = BllUser.Select();
            DataOut.ItemsSource = dt.DefaultView;
        }
        private void clear()
        {
            UserID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Phone.Text = "";
            Email.Text = "";
            Password.Text = "";
            Address.Text = "";
            UserType.SelectedIndex = 0;

        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if (!UserID.Text.ToString().Equals(""))
            {
                newUser.UserID = Convert.ToInt32(UserID.Text);
                newUser.FirstName = FirstName.Text;
                newUser.LasttName = LastName.Text;
                newUser.Email = Email.Text;
                newUser.Password = Password.Text;
                newUser.Phone = Phone.Text;
                newUser.address = Address.Text;
                newUser.User_Type = (UserType)UserType.SelectedIndex;
                newUser.AddDate = DateTime.Now;
                newUser.AddBy =Int32.Parse(MainWindow.LogUserID);

                bool success = BllUser.Update(newUser);
                if (success)
                {
                    MessageBox.Show("update successful");
                    clear();
                }
                else
                {
                    MessageBox.Show("update didnt work");
                }
                DataTable dt = BllUser.Select();
                DataOut.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show("User was not selected");
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (!UserID.Text.ToString().Equals(""))
            {


                newUser.UserID = Convert.ToInt32(UserID.Text);

                bool success = BllUser.Delete(newUser);
                if (success)
                {
                    MessageBox.Show("delete successful");
                    clear();
                }
                else
                {
                    MessageBox.Show("delete didnt work");
                }
                DataTable dt = BllUser.Select();
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
           
            UserID.Text = dgr["Id"].ToString();
            FirstName.Text = dgr["First_Name"].ToString();
            LastName.Text = dgr["Last_Name"].ToString();
            Phone.Text = dgr["Phone"].ToString();
            Email.Text = dgr["Email"].ToString(); 
            Password.Text = dgr["Password"].ToString(); 
            Address.Text = dgr["Address"].ToString();
            UserType.SelectedIndex =Int32.Parse(dgr["user_type"].ToString());

        }

        private void SearchData_TextChanged(object sender, TextChangedEventArgs e)
        {
            string KeyWord = SearchData.Text;

            if (KeyWord!=null)
            {
                DataTable dt = BllUser.Search(KeyWord);
                DataOut.ItemsSource = dt.DefaultView;
            }
            else
            {
                DataTable dt = BllUser.Select();
                DataOut.ItemsSource = dt.DefaultView;
            }
            
        }

        private void deleteGrid_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dgr = DataOut.SelectedItem as DataRowView;
            newUser.UserID = Convert.ToInt32(dgr["Id"].ToString());
            //dgr.Delete();
            //DataOut.SelectedItem = dgr;

            

            bool success = BllUser.Delete(newUser);
            if (success)
            {
                MessageBox.Show("delete successful");
                clear();
            }
            else
            {
                MessageBox.Show("delete didnt work");
            }
            DataTable dt = BllUser.Select();
            DataOut.ItemsSource = dt.DefaultView;
        }
            
    }
}
