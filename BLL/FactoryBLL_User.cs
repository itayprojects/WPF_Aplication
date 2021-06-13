using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FactoryBLL_User
    {
        static IBLL_User user = null;
        static IBLL_Category category = null;
        static IBLL_Product product = null;
        static IBLL_PurchaseSummary purchaseSummary = null;

        public static IBLL_User GetBllUser()
        {
            user = new BLL_User();
            return user;
        }

        public static IBLL_Category GetBllCategory()
        {
            category = new BLL_Category();
            return category;
        }

        public static IBLL_Product GetBllProduct()
        {
            product = new BLL_Product();
            return product;
        }
        public static IBLL_PurchaseSummary GetBllPurchaseSummary()
        {
            purchaseSummary = new BLL_PurchaseSummary();
            return purchaseSummary;
        }
    }
}
