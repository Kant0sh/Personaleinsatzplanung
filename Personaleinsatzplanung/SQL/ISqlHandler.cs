using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.SQL
{
    public interface ISqlHandler
    {
        string ServerUrl { get; set; }
        string UserId { get; set; }
        string Password { get; set; }
        string Database { get; set; }
        string Driver { get; set; }
        string Host { get; set; }

        string ConnectionString { get; }

        Task<SqlDataSet> SelectAsync(string Table, string Fields);
        Task<SqlDataSet> SelectAllAsync(string Table);
        Task<SqlDataSet> SelectAllWhereAsync(string Table, string Where);
        Task<SqlDataSet> SelectWhereAsync(string Table, string Fields, string Where);
        Task<SqlDataSet> SelectOrderByAsync(string Table, string Fields, string OrderBy);
        Task<SqlDataSet> SelectWhereOrderByAsync(string Table, string Fields, string Where, string OrderBy);
        Task<SqlDataSet> SelectAllOrderByAsync(string Table, string OrderBy);
        Task<SqlDataSet> SelectAllWhereOrderByAsync(string Table, string Where, string OrderBy);
        Task<SqlDataSet> SelectOrderByLimitAsync(string Table, string Fields, string OrderBy, string Limit);
        Task<SqlDataSet> SelectWhereOrderByLimitAsync(string Table, string Fields, string Where, string OrderBy, string Limit);
        Task<int> SelectHighestAsync(string Table, string Field);

        Task<int> InsertAsync(string Table, string Fields, params object[] Values);

        Task<int> DeleteAsync(string Table, string Where);

        Task<int> UpdateAsync(string Table, string Fields, string Where, params object[] Values);
    }
}
