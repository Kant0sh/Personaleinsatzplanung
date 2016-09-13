using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Personaleinsatzplanung.SQL
{
    public class MySQLHandler : ISqlHandler
    {

        public string ConnectionString
        {
            get
            {
                return "server=" + Server + ";uid=" + UserId + ";pwd=" + Password + ";database=" + Database + ";";
            }
        }

        string _server;
        public string Server
        {
            get
            {
                return _server;
            }

            set
            {
                _server = value;
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

        public string Driver { get; set; }

        public string Host { get; set; }

        public string Service { get; set; }

        public MySQLHandler(string server, string userId, string password, string database)
        {
            Server = server;
            UserId = userId;
            Password = password;
            Database = database;
        }

        public async Task<MySqlConnection> ConnectAsync()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(ConnectionString);
                await connection.OpenAsync();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return connection;
        }

        #region Interface Methods

        public async Task<SqlDataSet> SelectAsync(string Table, string Fields)
        {
            return await GetDataAsync(MySqlCommands.Select, Fields, Table);
        }

        public async Task<SqlDataSet> SelectAllAsync(string Table)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandType = CommandType.TableDirect;
            MySqlConnection connection = await ConnectAsync();
            command.Connection = connection;
            return await SqlDataSet.FromMySqlDataReaderAsync(await RunCommandAsync(connection, command));
        }

        public async Task<SqlDataSet> SelectAllWhereAsync(string Table, string Where)
        {
            return await GetDataAsync(MySqlCommands.SelectWhere, SqlUtility.All, Table, Where);
        }

        public async Task<SqlDataSet> SelectWhereAsync(string Table, string Fields, string Where)
        {
            return await GetDataAsync(MySqlCommands.SelectWhere, Fields, Table, Where);
        }

        public async Task<SqlDataSet> SelectOrderByAsync(string Table, string Fields, string OrderBy)
        {
            return await GetDataAsync(MySqlCommands.SelectOrderBy, Fields, Table, OrderBy);
        }

        public async Task<SqlDataSet> SelectWhereOrderByAsync(string Table, string Fields, string Where, string OrderBy)
        {
            return await GetDataAsync(MySqlCommands.SelectWhereOrderBy, Fields, Table, Where, OrderBy);
        }

        public async Task<SqlDataSet> SelectAllOrderByAsync(string Table, string OrderBy)
        {
            return await GetDataAsync(MySqlCommands.SelectOrderBy, SqlUtility.All, Table, OrderBy);
        }

        public async Task<SqlDataSet> SelectAllWhereOrderByAsync(string Table, string Where, string OrderBy)
        {
            return await GetDataAsync(MySqlCommands.SelectWhereOrderBy, SqlUtility.All, Table, Where, OrderBy);
        }

        public async Task<SqlDataSet> SelectOrderByLimitAsync(string Table, string Fields, string OrderBy, string Limit)
        {
            return await GetDataAsync(MySqlCommands.SelectOrderByLimit, Fields, Table, OrderBy, Limit);
        }

        public async Task<SqlDataSet> SelectWhereOrderByLimitAsync(string Table, string Fields, string Where, string OrderBy, string Limit)
        {
            return await GetDataAsync(MySqlCommands.SelectWhereOrderByLimit, Fields, Table, Where, OrderBy, Limit);
        }

        public async Task<int> SelectHighestAsync(string Table, string Field)
        {
            object obj = (await SelectOrderByLimitAsync(Table, Field, Field + " DESC", "1")).Data[0][0];
            if (obj != null && obj is int) return (int)obj;
            return -1;
        }

        public async Task<int> InsertAsync(string Table, string Fields, params object[] Values)
        {
            return await CreateAndRunInsertAsync(Values, Table, Fields);
        }

        public async Task<int> DeleteAsync(string Table, string Where)
        {
            return await CreateAndRunDeleteAsync(Table, Where);
        }

        public async Task<int> UpdateAsync(string Table, string Fields, string Where, params object[] Values)
        {
            return await CreateAndRunUpdateAsync(Table, Where, SqlUtility.ToArrayFromCommas(Fields), Values);
        }

        #endregion

        public async Task<ConnectedMySqlDataReader> RunCommandAsync(MySqlConnection connection, MySqlCommand command)
        {
            return new ConnectedMySqlDataReader(connection, await command.ExecuteReaderAsync() as MySqlDataReader);
        }

        public async Task<ConnectedMySqlDataReader> CreateAndRunCommandAsync(string command, params string[] args)
        {
            MySqlConnection connection = await ConnectAsync();
            return await RunCommandAsync(connection, MySqlCommands.CreateCommand(connection, command, args));
        }

        public async Task<int> CreateAndRunInsertAsync(object[] values, string table, string fields)
        {
            return await MySqlCommands.CreateInsert(await ConnectAsync(), table, fields, values).ExecuteNonQueryAsync();
        }

        public async Task<int> CreateAndRunDeleteAsync(string table, string where)
        {
            return await MySqlCommands.CreateDelete(await ConnectAsync(), table, where).ExecuteNonQueryAsync();
        }

        public async Task<int> CreateAndRunUpdateAsync(string table, string where, string[] fields, params object[] values)
        {
            return await MySqlCommands.CreateUpdate(await ConnectAsync(), table, where, fields, values).ExecuteNonQueryAsync();
        }

        public async Task<SqlDataSet> GetDataAsync(string command, params string[] args)
        {
            return await SqlDataSet.FromMySqlDataReaderAsync(await CreateAndRunCommandAsync(command, args));
        }
    }

    public class MySqlCommands : SqlCommands
    {
        public static MySqlCommand CreateCommand(MySqlConnection connection, string command, params string[] args)
        {
            MySqlCommand comm = new MySqlCommand(string.Format(command, args));
            comm.Connection = connection;
            return comm;
        }

        public static MySqlCommand CreateInsert(MySqlConnection connection, string table, string fields, params object[] args)
        {
            string[] tmpValueDefinitions = fields.Split(',');
            string[] valueDefinitions = new string[tmpValueDefinitions.Length];
            for (int i = 0; i < tmpValueDefinitions.Length; i++)
            {
                valueDefinitions[i] = "?" + tmpValueDefinitions[i].Trim();
            }
            string valDefString = string.Empty;
            foreach(string s in valueDefinitions)
            {
                valDefString += s + ", ";
            }
            valDefString = valDefString.Substring(0, valDefString.Length - 2);
            List<object> argList = args.ToList();
            MySqlCommand comm = new MySqlCommand(string.Format(Insert, table, fields, valDefString));
            for(int i = 0; i < argList.Count; i++)
            {
                MySqlDbType type = MySqlDbType.VarChar;
                object o = argList[i];
                if (o is string) type = MySqlDbType.VarChar;
                else if (o is int) type = MySqlDbType.Int32;
                else if (o is TimeSpan) type = MySqlDbType.Time;
                else if (o is DateTime) type = MySqlDbType.DateTime;
                else if (o is bool) type = MySqlDbType.Bit;
                else if (o is decimal) type = MySqlDbType.Decimal;
                comm.Parameters.Add(valueDefinitions[i], type).Value = argList[i];
            }
            comm.Connection = connection;
            return comm;
        }

        public static MySqlCommand CreateDelete(MySqlConnection connection, string table, string where)
        {
            MySqlCommand command = new MySqlCommand(string.Format(Delete, table, where));
            command.Connection = connection;
            return command;
        }

        public static MySqlCommand CreateUpdate(MySqlConnection connection, string table, string where, string[] fields, object[] values)
        {
            MySqlCommand command = new MySqlCommand(string.Format(Update, table, SqlUtility.GenerateSets(fields), where));
            for(int i = 0; i < fields.Length; i++)
            {
                MySqlDbType type = MySqlDbType.VarChar;
                object o = values[i];
                if (o is string) type = MySqlDbType.VarChar;
                else if (o is int) type = MySqlDbType.Int32;
                else if (o is TimeSpan) type = MySqlDbType.Time;
                else if (o is DateTime) type = MySqlDbType.DateTime;
                else if (o is bool) type = MySqlDbType.Bit;
                else if (o is decimal) type = MySqlDbType.Decimal;
                command.Parameters.Add("?" + fields[i], type).Value = values[i];
            }
            command.Connection = connection;
            Console.WriteLine(command.CommandText);
            return command;
        }
    }
}
