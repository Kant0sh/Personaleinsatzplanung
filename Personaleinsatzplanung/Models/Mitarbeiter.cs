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
        public String Table
        {
            get
            {
                return "mitarbeiter";
            }
        }

        public String InsertValueDefinitions
        {
            get
            {
                return "mitarbeiterkennung, name, vorname, stadt, postleitzahl, straße, hausnummer, faehigkeiten, schicht_id, telefon, mobil, tel_intern, fax_intern, e_mail";
            }
        }

        public object[] InsertValues
        {
            get
            {
                return new object[14] {Kennung, Name, Vorname, Adresse.Stadt, Adresse.Postleitzahl, Adresse.Straße, Adresse.Hausnummer, Fähigkeiten, Schicht.Id, Kontakt.GetRufnummer(RufnummerTyp.FestnetzPrivat), Kontakt.GetRufnummer(RufnummerTyp.MobilDienst), Kontakt.GetRufnummer(RufnummerTyp.FestnetzIntern), Kontakt.GetRufnummer(RufnummerTyp.FaxIntern), Kontakt.EMail};
            }
        }

        public void Save(MySQLHandler Sql)
        {
            Sql.Insert(Table, InsertValueDefinitions, InsertValues);
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

        Adresse _adresse;
        public Adresse Adresse
        {
            get
            {
                return _adresse;
            }
            set
            {
                _adresse = value;
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

        public Mitarbeiter() { }

        public Mitarbeiter(int Id, string Kennung, string Name, string Vorname, Adresse Adresse, string Fähigkeiten, Schicht Schicht, Kontakt Kontakt)
        {
            this.Id = Id;
            this.Kennung = Kennung;
            this.Name = Name;
            this.Vorname = Vorname;
            this.Adresse = Adresse;
            this.Fähigkeiten = Fähigkeiten;
            this.Schicht = Schicht;
            this.Kontakt = Kontakt;
        }
    }
}
