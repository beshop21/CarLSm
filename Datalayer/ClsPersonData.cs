﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class ClsPersonData
    {

        public static bool GetPersonInfoByPersonID(int PersonID,ref string firstName,ref string SecondName,ref string NationalNo,ref DateTime DateOFBirth,
            ref string Email,ref string Phone,ref string Address,ref string ImagePath,ref int Gendor,ref int CountryiD)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    
                    firstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    NationalNo = (string)reader["NationalID"];


                    DateOFBirth = (DateTime)reader["DataOfBrith"];
                    Email = (string)reader["Email"];
                   
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Addres"];
                    //Email: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }



                    Gendor = (int)reader["Gendor"];

                    CountryiD = (int)reader["CountryNameID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetPersonInfoByPersonNationa(string NationalNo, ref int PersonID, ref string firstName, ref string SecondName, ref DateTime DateOFBirth,
           ref string Email, ref string Phone, ref string Address, ref string ImagePath, ref int Gendor, ref int CountryiD)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from People where nationalID=@nationalID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("nationalID", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    firstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                 

                    DateOFBirth = (DateTime)reader["DataOFBrith"];
                    Email = (string)reader["Email"];

                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Addres"];
                    //Email: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }



                    Gendor = (int)reader["Gendor"];

                    CountryiD = (int)reader["CountryNameID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static int AddNewPerson(string FirstName, string SecondName,string NationalID,DateTime DateOFBirth,string Email,
            string Phone,string Address,string ImagePath,int Gendor,int CountryID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People (FirstName, SecondName, NationalID,DataOFBrith,Email,Phone,Addres,ImagePath,Gendor,CountryNameID)
                             VALUES (@FirstName,@SecondName,@NationalID,@DataOFBrith,@Email,@Phone,@Addres,@ImagePath,@Gendor,@CountryNameID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@NationalID", NationalID);
            command.Parameters.AddWithValue("@DataOFBrith", DateOFBirth);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Addres", Address);


            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            command.Parameters.AddWithValue("@Gendor", Gendor);


            command.Parameters.AddWithValue("CountryNameID",CountryID);

           
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return PersonID;
        }


        public static bool UpdatePerson(int personID,string FirstName, string SecondName, string NationalID, DateTime DateOFBirth, string Email,
            string Phone, string Address, string ImagePath, int Gendor, int CountryID)
        {

            int NumberEffet = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"update People set FirstName=@Firstname
                                              SecondName=@SecondName
                                              NationalID=@NationalID
                                              DataOFBrith=@DataOFBrith
                                              Email=@Email
                                              Phone=@Phone
                                              Addres=@Addres
                                              ImagePath=@ImagePath
                                              Gendor=@Gendor
                                              CountryNameID=@CountryNameID
                                             where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@NationalID", NationalID);
            command.Parameters.AddWithValue("@DataOFBrith", DateOFBirth);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Addres", Address);


            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            command.Parameters.AddWithValue("@Gendor", Gendor);


            command.Parameters.AddWithValue("CountryNameID", CountryID);

            try
            {

                connection.Open();
                NumberEffet = command.ExecuteNonQuery();






            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (NumberEffet > 0);
        }






    }
}
