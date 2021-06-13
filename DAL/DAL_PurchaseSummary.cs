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
    public class DAL_PurchaseSummary : IDAL_PurchaseSummary
    {
        static string MyConnString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ConnectionString;

        public bool Add(PurchaseSummary NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "INSERT INTO PurchaseSummary (User_Id, Product_Name, Price, Quantity, Total, Added_Date, Added_By, Product_Id) VALUES (@User_Id, @Product_Name, @Price, @Quantity, @Total, @Added_Date, @Added_By, @Product_Id)";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@User_Id", NewUser.User_Id);
                cmd.Parameters.AddWithValue("@Product_Name", NewUser.Product_Name);
                cmd.Parameters.AddWithValue("@Price", NewUser.Price);
                cmd.Parameters.AddWithValue("@Quantity", NewUser.Quantity);
                cmd.Parameters.AddWithValue("@Total", NewUser.Total);
                cmd.Parameters.AddWithValue("@Added_Date", NewUser.Added_Date);
                cmd.Parameters.AddWithValue("@Added_By", NewUser.AddBy);
                cmd.Parameters.AddWithValue("@Product_Id", NewUser.Product_Id);

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

        public bool Delete(PurchaseSummary NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "DELETE FROM PurchaseSummary WHERE Product_Id=@Product_Id";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Product_Id", NewUser.Product_Id);

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

        public bool DeleteByDate(int id, DateTime date)
        {
            bool Success = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "DELETE FROM PurchaseSummary WHERE User_Id=@User_Id AND Added_Date=@Added_Date";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@User_Id", id);
                cmd.Parameters.AddWithValue("@Added_Date", date);

                connect.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
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

        public DataTable Search(string KeyWord)
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT * FROM PurchaseSummary WHERE Product_Id LIKE '%" + KeyWord + "%' OR Product_Name LIKE '%" + KeyWord + "%' OR User_Id LIKE '%" + KeyWord + "%'";
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

        public DataTable SearchByDate(int id, DateTime date)
        {
            SqlConnection connect = new SqlConnection(MyConnString);
            DataTable dt = new DataTable();

            try
            {
                string command = "SELECT * FROM PurchaseSummary WHERE User_Id=@User_Id AND Added_Date=@Added_Date";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@User_Id", id);
                cmd.Parameters.AddWithValue("@Added_Date", date);

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
                string command = "SELECT * FROM PurchaseSummary";
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

        public bool Update(PurchaseSummary NewUser)
        {
            bool AddSuccess = false;
            SqlConnection connect = new SqlConnection(MyConnString);

            try
            {
                string command = "UPDATE PurchaseSummary SET User_Id=@User_Id, Product_Name=@Product_Name, Price=@Price, Quantity=@Quantity, Total=@Total, Added_Date=@Added_Date, Added_By=@Added_By WHERE Product_Id=@Product_Id";
                SqlCommand cmd = new SqlCommand(command, connect);

                cmd.Parameters.AddWithValue("@Product_Id", NewUser.Product_Id);
                cmd.Parameters.AddWithValue("@User_Id", NewUser.User_Id);
                cmd.Parameters.AddWithValue("@Product_Name", NewUser.Product_Name);
                cmd.Parameters.AddWithValue("@Price", NewUser.Price);
                cmd.Parameters.AddWithValue("@Quantity", NewUser.Quantity);
                cmd.Parameters.AddWithValue("@Total", NewUser.Total);
                cmd.Parameters.AddWithValue("@Added_Date", NewUser.Added_Date);
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
