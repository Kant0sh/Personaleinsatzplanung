using System;
using System.Collections;
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
using Telerik.Windows.Controls.Primitives;

namespace Personaleinsatzplanung.CustomControls
{
    /// <summary>
    /// Interaction logic for LabelledTextBox.xaml
    /// </summary>
    public partial class LabelledAutoCompleteBox : UserControl
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

        public double LabelWidth
        {
            get
            {
                return (double)lbl.Width;
            }
            set
            {
                lbl.Width = value;
            }
        }

        public object Selection
        {
            get
            {
                return textBox.SelectedItem;
            }
        }

        public IEnumerable ItemsSource
        {
            get
            {
                return textBox.ItemsSource;
            }
            set
            {
                textBox.ItemsSource = value;
            }
        }

        public AutoCompleteSelectionMode SelectionMode
        {
            get
            {
                return textBox.SelectionMode;
            }
            set
            {
                textBox.SelectionMode = value;
            }
        }

        public LabelledAutoCompleteBox()
        {
            InitializeComponent();
        }
    }
}
