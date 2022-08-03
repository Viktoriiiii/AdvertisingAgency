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
    public partial class FormMainForManager : Form
    {
        public FormMainForManager()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Application.OpenForms["FormMainForManager"].Close();
            Application.OpenForms[1].Show();
        }
    }
}
