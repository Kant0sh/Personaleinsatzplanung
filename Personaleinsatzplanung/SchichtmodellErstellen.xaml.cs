using Personaleinsatzplanung.CustomControls;
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
    /// Interaction logic for SchichtmodellErstellen.xaml
    /// </summary>
    public partial class SchichtmodellErstellen : Window
    {
        public SchichtmodellErstellen()
        {
            InitializeComponent();
            Loaded += SchichtmodellErstellen_Loaded;
        }

        private void SchichtmodellErstellen_Loaded(object sender, RoutedEventArgs e)
        {
            string[] days = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;
            string[] rows = new string[days.Length + 2];
            days.CopyTo(rows, 0);
            rows[rows.Length - 2] = "Wochentage";
            rows[rows.Length - 1] = "Werktage";
            foreach(string rowName in rows)
            {
                LabelledStackPanel panel = new LabelledStackPanel();
                panel.LabelText = rowName + ":";
                panel.Orientation = Orientation.Horizontal;
                Thickness mar = new Thickness();
                mar.Left = 10;
                mar.Right = 10;
                mar.Top = 10;
                panel.Margin = mar;
                mainStack.Children.Add(panel);
                panel.Children.Add(new TimePicker_VonBis_Appending());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
