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
    /// Interaction logic for LabelledRadioButton.xaml
    /// </summary>
    public partial class LabelledRadioButton : UserControl
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

        public string GroupName { get { return radioButton.GroupName; } set { radioButton.GroupName = value; } }
        public bool? IsChecked { get { return radioButton.IsChecked; } set { radioButton.IsChecked = value; } }

        public LabelledRadioButton()
        {
            InitializeComponent();
            Loaded += LabelledRadioButton_Loaded;
        }

        private void LabelledRadioButton_Loaded(object sender, RoutedEventArgs e)
        {
            radioButton.Checked += RadioButton_Checked;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OnChecked(sender, e);
        }

        bool click;
        private void lbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            click = true;
        }

        private void lbl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (click)
            {
                radioButton.IsChecked = true;
            }
            click = false;
        }

        private void lbl_MouseLeave(object sender, MouseEventArgs e)
        {
            click = false;
        }

        public delegate void CheckedEvent(object sender, RoutedEventArgs e);
        public event CheckedEvent Checked;
        protected virtual void OnChecked(object sender, RoutedEventArgs e)
        {
            Checked?.Invoke(sender, e);
        }
    }
}
