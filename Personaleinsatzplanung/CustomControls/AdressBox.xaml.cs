using Personaleinsatzplanung.ViewModels;
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
    /// Interaction logic for AdressBox.xaml
    /// </summary>
    public partial class AdressBox : UserControl
    {

        public static readonly DependencyProperty LabelWidthProperty = DependencyProperty.Register("LabelWidth", typeof(double), typeof(AdressBox));
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

        public static readonly DependencyProperty TextBoxMarginProperty = DependencyProperty.Register("TextBoxMargin", typeof(Thickness), typeof(AdressBox));
        public Thickness TextBoxMargin
        {
            get
            {
                return (Thickness)GetValue(TextBoxMarginProperty);
            }
            set
            {
                SetValue(TextBoxMarginProperty, value);
            }
        }

        Thickness _lastTextBoxMargin = new Thickness();
        public Thickness LastTextBoxMargin
        {
            get
            {
                if (ShowZusatz) return (Thickness)GetValue(TextBoxMarginProperty);
                else return _lastTextBoxMargin;
            }
            set
            {
                _lastTextBoxMargin = value;
            }
        }

        public double TextBoxMarginBot
        {
            get
            {
                return TextBoxMargin.Bottom;
            }
            set
            {
                Thickness tmpMar = new Thickness();
                tmpMar.Bottom = value;
                TextBoxMargin = tmpMar;
            }
        }

        public static readonly DependencyProperty ShowLandProperty = DependencyProperty.Register("ShowLand", typeof(bool), typeof(AdressBox));
        public bool ShowLand
        {
            get
            {
                return (bool)GetValue(ShowLandProperty);
            }
            set
            {
                SetValue(ShowLandProperty, value);
                if (!value) LandVisibility = Visibility.Collapsed;
            }
        }

        Visibility _landVisibility;
        public Visibility LandVisibility
        {
            get
            {
                return _landVisibility;
            }
            set
            {
                _landVisibility = value;
            }
        }

        public static readonly DependencyProperty ShowZusatzProperty = DependencyProperty.Register("ShowZusatz", typeof(bool), typeof(AdressBox));
        public bool ShowZusatz
        {
            get
            {
                return (bool)GetValue(ShowZusatzProperty);
            }
            set
            {
                SetValue(ShowZusatzProperty, value);
                if (!value) ZusatzVisibility = Visibility.Collapsed;
            }
        }

        Visibility _zusatzVisibility;
        public Visibility ZusatzVisibility
        {
            get
            {
                return _zusatzVisibility;
            }
            set
            {
                _zusatzVisibility = value;
            }
        }

        public AdressBox()
        {
            InitializeComponent();
        }
    }
}
