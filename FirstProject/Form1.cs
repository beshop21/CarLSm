using BusinessLayer;
using FirstProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProject
{
    public partial class FrmAddUpdate: Form
    {
        public enum EnMode { addnew=0,update=1}
        private EnMode _Mode;


        private int _personID=-1;

        CLsPesrons _personINfo;



        public FrmAddUpdate()
        {
            InitializeComponent();
            _Mode = EnMode.addnew;

        }
        public FrmAddUpdate(int personID)
        {
            InitializeComponent();
            _personID = personID;
            _Mode = EnMode.addnew;

        }

        private void _RestDefultValue()
        {
            _FillAllCountrys();

            if (_Mode == EnMode.addnew)
            {
                lblTitle.Text = "Addnew Person";
                _personINfo = new CLsPesrons();         
                    
                    
             }
            else
            {
                lblTitle.Text = "Update Person";
            }

            if (rbMale.Checked)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
            else
                pbPersonImage.Image = Resources.Woman_32;


            //IF User not have profil picture Hide Remove labe
            llRemoveImage.Visible = (pbPersonImage.Image != null);

            //we set the max date to 18 years from today, and set the default value the same.
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void _FillAllCountrys()
        {
            DataTable dt = clsCountrys.GetCountrys();
            foreach(DataRow mydata in dt.Rows)
            {
                cbCountry.Items.Add(mydata["CountryName"]);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _RestDefultValue();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int NationalCountryID = clsCountrys.Find(cbCountry.Text).ID;

            _personINfo.FirstName = txtFirstName.Text;
            _personINfo.SecondName = txtSecondName.Text;
            _personINfo.NationID = txtNationalNo.Text;
            _personINfo.DateOFBirth = dtpDateOfBirth.Value;
            _personINfo.Email = txtEmail.Text;
            _personINfo.Phone = txtPhone.Text;
            _personINfo.Address = txtAddress.Text;

            if (pbPersonImage.ImageLocation != null)
            {
                _personINfo.ImagePath = pbPersonImage.ImageLocation;
            }

            else
                _personINfo.ImagePath = "";

            if (rbMale.Checked)
            {
                _personINfo.Gendor = 0;
            }
            else
                _personINfo.Gendor = 1;

            _personINfo.CountryID = NationalCountryID;

            if (_personINfo.Save())
            {
                lblPersonID.Text = _personINfo.personID.ToString();
                _Mode = EnMode.update;
                lblTitle.Text = "Update Person";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
