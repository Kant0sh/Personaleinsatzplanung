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

namespace Personaleinsatzplanung.CustomControls
{
    /// <summary>
    /// Interaction logic for LabelledComboBox.xaml
    /// </summary>
    public partial class LabelledComboBox : UserControl
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

        public static readonly DependencyProperty ItemsSourceProperty = ComboBox.ItemsSourceProperty.AddOwner(typeof(LabelledComboBox));
        public IEnumerable ItemsSource
        {
            get
            {
                return GetValue(ItemsSourceProperty) as IEnumerable;
            }
            set
            {
                SetValue(ItemsSourceProperty, value as IEnumerable);
            }
        }

        public static readonly DependencyProperty SelectedItemProperty = ComboBox.SelectedItemProperty.AddOwner(typeof(LabelledComboBox));
        public object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        public LabelledComboBox()
        {
            InitializeComponent();
        }
    }
}
