using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LV_Example
{
    public partial class AddPerson : Form
    {
        public AddPerson()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0 && txtPhone.Text.Length > 0 && txtAge.Text.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Bad Results!");
            }
        }

        public int Age
        {
            get
            {
                return Convert.ToInt32(txtAge.Text);
            }
        }

        //We can't use the Name property because it masks a property from the parent object (Form)
        public string Bob
        {
            get
            {
                return txtName.Text;
            }
        }
        public string Phone
        {
            get
            {
                return txtPhone.Text;
            }
        }

        public int ImageIndex
        {
            set
            {
                //cmbImageIndex.Text = value.ToString();
                cmbImageIndex.SelectedIndex = value;
            }
            get
            {
                return Convert.ToInt32(cmbImageIndex.Text);
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }
    }
}
