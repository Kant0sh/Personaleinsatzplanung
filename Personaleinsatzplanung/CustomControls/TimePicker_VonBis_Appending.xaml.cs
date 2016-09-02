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

namespace Personaleinsatzplanung.CustomControls
{
    /// <summary>
    /// Interaction logic for LabelledTimePicker_VonBis.xaml
    /// </summary>
    public partial class TimePicker_VonBis_Appending : UserControl
    {
        public TimePicker_VonBis_Appending()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Parent is Panel)
            {
                Panel parPanel = Parent as Panel;
                TimePicker_VonBis_Appending tp = new TimePicker_VonBis_Appending();
                Thickness mar = new Thickness();
                mar.Left = 10;
                tp.Margin = mar;
                parPanel.Children.Add(tp);
            }
        }
    }
}
