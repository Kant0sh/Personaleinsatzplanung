using Microsoft.Practices.Prism.Commands;
using MySql.Data.MySqlClient;
using Personaleinsatzplanung.Models;
using Personaleinsatzplanung.SQL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.ViewModels
{
    public class MitarbeiterErfassenViewModel
    {
        MySQLHandler _sql;

        public Mitarbeiter Mitarbeiter = new Mitarbeiter();

        ObservableCollection<Schicht> _schichten = new ObservableCollection<Schicht>();
        public ObservableCollection<Schicht> Schichten
        {
            get
            {
                return _schichten;
            }
            set
            {
                _schichten = value;
            }
        }

        public string Kennung
        {
            get
            {
                return Mitarbeiter.Kennung;
            }
            set
            {
                Mitarbeiter.Kennung = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string Name
        {
            get
            {
                return Mitarbeiter.Name;
            }
            set
            {
                Mitarbeiter.Name = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string Vorname
        {
            get
            {
                return Mitarbeiter.Vorname;
            }
            set
            {
                Mitarbeiter.Vorname = value;
            }
        }

        public string Fähigkeiten
        {
            get
            {
                return Mitarbeiter.Fähigkeiten;
            }
            set
            {
                Mitarbeiter.Fähigkeiten = value;
            }
        }

        public Schicht Schicht
        {
            get
            {
                return Mitarbeiter.Schicht;
            }
            set
            {
                Mitarbeiter.Schicht = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string Telefon
        {
            get
            {
                if (Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FestnetzPrivat) == null) Mitarbeiter.Kontakt.Rufnummern.Add(new Rufnummer(string.Empty, RufnummerTyp.FestnetzPrivat));
                return Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FestnetzPrivat).Nummer;
            }
            set
            {
                if (Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FestnetzPrivat) == null) Mitarbeiter.Kontakt.Rufnummern.Add(new Rufnummer(string.Empty, RufnummerTyp.FestnetzPrivat));
                Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FestnetzPrivat).Nummer = value;
            }
        }

        public string Mobil
        {
            get
            {
                if (Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.MobilDienst) == null) Mitarbeiter.Kontakt.Rufnummern.Add(new Rufnummer(string.Empty, RufnummerTyp.MobilDienst));
                return Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.MobilDienst).Nummer;
            }
            set
            {
                if (Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.MobilDienst) == null) Mitarbeiter.Kontakt.Rufnummern.Add(new Rufnummer(string.Empty, RufnummerTyp.MobilDienst));
                Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.MobilDienst).Nummer = value;
            }
        }

        public string TelefonIntern
        {
            get
            {
                if (Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FestnetzIntern) == null) Mitarbeiter.Kontakt.Rufnummern.Add(new Rufnummer(string.Empty, RufnummerTyp.FestnetzIntern));
                return Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FestnetzIntern).Nummer;
            }
            set
            {
                if (Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FestnetzIntern) == null) Mitarbeiter.Kontakt.Rufnummern.Add(new Rufnummer(string.Empty, RufnummerTyp.FestnetzIntern));
                Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FestnetzIntern).Nummer = value;
            }
        }

        public string FaxIntern
        {
            get
            {
                if (Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FaxIntern) == null) Mitarbeiter.Kontakt.Rufnummern.Add(new Rufnummer(string.Empty, RufnummerTyp.FaxIntern));
                return Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FaxIntern).Nummer;
            }
            set
            {
                if (Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FaxIntern) == null) Mitarbeiter.Kontakt.Rufnummern.Add(new Rufnummer(string.Empty, RufnummerTyp.FaxIntern));
                Mitarbeiter.Kontakt.GetRufnummer(RufnummerTyp.FaxIntern).Nummer = value;
            }
        }

        public string EMail
        {
            get
            {
                return Mitarbeiter.Kontakt.EMail;
            }
            set
            {
                Mitarbeiter.Kontakt.EMail = value;
            }
        }

        DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand
        {
            get
            {
                return _saveCommand;
            }
            set
            {
                _saveCommand = value;
            }
        }

        public MitarbeiterErfassenViewModel(MySQLHandler Sql)
        {
            _sql = Sql;
            LoadSchichten();
            SaveCommand = new DelegateCommand(SaveMitarbeiter, CanSaveMitarbeiter);
        }

        public void SaveMitarbeiter()
        {
            Mitarbeiter.Save(_sql);
        }

        public bool CanSaveMitarbeiter()
        {
            if (Schicht != null && Name.Trim() != string.Empty && Kennung.Trim() != string.Empty) return true;
            return false;
        }

        public void LoadSchichten()
        {
            
        }
    }
}
