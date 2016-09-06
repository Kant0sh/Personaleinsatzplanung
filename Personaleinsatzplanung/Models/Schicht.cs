using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Schicht : Model
    {
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

        string _bezeichnung;
        public string Bezeichnung
        {
            get
            {
                return _bezeichnung;
            }
            set
            {
                _bezeichnung = value;
                OnPropertyChanged();
            }
        }

        List<Schichtzeit> _schichtzeiten;
        public List<Schichtzeit> Schichtzeiten
        {
            get
            {
                return _schichtzeiten;
            }
            set
            {
                _schichtzeiten = value;
                OnPropertyChanged();
            }
        }

        public List<Schichtzeit> GetSchichtzeiten(int TagId)
        {
            List<Schichtzeit> tmpSchichtzeiten = new List<Schichtzeit>();
            foreach(Schichtzeit sz in Schichtzeiten)
            {
                if (sz.TagId == TagId) tmpSchichtzeiten.Add(sz);
            }
            return tmpSchichtzeiten;
        }

        public Schicht()
        {

        }
    }
}
