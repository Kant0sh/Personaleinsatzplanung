using MySql.Data.MySqlClient;
using Personaleinsatzplanung.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class AdressTyp : Model
    {

        public static string Table
        {
            get
            {
                return Settings["adresstyp_table"];
            }
        }

        public static string FieldId
        {
            get
            {
                return Settings["adresstyp_id"];
            }
        }

        public static string FieldBezeichnung
        {
            get
            {
                return Settings["adresstyp_bezeichnung"];
            }
        }

        public static async Task<AdressTyp> LoadAsync(MySQLHandler sql, int AdressTypId)
        {
            AdressTyp typ = new AdressTyp();
            MySqlDataReader reader = await sql.SelectAllWhereAsync(Table, FieldId + " = " + AdressTypId);
            while(await reader.ReadAsync())
            {
                for(int i = 0; i < reader.FieldCount; i++)
                {
                    object val = reader.GetValue(i);
                    string name = reader.GetName(i);
                    if (name == FieldId) typ.Id = (int)val;
                    else if (name == FieldBezeichnung) typ.Bezeichnung = (string)val;
                }
                return typ;
            }
            return null;
        }

        int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        string _bezeichnung;
        public string Bezeichnung
        {
            get
            {
                return _bezeichnung;
            }
            set
            {
                _bezeichnung = value;
                OnPropertyChanged();
            }
        }

        public AdressTyp() { }

        public AdressTyp(int Id, string Bezeichnung)
        {
            this.Id = Id;
            this.Bezeichnung = Bezeichnung;
        }
    }
}
