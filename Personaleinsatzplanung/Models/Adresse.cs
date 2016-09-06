using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Adresse : Model
    {
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
