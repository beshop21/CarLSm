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
    public    int personID { set; get; }
    public    string FirstName { set; get; }
     public   string SecondName { set; get; }
     public   string NationID { set; get; }
   public     DateTime DateOFBirth { set; get; }
     public   string Email { set; get; }
   public     string Phone { set; get; }
    public    string Address { set; get; }
  public      string ImagePath { set; get; }
    public    int Gendor { set; get; }
    public    int CountryID { set; get; }
   public     clsCountrys CountryInfo;

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



        public static CLsPesrons Find(int ID)
        {
            string Firstname = "", SecondNamae = "", NationID = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOFbrith = DateTime.Now;
            int CountryID = -1;
            int Gendor = -1;
            if (ClsPersonData.GetPersonInfoByPersonID(ID, ref Firstname, ref SecondNamae, ref NationID, ref DateOFbrith, ref Email
                 , ref Phone, ref Address, ref ImagePath, ref Gendor, ref CountryID))
                return new CLsPesrons(ID, Firstname, SecondNamae, NationID, DateOFbrith, Email, Phone, Address, ImagePath, Gendor, CountryID);
            else
                return null;
        }
        public static CLsPesrons Find(string name)
        {
            int personID = -1;
            string Firstname = "", SecondNamae = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOFbrith = DateTime.Now;
            int CountryID = -1;
            int Gendor = -1;
            if (ClsPersonData.GetPersonInfoByPersonNationa(name, ref personID, ref Firstname, ref SecondNamae, ref DateOFbrith,
                 ref Email, ref Phone, ref Address, ref ImagePath, ref Gendor, ref CountryID))
                return new CLsPesrons(personID, Firstname, SecondNamae, name, DateOFbrith, Email, Phone, Address, ImagePath, Gendor, CountryID);
            else
                return null;
        }

        private bool _UpdatePerson()
        {
            return ClsPersonData.UpdatePerson(this.personID, this.FirstName, this.SecondName, this.NationID, this.DateOFBirth,
             this.Email, this.Phone, this.Address, this.ImagePath, this.Gendor, this.CountryID);
            
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

                case EnMode.update:
                    return _UpdatePerson();
            }

            return false;
        }








    }
}
