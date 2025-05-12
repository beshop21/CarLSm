using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
  public class CountryData
    {
        public static bool GetCOuntryID(int CountryID, ref string CountryName)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from Countrys where CountryID=@CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                isfound = true;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CountryName = (string)reader["CountryName"];
                }


                reader.Close();
            }catch(Exception ex)
            {
                isfound = false;
            }
            finally
            {
                connection.Close();
            }
            return isfound;
        }


        public static bool GetCountryName(ref int CountryID,  string CountryName)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from Countrys where CountryName=@CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                isfound = true;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CountryID = (int)reader["CountryID"];
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                isfound = false;
            }
            finally
            {
                connection.Close();
            }
            return isfound;
        }

        public static DataTable GetAllCountrys()
        {
            DataTable tb = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from Countrys";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    tb.Load(reader);
                }

                reader.Close();
            }catch(Exception ex)
            {

            }
            finally { connection.Close(); }
            return tb;
        }

    }
}
