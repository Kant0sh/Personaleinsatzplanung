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
using Telerik.Windows.Controls;
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

        public static readonly DependencyProperty SelectedItemProperty = RadAutoCompleteBox.SelectedItemProperty.AddOwner(typeof(LabelledAutoCompleteBox));

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

        public static readonly DependencyProperty ItemsSourceProperty = RadAutoCompleteBox.ItemsSourceProperty.AddOwner(typeof(LabelledAutoCompleteBox));

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

        public static readonly DependencyProperty DisplayMemberPathProperty = RadAutoCompleteBox.DisplayMemberPathProperty.AddOwner(typeof(LabelledAutoCompleteBox));

        public string DisplayMemberPath
        {
            get
            {
                return (string)GetValue(DisplayMemberPathProperty);
            }
            set
            {
                SetValue(DisplayMemberPathProperty, (string)value);
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
