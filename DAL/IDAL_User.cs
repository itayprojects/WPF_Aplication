using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL_User
    {
        DataTable Select();
        DataTable SelectUser();
        bool Add(User NewUser);
        bool Delete(User NewUser);
        bool Update(User NewUser);
        DataTable Search(string KeyWord);
        DataTable SearchUser(string KeyWord);
        DataTable userById(string id);
        bool LoginCheck(User NewUser);
    }
}
