using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        public static IDAL_User GetDalUser()
        {
            return new DAL_User();
        }

        public static IDAL_Category GetDalCategory()
        {
            return new DAL_Category();
        }

        public static IDAL_Product GetDalProduct()
        {
            return new DAL_Product();
        }

        public static IDAL_PurchaseSummary GetDalPurchaseSummary()
        {
            return new DAL_PurchaseSummary();
        }
    }
}
