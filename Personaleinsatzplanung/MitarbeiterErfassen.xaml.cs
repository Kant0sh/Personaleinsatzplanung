using MySql.Data.MySqlClient;
using Personaleinsatzplanung.SQL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Personaleinsatzplanung
{
    /// <summary>
    /// Interaction logic for MitarbeiterErfassen.xaml
    /// </summary>
    public partial class MitarbeiterErfassen : Window
    {

        MySQLHandler sql;

        List<DataObject> schichten;
        List<string> schichtBez;
        public MitarbeiterErfassen(MySQLHandler sql)
        {
            this.sql = sql;
            InitializeComponent();
            schichten = new List<DataObject>();
            MySqlDataReader reader = sql.SelectAll("schichten");
            while (reader.Read())
            {
                DataObject data = new DataObject();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    data.SetData(reader.GetName(i), reader.GetValue(i));
                }
                schichten.Add(data);
            }
            reader.Close();
            schichtBez = new List<string>();
            for(int i = 0; i < schichten.Count; i++)
            {
                schichtBez.Add(schichten[i].GetData("bezeichnung").ToString());
            }
            schicht.ItemsSource = schichtBez;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sql.Insert("mitarbeiter", "mitarbeiterkennung, name, vorname, stadt, postleitzahl, straße, hausnummer, faehigkeiten, schicht_id, telefon, mobil, tel_intern, fax_intern, e_mail", kennung.Text.Trim(), name.Text.Trim(), vorname.Text.Trim(), stadt.Text.Trim(), plz.Text.Trim(), straße.Text.Trim(), hausnummer.Text.Trim(), faehigkeiten.Text.Trim(), schichten[schichtBez.IndexOf((string)schicht.Selection)].GetData("schicht_id"), telefon.Text.Trim(), mobil.Text.Trim(), tel_intern.Text.Trim(), fax_intern.Text.Trim(), e_mail.Text.Trim());
        }
    }
}
