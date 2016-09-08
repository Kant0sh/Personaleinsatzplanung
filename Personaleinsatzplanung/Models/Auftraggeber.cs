using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Auftraggeber : Model
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
            }
        }



        public Auftraggeber() { }

        //public Auftraggeber()
        //{

        //}
    }
}
