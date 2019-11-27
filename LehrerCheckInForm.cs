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
    public partial class LehrerCheckInForm : Form
    {
        LehrerCheckInDatabaseConnection databaseConnection;
        Form form2;
        string listBoxValue;
        public LehrerCheckInForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            databaseConnection = new LehrerCheckInDatabaseConnection();
            databaseConnection.Connect();
            databaseConnection.FillList(lb_lehrer);
        }
        public void Bu_verbinden_Click(object sender, EventArgs e)
        {
            listBoxValue = lb_lehrer.GetItemText(lb_lehrer.SelectedItem);
            databaseConnection.UpdateVerfügbar(listBoxValue);
            this.Visible = false;
            CreateConnectedForm();
        }
        public void CreateConnectedForm()
        {
            form2 = new Form();
            Label message = new Label();
            Button buttonTrennen = new Button();

            form2.Text = "Verbunden";
            form2.Size = new Size(300, 150);

            message.Text = "Sie sind jetzt Verbunden!";
            message.AutoSize = true;
            message.Location = new Point(80, 20);
            form2.Controls.Add(message);

            buttonTrennen.Text = "Trennen";
            buttonTrennen.Location = new Point(100, 50);
            buttonTrennen.AutoSize = true;
            form2.Controls.Add(buttonTrennen);

            buttonTrennen.Click += new System.EventHandler(ButtonTrennen_click);
            form2.Show();
        }
        public void ButtonTrennen_click(object sender, EventArgs e)
        {
            databaseConnection.UpdateNichtVerfügbar(listBoxValue);
            form2.Close();
            this.Visible = true;
        }
        private void bu_beenden_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
