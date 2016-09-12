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

        public static readonly DependencyProperty LabelWidthProperty = DependencyProperty.Register("LabelWidth", typeof(double), typeof(LabelledTextBox));

        public double LabelWidth
        {
            get
            {
                return (double)GetValue(LabelWidthProperty);
            }
            set
            {
                SetValue(LabelWidthProperty, value);
            }
        }

        public static readonly DependencyProperty TextProperty = TextBox.TextProperty.AddOwner(typeof(LabelledTextBox));

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public delegate void TextChangedEvent(object sender, TextChangedEventArgs e);
        public event TextChangedEvent TextChanged;
        protected virtual void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged?.Invoke(sender, e);
        }

        public LabelledTextBox()
        {
            InitializeComponent();
            textBox.Loaded += textBox_Loaded;
            textBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnTextChanged(sender, e);
        }

        private void textBox_Loaded(object sender, RoutedEventArgs e)
        {
            if(textBox.ActualHeight > textBox.MinHeight)
            {
                textBox.TextWrapping = TextWrapping.Wrap;
                textBox.AcceptsReturn = true;
            }
        }
    }
}
