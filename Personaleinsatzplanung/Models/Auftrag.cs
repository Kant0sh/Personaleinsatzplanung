using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Auftrag : Model
    {
        
        public static string Table
        {
            get
            {
                return Settings["auftrag_table"];
            }
        }

        public static string FieldId
        {
            get
            {
                return Settings["auftrag_id"];
            }
        }

        public static string FieldAuftraggeber
        {
            get
            {
                return Settings["auftrag_auftraggeber"];
            }
        }

        public static string FieldAuftragsart
        {
            get
            {
                return Settings["auftrag_auftragsart"];
            }
        }

        public static string FieldSollzeit
        {
            get
            {
                return Settings["auftrag_sollzeit"];
            }
        }

        public static string FieldBezeichnung
        {
            get
            {
                return Settings["auftrag_bezeichnung"];
            }
        }

        public static string FieldBeschreibung
        {
            get
            {
                return Settings["auftrag_beschreibung"];
            }
        }

        public static string FieldStatus
        {
            get
            {
                return Settings["auftrag_status"];
            }
        }

        public static string FieldStartTermin
        {
            get
            {
                return Settings["auftrag_starttermin"];
            }
        }

        public static string FieldEndTermin
        {
            get
            {
                return Settings["auftrag_endtermin"];
            }
        }

        public static string FieldAuftragsEndTermin
        {
            get
            {
                return Settings["auftrag_auftragsendtermin"];
            }
        }



        public Auftrag() { }

        public Auftrag(int Id, Auftraggeber Auftraggeber, Auftragsart Auftragsart, Sollzeit Sollzeit, string Bezeichnung, string Beschreibung, int status, DateTime StartTermin, DateTime EndTermin, DateTime AuftragsEndTermin, bool ausfall)
        {

        }
    }
}
