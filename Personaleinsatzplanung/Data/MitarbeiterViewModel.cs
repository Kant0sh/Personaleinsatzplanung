using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Data
{
    public class MitarbeiterViewModel : BaseViewModel
    {

        string _nachname;
        string _vorname;
        int _nummer;
        string _fähigkeiten;

        public string Nachname
        {
            get
            {
                return _nachname;
            }
            set
            {
                _nachname = value;
                OnPropertyChanged();
            }
        }

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

        public int Nummer
        {
            get
            {
                return _nummer;
            }
            set
            {
                _nummer = value;
                OnPropertyChanged();
            }
        }

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

    }
}
