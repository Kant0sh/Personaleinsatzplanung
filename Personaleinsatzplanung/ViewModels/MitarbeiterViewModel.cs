using System;
using Personaleinsatzplanung.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.ViewModels
{
    public class MitarbeiterViewModel
    {
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
            }
        }        

        public string GanzerName
        {
            get
            {
                return Mitarbeiter.Vorname + " " + Mitarbeiter.Name;
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

        public MitarbeiterViewModel() { }

        public MitarbeiterViewModel(Mitarbeiter Mitarbeiter)
        {
            this.Mitarbeiter = Mitarbeiter;
        }
    }
}
