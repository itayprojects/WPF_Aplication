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

namespace WpfApp1.models.userModels
{
    /// <summary>
    /// Interaction logic for UserSet.xaml
    /// </summary>
    public partial class UserSet : Page
    {
        User newUser;
        IBLL_User BllUser;

        public UserSet()
        {
            InitializeComponent();
            newUser = new User();
            BllUser = FactoryBLL_User.GetBllUser();
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
                newUser.User_Type = UserType.user;
                newUser.AddDate = DateTime.Now;
                newUser.AddBy = Int32.Parse(MainWindow.LogUserID);

                bool success = BllUser.Update(newUser);
                if (success)
                {
                    MessageBox.Show("update successful");

                }
                else
                {
                    MessageBox.Show("update didnt work");
                }
                DataTable dt = BllUser.Select();

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
                var result=MessageBox.Show("are you shur you whant to delete and by that to close the app close","warning",MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    newUser.UserID = Convert.ToInt32(UserID.Text);

                    bool success = BllUser.Delete(newUser);
                    if (success)
                    {
                        MessageBox.Show("delete successful");
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        MessageBox.Show("delete didnt work");
                    }
                    DataTable dt = BllUser.Select();
                }
            }
            else
            {
                MessageBox.Show("User was not selected");
            }
        }

        private void userChange_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = BllUser.userById(MainWindow.LogUserID);

            UserID.Text = dt.Rows[0]["Id"].ToString();
            FirstName.Text = dt.Rows[0]["First_Name"].ToString();
            LastName.Text = dt.Rows[0]["Last_Name"].ToString();
            Phone.Text = dt.Rows[0]["Phone"].ToString();
            Email.Text = dt.Rows[0]["Email"].ToString();
            Password.Text = dt.Rows[0]["Password"].ToString();
            Address.Text = dt.Rows[0]["Address"].ToString();
        }

        
    }
}
