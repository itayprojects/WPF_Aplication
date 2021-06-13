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
using WpfApp1.models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User newUser;
        IBLL_User BllUser;
        public static string LogUserID;

        public MainWindow()
        {
            InitializeComponent();

            newUser = new User();
            BllUser = FactoryBLL_User.GetBllUser();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            Window x;
            newUser.Email = userName.Text;
            newUser.Password = userPass.Password;
            bool success = BllUser.LoginCheck(newUser);
            if (success)
            {
                MessageBox.Show("please enter");
                DataTable dt = BllUser.Search(userName.Text);
                LogUserID = dt.Rows[0]["Id"].ToString();
                if (dt.Rows[0]["user_type"].ToString().Equals("1"))
                {
                    x = new AdminWin();
                    x.Show();
                    this.Close();
                }
                else
                {
                    x = new UserWin();
                    x.Show();
                    this.Close();
                }


            }
            else
            {
                MessageBox.Show("not in data");
                clear();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Window x = new register();
            x.Show();
        }
        private void clear()
        {
            userName.Text = "";
            userPass.Password = "";
        }
    }
}
