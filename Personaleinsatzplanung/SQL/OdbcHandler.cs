using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.SQL
{
    public class OdbcHandler : ISqlHandler
    {
        public string ConnectionString
        {
            get
            {
                return "DSN=" + Driver + ";";
            }
        }

        public OdbcHandler(string DSN)
        {
            this.Driver = DSN;
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

        public string Server { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }

        public string Database { get; set; }

        public string Service { get; set; }

        public string Host { get; set; }

        public async Task<OdbcConnection> ConnectAsync()
        {
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = ConnectionString;
            try
            {
                await connection.OpenAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return connection;
        }

        public async Task<int> DeleteAsync(string Table, string Where)
        {
            return await CreateAndRunDeleteAsync(Table, Where);
        }

        public async Task<int> InsertAsync(string Table, string Fields, params object[] Values)
        {
            return await CreateAndRunInsertAsync(Values, Table, Fields);
        }

        public async Task<SqlDataSet> SelectAllAsync(string Table)
        {
            return await GetDataAsync(OdbcCommands.Select, SqlUtility.All, Table);
        }

        public async Task<SqlDataSet> SelectAllOrderByAsync(string Table, string OrderBy)
        {
            return await GetDataAsync(OdbcCommands.SelectOrderBy, SqlUtility.All, Table, OrderBy);
        }

        public async Task<SqlDataSet> SelectAllWhereAsync(string Table, string Where)
        {
            return await GetDataAsync(OdbcCommands.SelectWhere, SqlUtility.All, Table, Where);
        }

        public async Task<SqlDataSet> SelectAllWhereOrderByAsync(string Table, string Where, string OrderBy)
        {
            return await GetDataAsync(OdbcCommands.SelectWhereOrderBy, SqlUtility.All, Table, Where, OrderBy);
        }

        public async Task<SqlDataSet> SelectAsync(string Table, string Fields)
        {
            return await GetDataAsync(OdbcCommands.Select, Fields, Table);
        }

        public async Task<int> SelectHighestAsync(string Table, string Field)
        {
            object obj = (await SelectOrderByLimitAsync(Table, Field, Field + " DESC", "1")).Data[0][0];
            if (obj != null && obj is int) return (int)obj;
            return -1;
        }

        public async Task<SqlDataSet> SelectOrderByAsync(string Table, string Fields, string OrderBy)
        {
            return await GetDataAsync(OdbcCommands.SelectOrderBy, Fields, Table, OrderBy);
        }

        public async Task<SqlDataSet> SelectOrderByLimitAsync(string Table, string Fields, string OrderBy, string Limit)
        {
            return await GetDataAsync(OdbcCommands.SelectOrderByLimit, Fields, Table, OrderBy, Limit);
        }

        public async Task<SqlDataSet> SelectWhereAsync(string Table, string Fields, string Where)
        {
            return await GetDataAsync(OdbcCommands.SelectWhere, Fields, Table, Where);
        }

        public async Task<SqlDataSet> SelectWhereOrderByAsync(string Table, string Fields, string Where, string OrderBy)
        {
            return await GetDataAsync(OdbcCommands.SelectWhereOrderBy, Fields, Table, Where, OrderBy);
        }

        public async Task<SqlDataSet> SelectWhereOrderByLimitAsync(string Table, string Fields, string Where, string OrderBy, string Limit)
        {
            return await GetDataAsync(OdbcCommands.SelectWhereOrderByLimit, Fields, Table, Where, OrderBy, Limit);
        }

        public async Task<int> UpdateAsync(string Table, string Fields, string Where, params object[] Values)
        {
            return await CreateAndRunUpdateAsync(Table, Where, SqlUtility.ToArrayFromCommas(Fields), Values);
        }

        public async Task<ConnectedOdbcDataReader> RunCommandAsync(OdbcConnection connection, OdbcCommand command)
        {
            return new ConnectedOdbcDataReader(connection, await command.ExecuteReaderAsync() as OdbcDataReader);
        }

        public async Task<ConnectedOdbcDataReader> CreateAndRunCommandAsync(string command, params string[] args)
        {
            OdbcConnection connection = await ConnectAsync();
            return await RunCommandAsync(connection, OdbcCommands.CreateCommand(connection, command, args));
        }

        public async Task<int> CreateAndRunInsertAsync(object[] values, string table, string fields)
        {
            return await OdbcCommands.CreateInsert(await ConnectAsync(), table, SqlUtility.ToArrayFromCommas(fields), values).ExecuteNonQueryAsync();
        }

        public async Task<int> CreateAndRunDeleteAsync(string table, string where)
        {
            return await OdbcCommands.CreateDelete(await ConnectAsync(), table, where).ExecuteNonQueryAsync();
        }

        public async Task<int> CreateAndRunUpdateAsync(string table, string where, string[] fields, params object[] values)
        {
            return await OdbcCommands.CreateUpdate(await ConnectAsync(), table, where, fields, values).ExecuteNonQueryAsync();
        }

        public async Task<SqlDataSet> GetDataAsync(string command, params string[] args)
        {
            return SqlDataSet.FromOdbcDataReader(await CreateAndRunCommandAsync(command, args));
        }
    }

    public class OdbcCommands : SqlCommands
    {
        public static OdbcCommand CreateCommand(OdbcConnection connection, string command, params string[] args)
        {
            OdbcCommand comm = new OdbcCommand(string.Format(command, args));
            comm.Connection = connection;
            return comm;
        }

        public static OdbcCommand CreateInsert(OdbcConnection connection, string table, string[] fields, params object[] args)
        {
            OdbcCommand comm = new OdbcCommand(string.Format(Insert, table, SqlUtility.AppendWithCommas(fields), SqlUtility.GenerateInsertParameters(fields)));
            for (int i = 0; i < args.Length; i++)
            {
                comm.Parameters.Add(new OdbcParameter() { Value = args[i] });
            }
            comm.Connection = connection;
            return comm;
        }

        public static OdbcCommand CreateDelete(OdbcConnection connection, string table, string where)
        {
            OdbcCommand command = new OdbcCommand(string.Format(Delete, table, where));
            command.Connection = connection;
            return command;
        }

        public static OdbcCommand CreateUpdate(OdbcConnection connection, string table, string where, string[] fields, object[] values)
        {
            OdbcCommand command = new OdbcCommand(string.Format(Update, table, SqlUtility.GenerateSets(fields), where));
            for (int i = 0; i < fields.Length; i++)
            {
                OdbcType type = OdbcType.VarChar;
                object o = values[i];
                if (o is string) type = OdbcType.VarChar;
                else if (o is int) type = OdbcType.Int;
                else if (o is TimeSpan) type = OdbcType.Time;
                else if (o is DateTime) type = OdbcType.DateTime;
                else if (o is bool) type = OdbcType.Bit;
                else if (o is decimal) type = OdbcType.Decimal;
                command.Parameters.Add("@" + fields[i], type).Value = values[i];
            }
            command.Connection = connection;
            return command;
        }
    }
}
