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
    /// Interaction logic for LabelledTextBox.xaml
    /// </summary>
    public partial class LabelledTextBox : UserControl
    {

        public string LabelText
        {
            get
            {
                return lbl.Content.ToString();
            }
            set
            {
                lbl.Content = value;
            }
        }

        public LabelledTextBox()
        {
            InitializeComponent();
            textBox.Loaded += textBox_Loaded;
        }

        private void textBox_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(textBox.ActualHeight);
            if(textBox.ActualHeight > textBox.MinHeight)
            {
                textBox.TextWrapping = TextWrapping.Wrap;
                textBox.AcceptsReturn = true;
            }
        }
    }
}
