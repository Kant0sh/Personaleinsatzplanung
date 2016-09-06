using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Schichtzeit : Model
    {
        Schicht _parentSchicht;
        public Schicht ParentSchicht
        {
            get
            {
                return _parentSchicht;
            }
            set
            {
                _parentSchicht = value;
                OnPropertyChanged();
            }
        }

        int _tagId;
        public int TagId
        {
            get
            {
                return _tagId;
            }
            set
            {
                _tagId = value;
                OnPropertyChanged();
            }
        }

        TimeSpan _beginn;
        public TimeSpan Beginn
        {
            get
            {
                return _beginn;
            }
            set
            {
                _beginn = value;
                OnPropertyChanged();
            }
        }

        TimeSpan _ende;
        public TimeSpan Ende
        {
            get
            {
                return _ende;
            }
            set
            {
                _ende = value;
                OnPropertyChanged();
            }
        }

        public Schichtzeit()
        {

        }
    }
}
