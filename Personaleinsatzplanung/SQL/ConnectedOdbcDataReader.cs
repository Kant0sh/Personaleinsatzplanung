using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.SQL
{
    public class ConnectedOdbcDataReader
    {
        OdbcDataReader _reader;
        public OdbcDataReader Reader
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

        OdbcConnection _connection;
        public OdbcConnection Connection
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

        public void Close()
        {
            Reader.Close();
            Connection.Close();
            Connection.Dispose();
        }

        public ConnectedOdbcDataReader(OdbcConnection Connection, OdbcDataReader Reader)
        {
            this.Connection = Connection;
            this.Reader = Reader;
        }
    }
}
