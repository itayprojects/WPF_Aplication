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
    public class DAL_Product : IDAL_Product
    {
        static string MyConnString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ConnectionString;

        public bool Add(Product NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "INSERT INTO Product (Name, Category, Description, Price, Quantity, Added_Date, Added_By) VALUES (@Name, @Category, @Description, @Price, @Quantity, @Added_Date, @Added_By)";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Name", NewUser.Name);
                cmd.Parameters.AddWithValue("@Category", NewUser.Category);
                cmd.Parameters.AddWithValue("@Description", NewUser.Description);
                cmd.Parameters.AddWithValue("@Price", NewUser.Price);
                cmd.Parameters.AddWithValue("@Quantity", NewUser.Quantity);
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

        public bool Delete(Product NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "DELETE FROM Product WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewUser.ProductID);

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
                string command = "SELECT * FROM Product WHERE Id LIKE '%" + KeyWord + "%' OR Name LIKE '%" + KeyWord + "%' OR Category LIKE '%" + KeyWord + "%'";
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

        public DataTable SearcProduct(string KeyWord)
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT Id, Name, Price, Quantity FROM Product WHERE Id LIKE '%" + KeyWord + "%' OR Name LIKE '%" + KeyWord + "%' OR Category LIKE '%" + KeyWord + "%'";
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
                string command = "SELECT * FROM Product";
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

        public DataTable SelectProduct()
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT Id, Name, Price, Quantity FROM Product";
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

        public bool Update(Product NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "UPDATE Product SET Name=@Name, Category=@Category, Description=@Description, Price=@Price, Quantity=@Quantity, Added_Date=@Added_Date, Added_By=@Added_By WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Id", NewUser.ProductID);
                cmd.Parameters.AddWithValue("@Name", NewUser.Name);
                cmd.Parameters.AddWithValue("@Category", NewUser.Category);
                cmd.Parameters.AddWithValue("@Description", NewUser.Description);
                cmd.Parameters.AddWithValue("@Price", NewUser.Price);
                cmd.Parameters.AddWithValue("@Quantity", NewUser.Quantity);
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
