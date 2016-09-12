using MySql.Data.MySqlClient;
using Personaleinsatzplanung.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    /// <summary>
    /// Repräsentiert eine Adresse aus der DB
    /// </summary>
    /// <seealso cref="Personaleinsatzplanung.Models.Model" />
    public class Adresse : Model
    {

        #region SQL Felder

        // Alle Feldernamen werden in der Database.config definiert

        /// <summary>
        /// Gibt den Namen der verknüpften Tabelle in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Tabellenname
        /// </value>
        public static string Table
        {
            get
            {
                return Settings["adresse_table"];
            }
        }

        /// <summary>
        /// Gibt den Namen des Feldes "Id" in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Feldname Id
        /// </value>
        public static string FieldId
        {
            get
            {
                return Settings["adresse_id"];
            }
        }

        /// <summary>
        /// Gibt den Namen des Feldes "Land" in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Feldname Land
        /// </value>
        public static string FieldLand
        {
            get
            {
                return Settings["adresse_land"];
            }
        }

        /// <summary>
        /// Gibt den Namen des Feldes "Stadt" in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Feldname Stadt
        /// </value>
        public static string FieldStadt
        {
            get
            {
                return Settings["adresse_stadt"];
            }
        }

        /// <summary>
        /// Gibt den Namen des Feldes "Postleitzahl" in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Feldname Postleitzahl
        /// </value>
        public static string FieldPostleitzahl
        {
            get
            {
                return Settings["adresse_postleitzahl"];
            }
        }

        /// <summary>
        /// Gibt den Namen des Feldes "Straße" in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Feldname Straße
        /// </value>
        public static string FieldStraße
        {
            get
            {
                return Settings["adresse_straße"];
            }
        }

        /// <summary>
        /// Gibt den Namen des Feldes "Hausnummer" in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Feldname Hausnummer
        /// </value>
        public static string FieldHausnummer
        {
            get
            {
                return Settings["adresse_hausnummer"];
            }
        }

        /// <summary>
        /// Gibt den Namen des Feldes "Adresszusatz" in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Feldname Adresszusatz
        /// </value>
        public static string FieldAdresszusatz
        {
            get
            {
                return Settings["adresse_adresszusatz"];
            }
        }

        /// <summary>
        /// Gibt den Namen des Feldes "Auftraggeber" in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Feldname Auftraggeber
        /// </value>
        public static string FieldAuftraggeber
        {
            get
            {
                return Settings["adresse_auftraggeber"];
            }
        }

        /// <summary>
        /// Gibt den Namen des Feldes "Mitarbeiter" in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Feldname Mitarbeiter
        /// </value>
        public static string FieldMitarbeiter
        {
            get
            {
                return Settings["adresse_mitarbeiter"];
            }
        }

        /// <summary>
        /// Gibt den Namen des Feldes "Adresstyp" in der Datenbank aus.
        /// </summary>
        /// <value>
        /// Feldname Adresstyp
        /// </value>
        public static string FieldAdresstyp
        {
            get
            {
                return Settings["adresse_adresstyp"];
            }
        }

        #endregion

        #region SQL Methoden



        #endregion

        #region Felder

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

        int _adresstyp;
        public int Adresstyp
        {
            get
            {
                return _adresstyp;
            }
            set
            {
                _adresstyp = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialisiert eine leere Instanz der <see cref="Adresse"/> klasse.
        /// </summary>
        public Adresse() { }

        /// <summary>
        /// Initialisiert eine Instanz der <see cref="Adresse"/> klasse mit allen Parametern.
        /// </summary>
        public Adresse(string Land, string Stadt, string Postleitzahl, string Straße, string Hausnummer, string Adresszusatz, Auftraggeber Auftraggeber, Mitarbeiter Mitarbeiter, int Adresstyp)
        {
            this.Land = Land;
            this.Stadt = Stadt;
            this.Postleitzahl = Postleitzahl;
            this.Straße = Straße;
            this.Hausnummer = Hausnummer;
            this.Adresszusatz = Adresszusatz;
            this.Auftraggeber = Auftraggeber;
            this.Mitarbeiter = Mitarbeiter;
            this.Adresstyp = Adresstyp;
        }

        #endregion

    }

    public enum AdresstypMitarbeiter
    {
        Privat,
        Zweitadresse,
        Büro
    }

    public enum AdresstypAuftraggeber
    {
        Lieferadresse,
        Rechnungsadresse
    }

}
