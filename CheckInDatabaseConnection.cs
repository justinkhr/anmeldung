using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CheckIn
{
    class DatabaseConnection
    {
        private MySqlConnection _connection;
        private MySqlCommand _command;
        StringBuilder _connectionString = new StringBuilder();
        int max = 0;
        public DatabaseConnection()
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
        public int GetLastID()
        {
            _command = new MySqlCommand("SELECT MAX(KarteID) FROM karte ", _connection);
            _command.CommandType = CommandType.Text;
            max = Convert.ToInt32(_command.ExecuteScalar());
            max++;
            return max;  
        }
        public void WriteNewIdInKarte()
        {
            _command = new MySqlCommand("INSERT INTO karte(KarteID) VALUES("+max+")", _connection);
            _command.CommandType = CommandType.Text;
            _command.ExecuteScalar();
        }
        public void WriteNewRecordInKarteBildungsgang(int hh, int gy, int ifk, int ik, int unknown)
        {
            if(hh == 1)
            {
                _command = new MySqlCommand("INSERT INTO karte_bildungsgang(KarteID, BildungsgangID) VALUES(" + max + ", 'HH')", _connection);
                _command.CommandType = CommandType.Text;
                _command.ExecuteScalar();
            }
            if (gy == 1)
            {
                _command = new MySqlCommand("INSERT INTO karte_bildungsgang(KarteID, BildungsgangID) VALUES(" + max + ", 'GY')", _connection);
                _command.CommandType = CommandType.Text;
                _command.ExecuteScalar();
            }
            if (ifk == 1)
            {
                _command = new MySqlCommand("INSERT INTO karte_bildungsgang(KarteID, BildungsgangID) VALUES(" + max + ", 'IFK')", _connection);
                _command.CommandType = CommandType.Text;
                _command.ExecuteScalar();
            }
            if (ik == 1)
            {
                _command = new MySqlCommand("INSERT INTO karte_bildungsgang(KarteID, BildungsgangID) VALUES(" + max + ", 'IK')", _connection);
                _command.CommandType = CommandType.Text;
                _command.ExecuteScalar();
            }
            if (unknown == 1)
            {
                _command = new MySqlCommand("INSERT INTO karte_bildungsgang(KarteID, BildungsgangID) VALUES(" + max + ", 'Unbekannt')", _connection);
                _command.CommandType = CommandType.Text;
                _command.ExecuteScalar();
            }
        }
    }
}
