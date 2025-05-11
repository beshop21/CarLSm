using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer;

namespace BusinessLayer
{
 public   class clsCountrys
    {

        int ID { set; get; }
        string CountryName { set; get; }

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
    }
}
