using MySql.Data.MySqlClient;
using Personaleinsatzplanung.SQL;
using Personaleinsatzplanung.ViewModels;
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

namespace Personaleinsatzplanung.Views
{
    /// <summary>
    /// Interaction logic for MitarbeiterErfassen.xaml
    /// </summary>
    public partial class MitarbeiterErfassen : Window
    {
        public MitarbeiterErfassen(MySQLHandler Sql)
        {
            DataContext = new MitarbeiterErfassenViewModel(Sql);
            InitializeComponent();
        }
    }
}
