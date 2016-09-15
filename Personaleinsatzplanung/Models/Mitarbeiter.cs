using Personaleinsatzplanung.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Mitarbeiter : Model
    {

        public static string Table
        {
            get
            {
                return Settings["mitarbeiter_table"];
            }
        }

        public static string FieldId
        {
            get
            {
                return Settings["mitarbeiter_id"];
            }
        }

        public static string FieldKennung
        {
            get
            {
                return Settings["mitarbeiter_kennung"];
            }
        }

        public static string FieldName
        {
            get
            {
                return Settings["mitarbeiter_name"];
            }
        }

        public static string FieldVorname
        {
            get
            {
                return Settings["mitarbeiter_vorname"];
            }
        }

        public static string FieldFähigkeiten
        {
            get
            {
                return Settings["mitarbeiter_fähigkeiten"];
            }
        }

        public static string FieldSchicht
        {
            get
            {
                return Settings["mitarbeiter_schicht"];
            }
        }

        public static string FieldTelefon
        {
            get
            {
                return Settings["mitarbeiter_telefon"];
            }
        }

        public static string FieldMobil
        {
            get
            {
                return Settings["mitarbeiter_mobil"];
            }
        }

        public static string FieldTelefonIntern
        {
            get
            {
                return Settings["mitarbeiter_telefonIntern"];
            }
        }

        public static string FieldFaxIntern
        {
            get
            {
                return Settings["mitarbeiter_faxIntern"];
            }
        }

        public static string FieldEMail
        {
            get
            {
                return Settings["mitarbeiter_email"];
            }
        }

        public string InsertFields
        {
            get
            {
                return SqlUtility.AppendWithCommas(FieldKennung, FieldName, FieldVorname, FieldFähigkeiten, FieldSchicht, FieldTelefon, FieldMobil, FieldTelefonIntern, FieldFaxIntern, FieldEMail);
            }
        }

        public object[] InsertValues
        {
            get
            {
                return new object[10] { Kennung, Name, Vorname, Fähigkeiten, Schicht.Id, Kontakt.GetRufnummer(RufnummerTyp.FestnetzPrivat).Nummer, Kontakt.GetRufnummer(RufnummerTyp.MobilDienst).Nummer, Kontakt.GetRufnummer(RufnummerTyp.FestnetzIntern).Nummer, Kontakt.GetRufnummer(RufnummerTyp.FaxIntern).Nummer, Kontakt.EMail };
            }
        }

        public async void Save(ISqlHandler Sql)
        {
            await Sql.InsertAsync(Table, InsertFields, InsertValues);
        }

        public async static Task<Mitarbeiter> LoadAsync(ISqlHandler Sql, string[] fields, int Id)
        {
            SqlDataSet data = await Sql.SelectWhereAsync(Table, SqlUtility.AppendWithCommas(fields), SqlUtility.Equal(FieldId, Id));
            Mitarbeiter mit = new Mitarbeiter();
            for(int i = 0; i < data.FieldCount; i++)
            {
                string f = data.FieldNames[i];
                object o = data.Data[0][i];
                if (o is DBNull) o = default(object);
                if (f == FieldId) mit.Id = (int)o;
                else if (f == FieldKennung) mit.Kennung = (string)o;
                else if (f == FieldName) mit.Name = (string)o;
                else if (f == FieldVorname) mit.Vorname = (string)o;
                else if (f == FieldFähigkeiten) mit.Fähigkeiten = (string)o;
                else if (f == FieldSchicht) mit.Schicht.Id = (int)o;
                else if (f == FieldTelefon) mit.Kontakt.Rufnummern.Add(new Rufnummer((string)o, RufnummerTyp.FestnetzPrivat));
                else if (f == FieldMobil) mit.Kontakt.Rufnummern.Add(new Rufnummer((string)o, RufnummerTyp.MobilDienst));
                else if (f == FieldTelefonIntern) mit.Kontakt.Rufnummern.Add(new Rufnummer((string)o, RufnummerTyp.FestnetzIntern));
                else if (f == FieldFaxIntern) mit.Kontakt.Rufnummern.Add(new Rufnummer((string)o, RufnummerTyp.FaxIntern));
                else if (f == FieldEMail) mit.Kontakt.EMail = (string)o;
            }
            return mit;
        }

        public async static Task<List<Mitarbeiter>> LoadAllAsync(string[] Fields, ISqlHandler Sql)
        {
            SqlDataSet data = await Sql.SelectAsync(Table, SqlUtility.AppendWithCommas(Fields));
            List<Mitarbeiter> mitarbeiter = new List<Mitarbeiter>();
            foreach(List<object> singleData in data.Data)
            {
                Mitarbeiter mit = new Mitarbeiter();
                for (int i = 0; i < data.FieldCount; i++)
                {
                    string f = data.FieldNames[i];
                    object o = singleData[i];
                    if (o is DBNull) o = default(object);
                    if (f == FieldId) mit.Id = (int)o;
                    else if (f == FieldKennung) mit.Kennung = (string)o;
                    else if (f == FieldName) mit.Name = (string)o;
                    else if (f == FieldVorname) mit.Vorname = (string)o;
                    else if (f == FieldFähigkeiten) mit.Fähigkeiten = (string)o;
                    else if (f == FieldSchicht) mit.Schicht.Id = (int)o;
                    else if (f == FieldTelefon) mit.Kontakt.Rufnummern.Add(new Rufnummer((string)o, RufnummerTyp.FestnetzPrivat));
                    else if (f == FieldMobil) mit.Kontakt.Rufnummern.Add(new Rufnummer((string)o, RufnummerTyp.MobilDienst));
                    else if (f == FieldTelefonIntern) mit.Kontakt.Rufnummern.Add(new Rufnummer((string)o, RufnummerTyp.FestnetzIntern));
                    else if (f == FieldFaxIntern) mit.Kontakt.Rufnummern.Add(new Rufnummer((string)o, RufnummerTyp.FaxIntern));
                    else if (f == FieldEMail) mit.Kontakt.EMail = (string)o;
                }
                mitarbeiter.Add(mit);
            }
            return mitarbeiter;
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

        string _kennung;
        public string Kennung
        {
            get
            {
                return _kennung;
            }
            set
            {
                _kennung = value;
                OnPropertyChanged();
            }
        }

        string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        string _vorname;
        public string Vorname
        {
            get
            {
                return _vorname;
            }
            set
            {
                _vorname = value;
                OnPropertyChanged();
            }
        }

        string _fähigkeiten;
        public string Fähigkeiten
        {
            get
            {
                return _fähigkeiten;
            }
            set
            {
                _fähigkeiten = value;
                OnPropertyChanged();
            }
        }

        Schicht _schicht;
        public Schicht Schicht
        {
            get
            {
                return _schicht;
            }
            set
            {
                _schicht = value;
                OnPropertyChanged();
            }
        }

        Kontakt _kontakt;
        public Kontakt Kontakt
        {
            get
            {
                return _kontakt;
            }
            set
            {
                _kontakt = value;
                OnPropertyChanged();
            }
        }

        List<Adresse> _adressen;
        public List<Adresse> Adressen
        {
            get
            {
                return _adressen;
            }
            set
            {
                _adressen = value;
                OnPropertyChanged();
            }
        }

        public void AddRufnummer(Rufnummer rufnummer)
        {
            if (Kontakt == null) Kontakt = new Kontakt();
            if(Kontakt.GetRufnummer(rufnummer.Typ) == null)
            {
                Kontakt.Rufnummern.Add(rufnummer);
            }
        }

        public void AddEmail(string email)
        {
            if (Kontakt == null) Kontakt = new Kontakt();
            if (Kontakt.EMail == null || Kontakt.EMail.Trim() == string.Empty)
            {
                Kontakt.EMail = email;
            }
        }

        public Mitarbeiter()
        {
            this.Schicht = new Schicht();
            this.Adressen = new List<Adresse>();
            this.Kontakt = new Kontakt();
            this.Id = 0;
            this.Kennung = string.Empty;
            this.Name = string.Empty;
            this.Vorname = string.Empty;
            this.Fähigkeiten = string.Empty;
        }

        public Mitarbeiter(int Id, string Kennung, string Name, string Vorname, List<Adresse> Adressen, string Fähigkeiten, Schicht Schicht, Kontakt Kontakt)
        {
            this.Id = Id;
            this.Kennung = Kennung;
            this.Name = Name;
            this.Vorname = Vorname;
            this.Adressen = Adressen;
            this.Fähigkeiten = Fähigkeiten;
            this.Schicht = Schicht;
            this.Kontakt = Kontakt;
        }
    }
}
