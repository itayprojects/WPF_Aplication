using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_PurchaseSummary : IBLL_PurchaseSummary
    {
        IDAL_PurchaseSummary newPurchaseSummary;

        public BLL_PurchaseSummary()
        {
            newPurchaseSummary = FactoryDal.GetDalPurchaseSummary();
        }

        public bool Add(PurchaseSummary NewUser)
        {
            return newPurchaseSummary.Add(NewUser);
        }

        public bool Delete(PurchaseSummary NewUser)
        {
            return newPurchaseSummary.Delete(NewUser);
        }

        public bool DeleteByDate(int id, DateTime date)
        {
            return newPurchaseSummary.DeleteByDate(id, date);
        }

        public DataTable Search(string KeyWord)
        {
            return newPurchaseSummary.Search(KeyWord);
        }

        public DataTable SearchByDate(int id, DateTime date)
        {
            return newPurchaseSummary.SearchByDate(id,date);
        }

        public DataTable Select()
        {
            return newPurchaseSummary.Select();
        }

        public bool Update(PurchaseSummary NewUser)
        {
            return newPurchaseSummary.Update(NewUser);
        }
    }
}
