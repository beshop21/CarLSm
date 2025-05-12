using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer;

namespace BusinessLayer
{
 public   class clsCountrys
    {

    public    int ID { set; get; }
     public   string CountryName { set; get; }

        public clsCountrys()
        {
            this.ID = -1;
            this.CountryName = "";

        }

        private clsCountrys(int id,string Countryname)
        {
            this.ID = id;
            this.CountryName = CountryName;
        }
        public static clsCountrys Find(int ID)
        {
            string CountryName = "";
            if (CountryData.GetCOuntryID(ID, ref CountryName))
                return new clsCountrys(ID, CountryName);
            else
                return null;
        }

        public static clsCountrys Find(string CountryName)
        {
            int personID = -1;
            if (CountryData.GetCountryName(ref personID, CountryName))
                return new clsCountrys(personID, CountryName);
            else
                return null;
        }

        public static DataTable GetCountrys()
        {
            return CountryData.GetAllCountrys();
        }
    }
}
