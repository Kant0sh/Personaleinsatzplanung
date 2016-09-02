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

        MySqlConnection _connection;

        public MySqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public MySQLHandler(string serverUrl, string userId, string password, string database)
        {
            _serverUrl = serverUrl;
            _userId = userId;
            _password = password;
            _database = database;
        }

        public MySQLHandler Connect()
        {
            try
            {
                _connection = new MySqlConnection(ConnectionString);
                _connection.Open();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return this;
        }

        public void Disconnect()
        {
            _connection.ClearAllPoolsAsync();
            _connection.CloseAsync();
        }

        public MySqlDataReader SelectAll(string table)
        {
            MySqlCommand command = new MySqlCommand(table);
            command.Connection = _connection;
            command.CommandType = CommandType.TableDirect;
            return command.ExecuteReader();
        }

        public MySqlDataReader SelectAllWhere(string table, string where)
        {
            return CreateAndRunCommand(MySQLCommands.SelectWhere, "*", table, where);
        }

        public MySqlDataReader SelectWhere(string fields, string table, string where)
        {
            return CreateAndRunCommand(MySQLCommands.SelectWhere, fields, table, where);
        }

        public int Insert(string table, string definitions, string values)
        {
            return CreateAndRunInsert(MySQLCommands.Insert, table, definitions, values);
        }

        public String GetMySQLFormattedDateTime(DateTime dt)
        {
            return string.Format("{yyyy-MM-dd HH:mm:ss}", dt);
        }

        public MySqlDataReader RunCommand(MySqlCommand command)
        {
            return command.ExecuteReader();
        }

        public int RunInsert(MySqlCommand command)
        {
            return command.ExecuteNonQuery();
        }

        public MySqlDataReader CreateAndRunCommand(string command, params string[] args)
        {
            return RunCommand(MySQLCommands.CreateCommand(_connection, command, args));
        }

        public int CreateAndRunInsert(string command, params string[] args)
        {
            return RunInsert(MySQLCommands.CreateCommand(_connection, command, args));
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
        public static string Insert = "INSERT INTO {0} ({1}) VALUES ({2})";

        public static MySqlCommand CreateCommand(MySqlConnection connection, string command, params string[] args)
        {
            MySqlCommand comm = new MySqlCommand(string.Format(command, args));
            comm.Connection = connection;
            return comm;
        }
    }
}
