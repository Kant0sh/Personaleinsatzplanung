using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Rufnummer : Model
    {
        string _nummer;
        public string Nummer
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

        RufnummerTyp _typ;
        public RufnummerTyp Typ
        {
            get
            {
                return _typ;
            }
            set
            {
                _typ = value;
                OnPropertyChanged();
            }
        }

        public Rufnummer() { }

        public Rufnummer(string Nummer, RufnummerTyp Typ)
        {
            this.Nummer = Nummer;
            this.Typ = Typ;
        }
    }

    public enum RufnummerTyp
    {
        FestnetzPrivat,
        FestnetzIntern,
        FestnetzBüro,
        Mobil,
        MobilDienst,
        Fax,
        FaxIntern,
        FaxBüro
    }
}
