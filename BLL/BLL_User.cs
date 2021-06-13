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
    public class BLL_User : IBLL_User
    {
        IDAL_User newUser;
        public BLL_User()
        {
            newUser = FactoryDal.GetDalUser();
        }
        public DataTable Select()
        {
            return newUser.Select();
        }
        public bool Add(User UserIn)
        {

            return newUser.Add(UserIn);
        }

        public bool Delete(User UserIn)
        {
            return newUser.Delete(UserIn);
        }

        public bool Update(User UserIn)
        {
            return newUser.Update(UserIn);
        }

        public DataTable Search(string KeyWord)
        {
            return newUser.Search(KeyWord);
        }

        public bool LoginCheck(User UserIn)
        {
            return newUser.LoginCheck(UserIn);
        }

        public DataTable SelectUser()
        {
            return newUser.SelectUser();
        }

        public DataTable SearchUser(string KeyWord)
        {
            return newUser.SearchUser(KeyWord);
        }

        public DataTable userById(string id)
        {
            return newUser.userById(id);
        }
    }
}
