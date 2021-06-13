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
    public class BLL_Category : IBLL_Category
    {
        IDAL_Category newCategory;

        public BLL_Category()
        {
            newCategory = FactoryDal.GetDalCategory();
        }

        public bool Add(Category NewUser)
        {
            return newCategory.Add(NewUser);
        }

        public bool Delete(Category NewUser)
        {
            return newCategory.Delete(NewUser);
        }

        public DataTable Search(string KeyWord)
        {
            return newCategory.Search(KeyWord);
        }

        public DataTable Select()
        {
            return newCategory.Select();
        }

        public bool Update(Category NewUser)
        {
            return newCategory.Update(NewUser);
        }
    }
}
