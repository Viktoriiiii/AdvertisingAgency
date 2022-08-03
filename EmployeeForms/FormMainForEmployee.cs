using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvertisingAgency
{
    public partial class FormMainForEmployee : Form
    {
        public FormMainForEmployee()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Application.OpenForms["FormMainForEmployee"].Close();
            Application.OpenForms[1].Show();
        }
    }
}
