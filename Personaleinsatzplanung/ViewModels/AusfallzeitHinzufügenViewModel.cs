using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personaleinsatzplanung.SQL;
using MySql.Data.MySqlClient;
using Telerik.Windows.Controls;
using Personaleinsatzplanung.Models;

namespace Personaleinsatzplanung.ViewModels
{
    public class AusfallzeitHinzufügenViewModel
    {

        ObservableCollection<MitarbeiterViewModel> _mitarbeiter = new ObservableCollection<MitarbeiterViewModel>();
        public ObservableCollection<MitarbeiterViewModel> MitarbeiterList
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

        public AusfallzeitHinzufügenViewModel(MySQLHandler sql)
        {
            //MySqlDataReader reader = sql.Select(Mitarbeiter.Table, MySQLHandler.AppendWithCommas(Mitarbeiter.FieldId, Mitarbeiter.FieldKennung, Mitarbeiter.FieldName, Mitarbeiter.FieldVorname, Mitarbeiter.FieldFähigkeiten));

            //while (reader.Read())
            //{
            //    Mitarbeiter mitarbeiter = new Mitarbeiter();
            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        object val = reader.GetValue(i);
            //        string name = reader.GetName(i);
            //        if (name == Mitarbeiter.FieldId) mitarbeiter.Id = (int)val;
            //        else if (name == Mitarbeiter.FieldKennung) mitarbeiter.Kennung = (string)val;
            //        else if (name == Mitarbeiter.FieldName) mitarbeiter.Name = (string)val;
            //        else if (name == Mitarbeiter.FieldVorname) mitarbeiter.Vorname = (string)val;
            //        else if (name == Mitarbeiter.FieldFähigkeiten) mitarbeiter.Fähigkeiten = (string)val;
            //    }
            //    MitarbeiterList.Add(new MitarbeiterViewModel(mitarbeiter));
            //}
            //reader.Close();
        }
    }
}
