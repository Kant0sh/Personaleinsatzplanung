using Personaleinsatzplanung.Calendar;
using Personaleinsatzplanung.CustomControls;
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
    /// Interaction logic for SchichtmodellErstellen.xaml
    /// </summary>
    public partial class SchichtmodellErstellen : Window
    {

        MySQLHandler sql;

        public SchichtmodellErstellen(MySQLHandler sql)
        {
            this.sql = sql;
            InitializeComponent();
            Loaded += SchichtmodellErstellen_Loaded;
        }

        private void SchichtmodellErstellen_Loaded(object sender, RoutedEventArgs e)
        {
            string[] days = CalendarUtil.GetDayNames();
            string[] rows = new string[days.Length + 2];
            days.CopyTo(rows, 0);
            rows[rows.Length - 2] = "Wochentage";
            rows[rows.Length - 1] = "Werktage";
            foreach(string rowName in rows)
            {
                LabelledStackPanel panel = new LabelledStackPanel();
                panel.LabelText = rowName + ":";
                panel.LabelWidth = 100;
                panel.Orientation = Orientation.Horizontal;
                Thickness mar = new Thickness();
                mar.Left = 10;
                mar.Right = 10;
                mar.Top = 10;
                panel.Margin = mar;
                mainStack.Children.Add(panel);
                panel.Children.Add(new TimePicker_VonBis_Appending());
            }
            mainStack.Children[7].Visibility = Visibility.Collapsed;
            mainStack.Children[8].Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Trim() == string.Empty) return;
            sql.Insert("schichten", "bezeichnung", textBox.Text.Trim());
            int schichtId = sql.SelectLastInt("schichten", "schicht_id");
            foreach (LabelledStackPanel panel in mainStack.Children)
            {
                if (panel.Visibility == Visibility.Visible)
                {
                    int i = mainStack.Children.IndexOf(panel);
                    for (int j = 1; j < panel.Children.Count; j++)
                    {
                        TimePicker_VonBis_Appending tp = panel.Children[j] as TimePicker_VonBis_Appending;
                        if (tp.Von != null && tp.Bis != null) sql.Insert("schichtzeiten", "schicht_id, tag_index, beginn, ende", schichtId, i, sql.GetMySQLFormattedTime((TimeSpan)tp.Von), sql.GetMySQLFormattedTime(((TimeSpan)tp.Bis)));
                    }
                }
            }
        }

        private void RadioButton0_Checked(object sender, RoutedEventArgs e)
        {
            // Einzeln Erstellen
            foreach (LabelledStackPanel panel in mainStack.Children)
            {
                panel.Visibility = Visibility.Visible;
            }
            mainStack.Children[7].Visibility = Visibility.Collapsed;
            mainStack.Children[8].Visibility = Visibility.Collapsed;
        }
        
        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            // Wochentage
            foreach (LabelledStackPanel panel in mainStack.Children)
            {
                panel.Visibility = Visibility.Collapsed;
            }
            mainStack.Children[7].Visibility = Visibility.Visible;
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            // Werktage
            foreach (LabelledStackPanel panel in mainStack.Children)
            {
                panel.Visibility = Visibility.Collapsed;
            }
            mainStack.Children[5].Visibility = Visibility.Visible;
            mainStack.Children[6].Visibility = Visibility.Visible;
            mainStack.Children[8].Visibility = Visibility.Visible;
        }
    }
}
