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
    public class DAL_Category : IDAL_Category
    {
        static string MyConnString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ConnectionString;

        public bool Add(Category NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "INSERT INTO Categories (Title, Description, Added_Date, Added_By) VALUES (@Title, @Description, @Added_Date, @Added_By)";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Title", NewUser.Title);
                cmd.Parameters.AddWithValue("@Description", NewUser.Description);
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

        public bool Delete(Category NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "DELETE FROM Categories WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewUser.CategoryID);

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

        public DataTable Search(string KeyWord)
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT * FROM Categories WHERE Id LIKE '%" + KeyWord + "%' OR Title LIKE '%" + KeyWord + "%' OR Description LIKE '%" + KeyWord +  "%'";
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

        public DataTable Select()
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT * FROM Categories";
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

        public bool Update(Category NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "UPDATE Categories SET Title=@Title, Description=@Description, Added_Date=@Added_Date, Added_By=@Added_By WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewUser.CategoryID);
                cmd.Parameters.AddWithValue("@Title", NewUser.Title);
                cmd.Parameters.AddWithValue("@Description", NewUser.Description);
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
    }
}
