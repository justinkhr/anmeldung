using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anmeldung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bu_verbinden_Click(object sender, EventArgs e)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            databaseConnection.Connect();
            databaseConnection.FillList(lb_lehrer);
        }
    }
}
