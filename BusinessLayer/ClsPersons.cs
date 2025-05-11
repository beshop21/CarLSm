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
        int gendor { set; get; }
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
            this.gendor = -1;
            this.CountryID = -1;
        } 

    }
}
