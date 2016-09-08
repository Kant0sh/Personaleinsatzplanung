using MySql.Data.MySqlClient;
using Personaleinsatzplanung.ViewModels;
using Personaleinsatzplanung.SQL;
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
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Personaleinsatzplanung.Views
{
    /// <summary>
    /// Interaction logic for AusfallzeitHinzufügen.xaml
    /// </summary>
    public partial class AusfallzeitHinzufügen : Window
    {
        public AusfallzeitHinzufügen(MySQLHandler sql)
        {
            InitializeComponent();
            DataContext = new AusfallzeitHinzufügenViewModel(sql);
        }
    }
}
