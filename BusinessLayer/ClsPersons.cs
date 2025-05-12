using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CLsPesrons
    {

       public enum EnMode { addnew=0,update=1}
      public  EnMode Mode = EnMode.addnew;
        int personID { set; get; }
        string FirstName { set; get; }
        string SecondName { set; get; }
        string NationID { set; get; }
        DateTime DateOFBirth { set; get; }
        string Email { set; get; }
        string Phone { set; get; }
        string Address { set; get; }
        string ImagePath { set; get; }
        int Gendor { set; get; }
        int CountryID { set; get; }
        clsCountrys CountryInfo;

       public CLsPesrons()
        {
            this.personID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.NationID = "";
            this.DateOFBirth = DateTime.Now;
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.ImagePath = "";
            this.Gendor = -1;
            this.CountryID = -1;
        } 

    private CLsPesrons(int personID,string firstname,string secondname,string nationalno,DateTime dateofbrith,string email,
        string phone,string address,string Imagepath,int gendor,int countryid)
        {
            this.personID = personID;
            this.FirstName = firstname;
            this.SecondName = secondname;
            this.NationID = nationalno;
            this.DateOFBirth = dateofbrith;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
            this.ImagePath = Imagepath;
            this.Gendor = gendor;
            this.CountryID = countryid;
            this.CountryInfo = clsCountrys.Find(countryid);
        }



        private bool _AddnewPerson()
        {
            this.personID = ClsPersonData.AddNewPerson(this.FirstName, this.SecondName, this.NationID, this.DateOFBirth,
                this.Email, this.Phone, this.Address, this.ImagePath, this.Gendor, this.CountryID);
            return (this.personID != -1);
        }












        public bool Save()
        {
            switch (Mode)
            {
                case EnMode.addnew:
                    if (_AddnewPerson())
                    {
                        Mode = EnMode.update;
                        return true;
                    }

                    else
                        return false;
            }

            return false;
        }








    }
}
