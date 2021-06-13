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
using System.Windows.Shapes;
using static BE.ProjectEnums;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Window
    {
        User newUser;
        IBLL_User BllUser;
        private int _errorrs = 0;

        public register()
        {
            InitializeComponent();
            newUser = new User();
            BllUser = FactoryBLL_User.GetBllUser();
            this.DataContext = newUser;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = BllUser.Search(Email.Text.ToString());

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("user already exsist");
            }
            else if (!Password.Text.Equals(Confirm.Text))
            {
                MessageBox.Show("password was not confirm");
            }
            else
            {
                newUser.FirstName = FirstName.Text;
                newUser.LasttName = LastName.Text;
                newUser.Email = Email.Text;
                newUser.Password = Password.Text;
                newUser.Phone = Phone.Text;
                newUser.address = Address.Text;
                newUser.User_Type = UserType.user;
                newUser.AddDate = DateTime.Now;
                newUser.AddBy = 1;

                bool success = BllUser.Add(newUser);
                if (success)
                {
                    MessageBox.Show("Add is successful");
                    clear();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Add didnt work");
                }
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clear()
        {

            FirstName.Text = "";
            LastName.Text = "";
            Phone.Text = "";
            Email.Text = "";
            Password.Text = "";
            Confirm.Text = "";
            Address.Text = "";


        }

        private void FirstName_Error(object sender, ValidationErrorEventArgs e)
        {

            if (e.Action==ValidationErrorEventAction.Added)
            {
                _errorrs++;
                AddUser.IsEnabled = false;
            }
            else
            {
                _errorrs--;
                if (_errorrs == 0)
                {
                    AddUser.IsEnabled = true;
                }
            }
        }
    }
}
