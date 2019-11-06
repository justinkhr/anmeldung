using System;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Anmeldung
{
    class DatabaseConnection
    {
        private MySqlConnection _connection;
        StringBuilder _connectionString = new StringBuilder();
        public DatabaseConnection()
        {
            _connectionString.Append("SERVER=localhost;");
            _connectionString.Append("PORT=3306;");
            _connectionString.Append("DATABASE=anmeldung;");
            _connectionString.Append("UID=root;");
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
    }

}
