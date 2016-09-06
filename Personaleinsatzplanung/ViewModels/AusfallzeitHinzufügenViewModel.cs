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
    class AusfallzeitHinzufügenViewModel : ViewModel
    {

        public ObservableCollection<MitarbeiterViewModel> Mitarbeiter = new ObservableCollection<MitarbeiterViewModel>();

        public AusfallzeitHinzufügenViewModel(MySQLHandler sql)
        {
            if (sql.Connection.State != System.Data.ConnectionState.Open) sql.Connect();
            MySqlDataReader reader = sql.SelectAll("mitarbeiter");

            while (reader.Read())
            {
                Mitarbeiter mitarbeiter = new Mitarbeiter();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    object val = reader.GetValue(i);
                    switch (reader.GetName(i))
                    {
                        case "id":
                            mitarbeiter.Id = (int)val;
                            break;
                        case "name":
                            mitarbeiter.Name = (string)val;
                            break;
                        case "vorname":
                            mitarbeiter.Vorname = (string)val;
                            break;
                        case "faehigkeiten":
                            mitarbeiter.Fähigkeiten = (string)val;
                            break;
                    }
                }
                Mitarbeiter.Add(new MitarbeiterViewModel(mitarbeiter));
            }
            reader.Close();
        }

    }
}
