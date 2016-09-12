using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.SQL
{
    class InformixOdbcHandler : ISqlHandler
    {
        public string ConnectionString
        {
            get
            {
                return Driver + ";" + Database + ";" + ServerUrl + ";" + Host + ";" + UserId + ";" + Password + ";";
            }
        }

        string _serverUrl;
        public string ServerUrl
        {
            get
            {
                return _serverUrl;
            }

            set
            {
                _serverUrl = value;
            }
        }

        string _userId;
        public string UserId
        {
            get
            {
                return _userId;
            }

            set
            {
                _userId = value;
            }
        }

        string _password;
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        string _database;
        public string Database
        {
            get
            {
                return _database;
            }

            set
            {
                _database = value;
            }
        }

        string _driver;
        public string Driver
        {
            get
            {
                return _driver;
            }

            set
            {
                _driver = value;
            }
        }

        string _host;
        public string Host
        {
            get
            {
                return _host;
            }

            set
            {
                _host = value; 
            }
        }

        public Task<int> DeleteAsync(string Table, string Where)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(string Table, string Fields, params object[] Values)
        {
            throw new NotImplementedException();
        }

        public Task<SqlDataSet> SelectAllAsync(string Table)
        {
            throw new NotImplementedException();
        }

        public Task<SqlDataSet> SelectAllOrderByAsync(string Table, string OrderBy)
        {
            throw new NotImplementedException();
        }

        public Task<SqlDataSet> SelectAllWhereAsync(string Table, string Where)
        {
            throw new NotImplementedException();
        }

        public Task<SqlDataSet> SelectAllWhereOrderByAsync(string Table, string Where, string OrderBy)
        {
            throw new NotImplementedException();
        }

        public Task<SqlDataSet> SelectAsync(string Table, string Fields)
        {
            throw new NotImplementedException();
        }

        public Task<int> SelectHighestAsync(string Table, string Field)
        {
            throw new NotImplementedException();
        }

        public Task<SqlDataSet> SelectOrderByAsync(string Table, string Fields, string OrderBy)
        {
            throw new NotImplementedException();
        }

        public Task<SqlDataSet> SelectOrderByLimitAsync(string Table, string Fields, string OrderBy, string Limit)
        {
            throw new NotImplementedException();
        }

        public Task<SqlDataSet> SelectWhereAsync(string Table, string Fields, string Where)
        {
            throw new NotImplementedException();
        }

        public Task<SqlDataSet> SelectWhereOrderByAsync(string Table, string Fields, string Where, string OrderBy)
        {
            throw new NotImplementedException();
        }

        public Task<SqlDataSet> SelectWhereOrderByLimitAsync(string Table, string Fields, string Where, string OrderBy, string Limit)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(string Table, string Fields, string Where, params object[] Values)
        {
            throw new NotImplementedException();
        }
    }
}
