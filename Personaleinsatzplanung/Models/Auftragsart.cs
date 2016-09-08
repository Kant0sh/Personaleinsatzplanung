using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Auftragsart : Model
    {

        public static string Table
        {
            get
            {
                return Settings["auftragsart_table"];
            }
        }

        public static string FieldId
        {
            get
            {
                return Settings["auftragsart_id"];
            }
        }

        public static string FieldBezeichnung
        {
            get
            {
                return Settings["auftragsart_bezeichnung"];
            }
        }

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
            }
        }

        public Auftragsart() { }

        public Auftragsart(int Id, string Bezeichnung)
        {
            this.Id = Id;
            this.Bezeichnung = Bezeichnung;
        }
    }
}
