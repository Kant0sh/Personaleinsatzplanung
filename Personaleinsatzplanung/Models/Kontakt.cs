using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Kontakt : Model
    {
        List<Rufnummer> _rufnummern = new List<Rufnummer>();
        public List<Rufnummer> Rufnummern
        {
            get
            {
                return _rufnummern;
            }
            set
            {
                _rufnummern = value;
                OnPropertyChanged();
            }
        }

        public Rufnummer GetRufnummer(RufnummerTyp Typ)
        {
            foreach(Rufnummer r in Rufnummern)
            {
                if (r.Typ == Typ) return r;
            }
            return null;
        }

        string _eMail;
        public string EMail
        {
            get
            {
                return _eMail;
            }
            set
            {
                _eMail = value;
                OnPropertyChanged();
            }
        }

        public Kontakt()
        {

        }
    }
}
