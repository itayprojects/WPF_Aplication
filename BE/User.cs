using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static BE.ProjectEnums;

namespace BE
{
    public class User : IDataErrorInfo
    {
        

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string address { get; set; }
        public UserType User_Type { get; set; }
        public DateTime AddDate { get; set; }
        public int AddBy { get; set; }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                //string pattern = @"^[A-Za-z]+[\s][A-Za-z]+[.][A-Za-z]+$";
                //Regex no = new Regex(pattern);
                if(columnName== "FirstName")
                {
                    if (string.IsNullOrEmpty(FirstName))
                    {
                        result = "Please enter a First Name";
                    }
                    else if(!Regex.IsMatch(FirstName, @"^[A-Za-z]{2,19}$"))
                    {
                        result = "not valide First Name";
                    }
                }
                if (columnName == "LasttName")
                {
                    if (string.IsNullOrEmpty(LasttName))
                    {
                        result = "Please enter a Last Name";
                    }
                    else if (!Regex.IsMatch(LasttName, @"^[\p{L}\p{M}' \.\-]+$"))
                    {
                        result = "not valide Last Name";
                    }
                }
                return result;
            }
        }
        
    }
}
