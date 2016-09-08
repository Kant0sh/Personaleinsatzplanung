using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Personaleinsatzplanung.SQL
{
    public class MySQLHandler
    {

        string _serverUrl;
        string _userId;
        string _password;
        string _database;

        public string ConnectionString
        {
            get
            {
                return "server=" + _serverUrl + ";uid=" + _userId + ";pwd=" + _password + ";database=" + _database + ";";
            }
        }

        public MySQLHandler(string serverUrl, string userId, string password, string database)
        {
            _serverUrl = serverUrl;
            _userId = userId;
            _password = password;
            _database = database;
        }

        public MySqlConnection Connect()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(ConnectionString);
                connection.Open();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return connection;
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

        public MySqlDataReader Select(string table, string fields)
        {
            return CreateAndRunCommand(MySQLCommands.Select, fields, table);
        }

        public MySqlDataReader SelectAll(string table)
        {
            MySqlCommand command = new MySqlCommand(table);
            command.Connection = Connect();
            command.CommandType = CommandType.TableDirect;
            return command.ExecuteReader();
        }

        public async Task<MySqlDataReader> SelectAllAsync(string table)
        {
            MySqlCommand command = new MySqlCommand(table);
            command.Connection = await ConnectAsync();
            command.CommandType = CommandType.TableDirect;
            return command.ExecuteReader();
        }

        public MySqlDataReader SelectAllWhere(string table, string where)
        {
            return CreateAndRunCommand(MySQLCommands.SelectWhere, "*", table, where);
        }

        public async Task<MySqlDataReader> SelectAllWhereAsync(string table, string where)
        {
            return await CreateAndRunCommandAsync(MySQLCommands.SelectWhere, "*", table, where);
        }

        public MySqlDataReader SelectWhere(string fields, string table, string where)
        {
            return CreateAndRunCommand(MySQLCommands.SelectWhere, fields, table, where);
        }

        public MySqlDataReader SelectWhereOrderBy(string fields, string table, string where, string orderBy)
        {
            return CreateAndRunCommand(MySQLCommands.SelectWhereOrderBy, fields, table, where, orderBy);
        }

        public MySqlDataReader SelectWhereOrderBy(string fields, string table, string orderBy)
        {
            return CreateAndRunCommand(MySQLCommands.SelectWhereOrderBy, fields, table, orderBy);
        }

        public MySqlDataReader SelectOrderByLimit(string fields, string table, string orderBy, string limit)
        {
            return CreateAndRunCommand(MySQLCommands.SelectOrderByLimit, fields, table, orderBy, limit);
        }

        public MySqlDataReader SelectWhereOrderByLimit(string fields, string table, string where, string orderBy, string limit)
        {
            return CreateAndRunCommand(MySQLCommands.SelectWhereOrderByLimit, fields, where, table, orderBy, limit);
        }

        public int SelectLastInt(string table, string field)
        {
            MySqlDataReader reader = SelectOrderByLimit(field, table, field + " DESC", "1");
            while (reader.Read())
            {
                int i = (int)reader.GetValue(0);
                reader.Close();
                return i;
            }
            return -1;
        }

        public int Insert(string table, string fields, params object[] values)
        {
            return CreateAndRunInsert(values, table, fields);
        }

        public String GetMySQLFormattedTime(TimeSpan ts)
        {
            return ts.ToString();
        }

        public MySqlDataReader RunCommand(MySqlCommand command)
        {
            return command.ExecuteReader();
        }

        public async Task<MySqlDataReader> RunCommandAsync(MySqlCommand command)
        {
            return await command.ExecuteReaderAsync() as MySqlDataReader;
        }

        public int RunInsert(MySqlCommand command)
        {
            return command.ExecuteNonQuery();
        }

        public MySqlDataReader CreateAndRunCommand(string command, params string[] args)
        {
            return RunCommand(MySQLCommands.CreateCommand(Connect(), command, args));
        }

        public async Task<MySqlDataReader> CreateAndRunCommandAsync(string command, params string[] args)
        {
            return await RunCommandAsync(MySQLCommands.CreateCommand(await ConnectAsync(), command, args));
        }

        public int CreateAndRunInsert(object[] values, string table, string fields)
        {
            return RunInsert(MySQLCommands.CreateInsert(Connect(), table, fields, values));
        }

        public static string AppendWithCommas(params string[] strings)
        {
            string s = "";
            for(int i = 0; i < strings.Length; i++)
            {
                s = s + strings[i];
                if (i != strings.Length - 1) s = s + ", ";
            }
            return s;
        }

        public void PrintReader(MySqlDataReader reader)
        {
            while (reader.Read())
            {
                for(int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetValue(i) + " ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }
    }

    public class MySQLCommands
    {
        public static string Select = "SELECT {0} FROM {1}";
        public static string SelectWhere = Select + " WHERE {2}";
        public static string SelectOrderBy = Select + " ORDER BY {2}";
        public static string SelectOrderByLimit = SelectOrderBy + " LIMIT {3}";
        public static string SelectWhereOrderBy = SelectWhere + " ORDER BY {3}";
        public static string SelectWhereOrderByLimit = SelectWhereOrderBy + " LIMIT {4}";
        public static string Insert = "INSERT INTO {0} ({1}) VALUES ({2})";

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
    }
}
