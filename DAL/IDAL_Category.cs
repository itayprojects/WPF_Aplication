using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL_Category
    {
        DataTable Select();
        bool Add(Category NewUser);
        bool Delete(Category NewUser);
        bool Update(Category NewUser);
        DataTable Search(string KeyWord);
    }
}
