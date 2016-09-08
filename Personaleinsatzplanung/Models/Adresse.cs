using MySql.Data.MySqlClient;
using Personaleinsatzplanung.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Adresse : Model
    {

        public static string Table
        {
            get
            {
                return Settings["adresse_table"];
            }
        }

        public static string FieldId
        {
            get
            {
                return Settings["adresse_id"];
            }
        }

        public static string FieldLand
        {
            get
            {
                return Settings["adresse_land"];
            }
        }

        public static string FieldStadt
        {
            get
            {
                return Settings["adresse_stadt"];
            }
        }

        public static string FieldPostleitzahl
        {
            get
            {
                return Settings["adresse_postleitzahl"];
            }
        }

        public static string FieldStraße
        {
            get
            {
                return Settings["adresse_straße"];
            }
        }

        public static string FieldHausnummer
        {
            get
            {
                return Settings["adresse_hausnummer"];
            }
        }

        public static string FieldAdresszusatz
        {
            get
            {
                return Settings["adresse_adresszusatz"];
            }
        }

        public static string FieldAuftraggeber
        {
            get
            {
                return Settings["adresse_auftraggeber"];
            }
        }

        public static string FieldMitarbeiter
        {
            get
            {
                return Settings["adresse_mitarbeiter"];
            }
        }

        public static string FieldAdresstyp
        {
            get
            {
                return Settings["adresse_adresstyp"];
            }
        }

        public string InsertFields
        {
            get
            {
                return MySQLHandler.AppendWithCommas(FieldId, FieldLand, FieldStadt, FieldPostleitzahl, FieldStraße, FieldHausnummer, FieldAdresszusatz, FieldAuftraggeber, FieldMitarbeiter, FieldAdresstyp);
            }
        }

        public object[] InsertValues
        {
            get
            {
                return new object[10] { Id, Land, Stadt, Postleitzahl, Straße, Hausnummer, Adresszusatz, Auftraggeber, Mitarbeiter, Typ };
            }
        }

        public void Save(MySQLHandler Sql)
        {
            Sql.Insert(Table, InsertFields, InsertValues);
        }

        public static MySqlDataReader LoadAll(MySQLHandler sql)
        {
            return sql.SelectAll(Table);
        }

        public static MySqlDataReader Load(MySQLHandler sql, string where)
        {
            if (where == string.Empty) return sql.SelectAll(Table);
            return sql.SelectAllWhere(Table, where);
        }

        public static MySqlDataReader Load(MySQLHandler sql, string fields, string where)
        {
            if (where == string.Empty) return sql.Select(Table, fields);
            return sql.SelectWhere(fields, Table, where);
        }

        public async static Task<MySqlDataReader> LoadAsync(MySQLHandler sql, string where)
        {
            if (where == string.Empty) return await sql.SelectAllAsync(Table);
            return await sql.SelectAllWhereAsync(Table, where);
        }

        public async static Task<MySqlDataReader> LoadAllAsync(MySQLHandler sql)
        {
            return await sql.SelectAllAsync(Table);
        }

        public static async Task<List<Adresse>> LoadListAsync(MySQLHandler sql, string where)
        {
            MySqlDataReader reader = await LoadAsync(sql, where);
            List<Adresse> adressen = new List<Adresse>();
            while (await reader.ReadAsync())
            {
                Adresse adresse = new Adresse();
                for(int i = 0; i < reader.FieldCount; i++)
                {
                    object val = await reader.GetFieldValueAsync<object>(i);
                    if (!(val is DBNull))
                    {
                        string name = reader.GetName(i);
                        if (name == FieldId) adresse.Id = (int)val;
                        else if (name == FieldLand) adresse.Land = (string)val;
                        else if (name == FieldStadt) adresse.Stadt = (string)val;
                        else if (name == FieldPostleitzahl) adresse.Postleitzahl = (string)val;
                        else if (name == FieldStraße) adresse.Straße = (string)val;
                        else if (name == FieldHausnummer) adresse.Hausnummer = (string)val;
                        else if (name == FieldAdresszusatz) adresse.Adresszusatz = (string)val;
                        else if (name == FieldAdresstyp) adresse.Typ = await AdressTyp.LoadAsync(sql, (int)val);
                    }
                }
                adressen.Add(adresse);
            }
            return adressen;
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

        string _land;
        public string Land
        {
            get
            {
                return _land;
            }
            set
            {
                _land = value;
                OnPropertyChanged();
            }
        }

        string _stadt;
        public string Stadt
        {
            get
            {
                return _stadt;
            }
            set
            {
                _stadt = value;
                OnPropertyChanged();
            }
        }

        string _postleitzahl;
        public string Postleitzahl
        {
            get
            {
                return _postleitzahl;
            }
            set
            { 
                _postleitzahl = value;
                OnPropertyChanged();
            }
        }

        string _straße;
        public string Straße
        {
            get
            {
                return _straße;
            }
            set
            {
                _straße = value;
                OnPropertyChanged();
            }
        }

        string _hausnummer;
        public string Hausnummer
        {
            get
            {
                return _hausnummer;
            }
            set
            {
                _hausnummer = value;
                OnPropertyChanged();
            }
        }

        string _adresszusatz;
        public String Adresszusatz
        {
            get
            {
                return _adresszusatz;
            }
            set
            {
                _adresszusatz = value;
                OnPropertyChanged();
            }
        }

        Auftraggeber _auftraggeber;
        public Auftraggeber Auftraggeber
        {
            get
            {
                return _auftraggeber;
            }
            set
            {
                _auftraggeber = value;
                OnPropertyChanged();
            }
        }

        public void QueueAuftraggeberLoad(int AuftraggeberId)
        {

        }

        Mitarbeiter _mitarbeiter;
        public Mitarbeiter Mitarbeiter
        {
            get
            {
                return _mitarbeiter;
            }
            set
            {
                _mitarbeiter = value;
                OnPropertyChanged();
            }
        }

        AdressTyp _typ;
        public AdressTyp Typ
        {
            get
            {
                return _typ;
            }
            set
            {
                _typ = value;
                OnPropertyChanged();
            }
        }

        public Adresse() { }

        public Adresse(string Land, string Stadt, string Postleitzahl, string Straße, string Hausnummer, string Adresszusatz)
        {
            this.Land = Land;
            this.Stadt = Stadt;
            this.Postleitzahl = Postleitzahl;
            this.Straße = Straße;
            this.Hausnummer = Hausnummer;
            this.Adresszusatz = Adresszusatz;
        }
    }
}
