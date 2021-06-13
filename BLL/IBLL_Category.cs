using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLL_Category
    {
        DataTable Select();
        bool Add(Category NewUser);
        bool Delete(Category NewUser);
        bool Update(Category NewUser);
        DataTable Search(string KeyWord);
    }
}
