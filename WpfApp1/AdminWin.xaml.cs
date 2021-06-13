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
using WpfApp1.models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AdminWin.xaml
    /// </summary>
    public partial class AdminWin : Window
    {
        IBLL_User BllUser;
        public AdminWin()
        {
            InitializeComponent();
            BllUser = FactoryBLL_User.GetBllUser();
        }

        private void Btn_open_Click(object sender, RoutedEventArgs e)
        {
            btn_open.Visibility = Visibility.Collapsed;
            btn_close.Visibility = Visibility.Visible;
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            btn_close.Visibility = Visibility.Collapsed;
            btn_open.Visibility = Visibility.Visible;
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!btn_open.IsVisible)
            {
                Tt_user.Visibility = Visibility.Collapsed;
                Tt_category.Visibility = Visibility.Collapsed;
                Tt_product.Visibility = Visibility.Collapsed;
                Tt_calendar.Visibility = Visibility.Collapsed;
                Tt_store.Visibility = Visibility.Collapsed;

            }
            else
            {
                Tt_user.Visibility = Visibility.Visible;
                Tt_category.Visibility = Visibility.Visible;
                Tt_product.Visibility = Visibility.Visible;
                Tt_calendar.Visibility = Visibility.Visible;
                Tt_store.Visibility = Visibility.Visible;

            }


        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show((sender as ListViewItem).Name.ToString());
            //ListViewItem btn = sender as ListViewItem;
            Page x = null;

            if (btn_usr.IsSelected) x = new UserPage();
            if (btn_cat.IsSelected) x = new CategoryPage();
            if (btn_prd.IsSelected) x = new ProductPage();
            if (btn_cal.IsSelected) x = new CalendarPage();
            if (btn_str.IsSelected) x = new StorePage();


            subWin.Content = x;
        }

        private void UserName_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = BllUser.Search(MainWindow.LogUserID);
            UserName.Text=dt.Rows[0]["First_Name"].ToString();
               
        }


        private void closeAll_Click(object sender, RoutedEventArgs e)
        {
            Window l = new MainWindow();
            l.Show();
            this.Close();
            
        }
    }
}
