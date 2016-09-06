using System;
using Personaleinsatzplanung.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.ViewModels
{
    public class MitarbeiterViewModel : ViewModel
    {
        public Mitarbeiter Mitarbeiter
        {
            get
            {
                return Model as Mitarbeiter;
            }
            set
            {
                Model = value;
            }
        }

        public MitarbeiterViewModel() { }

        public MitarbeiterViewModel(Mitarbeiter Mitarbeiter)
        {
            this.Mitarbeiter = Mitarbeiter;
        }
    }
}
