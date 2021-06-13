using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL_PurchaseSummary
    {
        DataTable Select();
        bool Add(PurchaseSummary NewUser);
        bool Delete(PurchaseSummary NewUser);
        bool DeleteByDate(int id, DateTime date);
        bool Update(PurchaseSummary NewUser);
        DataTable Search(string KeyWord);
        DataTable SearchByDate(int id,DateTime date);
    }
}
