using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personaleinsatzplanung.SQL;
using MySql.Data.MySqlClient;
using Telerik.Windows.Controls;

namespace Personaleinsatzplanung.Data
{
    class AusfallzeitHinzufügenViewModel : BaseViewModel
    {

        private ObservableCollection<MitarbeiterViewModel> _mitarbeiter = new ObservableCollection<MitarbeiterViewModel>();
        public ObservableCollection<MitarbeiterViewModel> Mitarbeiter
        {
            get
            {
                return _mitarbeiter;
            }
            set
            {
                _mitarbeiter = value;
                OnPropertyChanged();
            }
        }

        public AusfallzeitHinzufügenViewModel(MySQLHandler sql)
        {
            if (sql.Connection.State != System.Data.ConnectionState.Open) sql.Connect();
            MySqlDataReader reader = sql.SelectAll("mitarbeiter");

            while (reader.Read())
            {
                MitarbeiterViewModel mitarbeiter = new MitarbeiterViewModel();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    object val = reader.GetValue(i);
                    switch (reader.GetName(i))
                    {
                        case "id":
                            mitarbeiter.Nummer = (int)val;
                            break;
                        case "name":
                            mitarbeiter.Nachname = (string)val;
                            break;
                        case "vorname":
                            mitarbeiter.Vorname = (string)val;
                            break;
                        case "faehigkeiten":
                            mitarbeiter.Fähigkeiten = (string)val;
                            break;
                    }
                }
                Mitarbeiter.Add(mitarbeiter);
            }
            reader.Close();
        }

    }
}
