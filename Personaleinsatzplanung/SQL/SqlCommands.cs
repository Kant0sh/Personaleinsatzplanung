using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.SQL
{
    public class SqlCommands
    {
        public static string Select = "SELECT {0} FROM {1}";
        public static string SelectWhere = Select + " WHERE {2}";
        public static string SelectOrderBy = Select + " ORDER BY {2}";
        public static string SelectOrderByLimit = SelectOrderBy + " LIMIT {3}";
        public static string SelectWhereOrderBy = SelectWhere + " ORDER BY {3}";
        public static string SelectWhereOrderByLimit = SelectWhereOrderBy + " LIMIT {4}";

        public static string Insert = "INSERT INTO {0} ({1}) VALUES ({2})";

        public static string Delete = "DELETE FROM {0} WHERE {1}";

        public static string Update = "UPDATE {0} SET {1} WHERE {2}";
    }
}
