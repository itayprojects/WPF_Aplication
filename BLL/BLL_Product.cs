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
    public class BLL_Product : IBLL_Product
    {
        IDAL_Product newProduct;

        public BLL_Product()
        {
            newProduct = FactoryDal.GetDalProduct();
        }
        public bool Add(Product NewUser)
        {
            return newProduct.Add(NewUser);
        }

        public bool Delete(Product NewUser)
        {
            return newProduct.Delete(NewUser);
        }

        public DataTable Search(string KeyWord)
        {
            return newProduct.Search(KeyWord);
        }

        public DataTable SearcProduct(string KeyWord)
        {
            return newProduct.SearcProduct(KeyWord);
        }

        public DataTable Select()
        {
            return newProduct.Select();
        }

        public DataTable SelectProduct()
        {
            return newProduct.SelectProduct();
        }

        public bool Update(Product NewUser)
        {
            return newProduct.Update(NewUser);
        }
    }
}
