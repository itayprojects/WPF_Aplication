using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_User : IDAL_User
    {
        static string MyConnString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ConnectionString;

        #region SelectUser
        public DataTable Select()
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(command, connect);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
            }
            return dt;

        }
        #endregion

        #region AddUser
        public bool Add(User NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "INSERT INTO Users (First_Name, Last_Name, Email, Password, Phone, Address, user_type, Added_Date, Added_By) VALUES (@First_Name, @Last_Name, @Email, @Password, @Phone, @Address, @user_type, @Added_Date, @Added_By)";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@First_Name", NewUser.FirstName);
                cmd.Parameters.AddWithValue("@Last_Name", NewUser.LasttName);
                cmd.Parameters.AddWithValue("@Email", NewUser.Email);
                cmd.Parameters.AddWithValue("@Password", NewUser.Password);
                cmd.Parameters.AddWithValue("@Phone", NewUser.Phone);
                cmd.Parameters.AddWithValue("@Address", NewUser.address);
                cmd.Parameters.AddWithValue("@user_type", NewUser.User_Type);
                cmd.Parameters.AddWithValue("@Added_Date", NewUser.AddDate);
                cmd.Parameters.AddWithValue("@Added_By", NewUser.AddBy);

                connect.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    AddSuccess = true;
                }
                else
                {
                    AddSuccess = false;
                }
            }
            catch (Exception)
            {

                throw new Exception("dsd");
            }
            finally
            {
                connect.Close();
            }
            return AddSuccess;
        }
        #endregion

        #region DeleteUser
        public bool Delete(User NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "DELETE FROM Users WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewUser.UserID);

                connect.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    AddSuccess = true;
                }
                else
                {
                    AddSuccess = false;
                }
            }
            catch (Exception)
            {

                throw new Exception("dsd");
            }
            finally
            {
                connect.Close();
            }
            return AddSuccess;
        }

        #endregion

        #region Update User
        public bool Update(User NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "UPDATE Users SET First_Name=@First_Name, Last_Name=@Last_Name, Email=@Email, Password=@Password, Phone=@Phone, Address=@Address, user_type=@user_type, Added_Date=@Added_Date, Added_By=@Added_By WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewUser.UserID);
                cmd.Parameters.AddWithValue("@First_Name", NewUser.FirstName);
                cmd.Parameters.AddWithValue("@Last_Name", NewUser.LasttName);
                cmd.Parameters.AddWithValue("@Email", NewUser.Email);
                cmd.Parameters.AddWithValue("@Password", NewUser.Password);
                cmd.Parameters.AddWithValue("@Phone", NewUser.Phone);
                cmd.Parameters.AddWithValue("@Address", NewUser.address);
                cmd.Parameters.AddWithValue("@user_type", NewUser.User_Type);
                cmd.Parameters.AddWithValue("@Added_Date", NewUser.AddDate);
                cmd.Parameters.AddWithValue("@Added_By", NewUser.AddBy);

                connect.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    AddSuccess = true;
                }
                else
                {
                    AddSuccess = false;
                }
            }
            catch (Exception)
            {

                throw new Exception("dsd");
            }
            finally
            {
                connect.Close();
            }
            return AddSuccess;
        }
        #endregion

        #region Search User
        public DataTable Search(string KeyWord)
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT * FROM Users WHERE Id LIKE '%"+KeyWord+ "%' OR First_Name LIKE '%"+KeyWord+ "%' OR Last_Name LIKE '%"+KeyWord+ "%' OR Email LIKE '%"+KeyWord+"%'";
                SqlCommand cmd = new SqlCommand(command, connect);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
            }
            return dt;
        }
        #endregion

        #region Login User
        public bool LoginCheck(User NewUser)
        {
            bool Success = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "SELECT * FROM Users WHERE Email=@Email AND Password=@Password";
                SqlCommand cmd = new SqlCommand(command, connect);

                
                cmd.Parameters.AddWithValue("@Email", NewUser.Email);
                cmd.Parameters.AddWithValue("@Password", NewUser.Password);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                connect.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Success = true;
                }
                else
                {
                    Success = false;
                }
            }
            catch (Exception)
            {

                throw new Exception("dsd");
            }
            finally
            {
                connect.Close();
            }
            return Success;
        }

        public DataTable SelectUser()
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT Id, First_Name, Last_Name, Email, Phone, Address FROM Users";
                SqlCommand cmd = new SqlCommand(command, connect);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
            }
            return dt;
        }

        public DataTable SearchUser(string KeyWord)
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT Id, First_Name, Last_Name, Email, Phone, Address FROM Users WHERE Id LIKE '%" + KeyWord + "%' OR First_Name LIKE '%" + KeyWord + "%' OR Last_Name LIKE '%" + KeyWord + "%' OR Email LIKE '%" + KeyWord + "%'";
                SqlCommand cmd = new SqlCommand(command, connect);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
            }
            return dt;
        }

        public DataTable userById(string id)
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT * FROM Users WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connect.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
            }
            return dt;
        }
        #endregion
    }
}
