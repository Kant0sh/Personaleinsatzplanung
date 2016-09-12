using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.SQL
{
    public class SqlDataSet
    {
        List<string> _fieldNames = new List<string>();
        public List<string> FieldNames
        {
            get
            {
                return _fieldNames;
            }
            set
            {
                _fieldNames = value;
            }
        }

        List<List<object>> _data = new List<List<object>>();
        public List<List<object>> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public int DataRowCount
        {
            get
            {
                int i = 0;
                foreach(List<object> list in Data)
                {
                    if(list.Count > i)
                    {
                        i = list.Count;
                    }
                }
                return i;
            }
        }

        public int FieldCount
        {
            get
            {
                return FieldNames.Count;
            }
        }

        public void AddData(string[] FieldNames, object[] data)
        {
            int index = DataRowCount;
            if(FieldNames.Length == data.Length)
            {
                for(int i = 0; i < FieldNames.Length; i++)
                {
                    AddData(FieldNames[i], data[i], index);
                }
            }
        }

        public void AddData(string FieldName, object data, int Index)
        {
            if (!FieldNames.Contains(FieldName)) AddField(FieldName);
            while (GetFieldData(FieldName).Count <= Index) GetFieldData(FieldName).Add(default(object));
            GetFieldData(FieldName)[Index] = data;
        }

        public List<object> GetFieldData(string FieldName)
        {
            return Data[FieldNames.IndexOf(FieldName)];
        }

        public object GetFieldData(string FieldName, int Index)
        {
            return GetFieldData(FieldName)[Index];
        }

        public void AddField(string FieldName)
        {
            FieldNames.Add(FieldName);
            Data.Add(new List<object>());
        }

        public SqlDataSet() { }

        public SqlDataSet(params string[] FieldNames)
        {
            for(int i = 0; i < FieldNames.Length; i++)
            {
                AddField(FieldNames[i]);
            }
        }

        public async static Task<SqlDataSet> FromMySqlDataReaderAsync(ConnectedMySqlDataReader Reader)
        {
            SqlDataSet Data = new SqlDataSet();
            while(await Reader.Reader.ReadAsync())
            {
                string[] fieldNames = new string[Reader.Reader.FieldCount];
                object[] data = new object[Reader.Reader.FieldCount];
                for(int i = 0; i < Reader.Reader.FieldCount; i++)
                {
                    fieldNames[i] = Reader.Reader.GetName(i);
                    data[i] = await Reader.Reader.GetFieldValueAsync<object>(i);
                }
                Data.AddData(fieldNames, data);
            }
            await Reader.CloseAsync();
            return Data;
        }
    }
}
