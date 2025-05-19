using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using System.Security.Permissions;
using FirstProject.Properties;
using System.IO;

namespace FirstProject
{
    public partial class CTRPersnInfo: UserControl
    {
        private int _personID=-1;
        CLsPesrons _perons;

        public int PersonID
        {
            get { return _personID; }
        }

        public CLsPesrons CLsPersonINfo
        {
            get { return _perons; }
        }
        public CTRPersnInfo()
        {
            InitializeComponent();
          
        }
        public void LoadPersonInfo(int ID)
        {
            _perons = CLsPesrons.Find(ID);
            if (_perons == null)
            {
                MessageBox.Show("This person ID is Not Exist");
            }
            FillPeronsINfo();
        }

        public void LoadPersonInfo(string name)
        {
            _perons = CLsPesrons.Find(name);
            if (_perons == null)
            {
                MessageBox.Show("This person ID is Not Exist");
            }
            FillPeronsINfo();
        }

        private void FillPeronsINfo()
        {
            llEditPersonInfo.Enabled = true;
            _personID = _perons.personID;
            lblPersonID.Text = _perons.personID.ToString();
            lblFullName.Text = _perons.FirstName + " " + _perons.SecondName;
            lblNationalNo.Text = _perons.NationID;
            lblGendor.Text = _perons.Gendor == 0 ? "Male" : "Female";
            lblEmail.Text = _perons.Email;
            lblAddress.Text = _perons.Address;
            lblDateOfBirth.Text = _perons.DateOFBirth.ToShortDateString();
            lblPhone.Text = _perons.Phone;
            lblCountry.Text = clsCountrys.Find(_perons.CountryID).CountryName;

            LoadPersonImage();

        }

        private void LoadPersonImage()
        {
            if (_perons.Gendor == 0)

                pbGendor.Image = Resources.Male_512;
            else
                pbGendor.Image = Resources.Female_512;

            string imagePath = _perons.ImagePath;
            if (imagePath != null)
            {
                if (File.Exists(imagePath))
                    pbPersonImage.ImageLocation = imagePath;
            }
            else
                MessageBox.Show("This Image Is not in the Files Please Check ");
        }

        public void DefulltSetting()
        {
            _personID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            pbGendor.Image = Resources.Man_32;
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
