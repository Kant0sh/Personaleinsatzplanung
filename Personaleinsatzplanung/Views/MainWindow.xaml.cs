using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Personaleinsatzplanung.SQL;
using System.Configuration;
using Telerik.Windows.Controls;
using Personaleinsatzplanung.Models;

namespace Personaleinsatzplanung.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MySQLHandler sql = new MySQLHandler("127.0.0.1", "root", "password", "pep");
            OdbcHandler sqlOdbc = new OdbcHandler("AUPOSGLAS");
            //new AusfallzeitHinzufügen(sql).Show();
            //new SchichtmodellErstellen(sql).Show();
            //new MitarbeiterErfassen(sql).Show();
            //Close();
        }
    }
}
