using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BusinessLayer;

namespace FirstProject
{
    public partial class CTRWithFillter: UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        private int _PerisnID = -1;
        CLsPesrons _person;

        public int personID
        {
            get { return _PerisnID; }
        }

        public CLsPesrons INfoPerson
        {
            get { return _person; }
        }



        public CTRWithFillter()
        {
            InitializeComponent();
        }
        private void FindNow()
        {
            switch(cbFilterBy.Text)
            {
                case "Person ID":
                    ctrPersnInfo1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    break;

                case "National ID":
                    ctrPersnInfo1.LoadPersonInfo(txtFilterValue.Text);
                    break;
                default:
                    break;
            }
        }
        private void CTRWithFillter_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindNow();
        }
    }
}
