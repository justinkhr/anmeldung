using System;
using System.Windows.Forms;
using System.IO;

namespace CheckIn
{
    public partial class Form1 : Form
    {
        DatabaseConnection databaseConnection;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Stellt die Datenbankverbindung her.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            databaseConnection = new DatabaseConnection();
            databaseConnection.Connect();
            la_number.Text = databaseConnection.GetLastID().ToString();
        }
        #region Button & CheckBox Events
        /// <summary>
        /// Legt fest, was passieren soll, wenn eine CheckBox checked / unchecked wird oder ein Button geklickt wird. 
        /// </summary>
        private void cb_nichtbekannt_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_nichtbekannt.Checked == true)
            {
                cb_gy.Checked = false;
                cb_gy.Enabled = false;
                cb_hh.Checked = false;
                cb_hh.Enabled = false;
                cb_ifk.Checked = false;
                cb_ifk.Enabled = false;
                cb_ik.Checked = false;
                cb_ik.Enabled = false;
                bu_hh.Enabled = false;
                bu_gy.Enabled = false;
                bu_ik.Enabled = false;
                bu_ifk.Enabled = false;
            }
            else
            {
                cb_gy.Enabled = true;
                cb_hh.Enabled = true;
                cb_ifk.Enabled = true;
                cb_ik.Enabled = true;
                bu_hh.Enabled = true;
                bu_gy.Enabled = true;
                bu_ik.Enabled = true;
                bu_ifk.Enabled = true;
            }
        }
        private void bu_hh_Click(object sender, EventArgs e)
        {
            if (cb_hh.Checked == false)
            {
                cb_hh.Checked = true;
            }
            else
            {
                cb_hh.Checked = false;
            }
        }

        private void bu_gy_Click(object sender, EventArgs e)
        {
            if (cb_gy.Checked == false)
            {
                cb_gy.Checked = true;
            }
            else
            {
                cb_gy.Checked = false;
            }
        }

        private void bu_ifk_Click(object sender, EventArgs e)
        {
            if (cb_ifk.Checked == false)
            {
                cb_ifk.Checked = true;
            }
            else
            {
                cb_ifk.Checked = false;
            }
        }

        private void bu_ik_Click(object sender, EventArgs e)
        {
            if (cb_ik.Checked == false)
            {
                cb_ik.Checked = true;
            }
            else
            {
                cb_ik.Checked = false;
            }
        }

        private void bu_nichtbekannt_Click(object sender, EventArgs e)
        {
            if (cb_nichtbekannt.Checked == false)
            {
                cb_nichtbekannt.Checked = true;
            }
            else
            {
                cb_nichtbekannt.Checked = false;
            }
        }
        #endregion

        #region Write Into Database
        /// <summary>
        /// Diese Methode schreibt die KarteID und die ausgewählten Bildungsgänge in die Tabellen karte & karte_bildungsgang.
        /// </summary>
        private void bu_weiter_Click(object sender, EventArgs e)
        {   
            int hh = 0; int gy = 0; int ifk = 0; int ik = 0; int unknown = 0;
            if(cb_gy.Checked == true)
            {
                gy = 1;
            }
            if (cb_hh.Checked == true)
            {
                hh = 1;
            }
            if (cb_ifk.Checked == true)
            {
                ifk = 1;
            }
            if (cb_ik.Checked == true)
            {
                ik = 1;
            }
            if (cb_nichtbekannt.Checked == true)
            {
                unknown = 1;
            }
            if (hh == 0 && gy == 0 && ifk == 0 && ik == 0 && unknown == 0)
            {
                MessageBox.Show("Sie haben keinen Bildungsgang ausgewählt.");
            }
            else
            {
                try
                {
                    databaseConnection.WriteNewIdInKarte();
                    databaseConnection.WriteNewRecordInKarteBildungsgang(hh, gy, ifk, ik, unknown);
                    MessageBox.Show("Daten wurden erfolgreich übermittelt. Bitte warten Sie bis Ihre Nummer aufgerufen wird. Ihre Nummer: " + la_number.Text);
                    Application.Restart();
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Fehler bei der Datenübermittlung \t" + exception.Message);
                }
            }      
        }
        #endregion
    }
}
