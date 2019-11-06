using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Anmeldung
{
    class Query
    {
        private MySqlCommand _command;
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
        public void FillList()
        {
            _command = new MySqlCommand("SELECT LehrerName FROM lehrer;");
            _command.ExecuteNonQuery();
        }
        public int CountTeachers()
        {
            int counter = 0;
            _command = new MySqlCommand("SELECT COUNT(LehrerID) FROM lehrer;");
            counter = _command.ExecuteNonQuery();
            return counter;
        }
    }
}
