using System;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Anmeldung
{
    class LehrerCheckInDatabaseConnection
    {
        private MySqlConnection _connection;
        private MySqlCommand _command;
        StringBuilder _connectionString = new StringBuilder();
        public LehrerCheckInDatabaseConnection()
        {
            _connectionString.Append("SERVER=localhost;");
            _connectionString.Append("PORT=3306;");
            _connectionString.Append("DATABASE=anmeldung;");
            _connectionString.Append("UID=root;");
            if (!File.Exists("config.ini"))
            {
                File.Create("config.ini");
                File.AppendAllText("config.ini", _connectionString.ToString());
            }
            else
            {
                File.AppendAllText("config.ini", _connectionString.ToString());
            }
        }
        public MySqlConnection Conn
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }
        public MySqlCommand Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
            }
        }
        public void Connect()
        {
            _connection = new MySqlConnection(_connectionString.ToString());
            try
            {
                _connection.Open();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        public void FillList(ListBox lb)
        {
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT LehrerName FROM lehrer", _connection))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach(DataRow row in dataTable.Rows)
                {
                    lb.Items.Add(row["LehrerName"]);
                }
            }
        }
        public void UpdateVerfügbar(string lehrerID)
        {
            MySqlCommand command = new MySqlCommand("UPDATE lehrer SET Verfügbar = TRUE WHERE LehrerID = '" + lehrerID.Substring(0,3) + "'", _connection);
            command.ExecuteNonQuery();
        }
        public void UpdateNichtVerfügbar(string lehrerID)
        {
            MySqlCommand command = new MySqlCommand("UPDATE lehrer SET Verfügbar = FALSE WHERE LehrerID = '" + lehrerID.Substring(0, 3) + "'", _connection);
            command.ExecuteNonQuery();
        }
    }
}