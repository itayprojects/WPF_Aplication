using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL_Product
    {
        DataTable Select();
        DataTable SelectProduct();
        bool Add(Product NewUser);
        bool Delete(Product NewUser);
        bool Update(Product NewUser);
        DataTable Search(string KeyWord);
        DataTable SearcProduct(string KeyWord);
    }
}
