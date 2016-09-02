using MySql.Data.MySqlClient;
using Personaleinsatzplanung.Data;
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

namespace Personaleinsatzplanung
{
    /// <summary>
    /// Interaction logic for AusfallzeitHinzufügen.xaml
    /// </summary>
    public partial class AusfallzeitHinzufügen : Window
    {
        public AusfallzeitHinzufügen(MySQLHandler sql)
        {
            StyleManager.ApplicationTheme = new Windows8Theme();
            AusfallzeitHinzufügenViewModel vm = new AusfallzeitHinzufügenViewModel(sql);
            vm.PropertyChanged += Vm_PropertyChanged;
            DataContext = new AusfallzeitHinzufügenViewModel(sql);
            InitializeComponent();
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }
    }
}
