using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.SQL
{
    public class ConnectedMySqlDataReader
    {
        MySqlDataReader _reader;
        public MySqlDataReader Reader
        {
            get
            {
                return _reader;
            }
            set
            {
                _reader = value;
            }
        }

        MySqlConnection _connection;
        public MySqlConnection Connection
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

        public async Task CloseAsync()
        {
            Reader.Close();
            await Connection.ClearAllPoolsAsync();
            await Connection.CloseAsync();
        }

        public ConnectedMySqlDataReader(MySqlConnection Connection, MySqlDataReader Reader)
        {
            this.Connection = Connection;
            this.Reader = Reader;
        }
    }
}
