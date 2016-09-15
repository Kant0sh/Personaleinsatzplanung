using Personaleinsatzplanung.Models;
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

namespace Personaleinsatzplanung.CustomControls.Timeline
{
    /// <summary>
    /// Interaction logic for TimelineRowMitarbeiter.xaml
    /// </summary>
    public partial class TimelineRowMitarbeiter : UserControl
    {
        public static readonly DependencyProperty MitarbeiterProperty = DependencyProperty.Register("Mitarbeiter", typeof(MitarbeiterViewModel), typeof(TimelineRowMitarbeiter));
        public MitarbeiterViewModel Mitarbeiter
        {
            get
            {
                return GetValue(MitarbeiterProperty) as MitarbeiterViewModel;
            }
            set
            {
                SetValue(MitarbeiterProperty, value);
            }
        }

        public string MitarbeiterName
        {
            get
            {
                return Mitarbeiter.GanzerName;
            }
        }

        public string MitarbeiterFähigkeiten
        {
            get
            {
                return Mitarbeiter.Fähigkeiten;
            }
        }

        public string MitarbeiterKennung
        {
            get
            {
                return Mitarbeiter.Kennung;
            }
        }

        public static readonly DependencyProperty IsMitarbeiterPinnedProperty = DependencyProperty.Register("IsMitarbeiterPinned", typeof(bool), typeof(TimelineRowMitarbeiter));
        public bool IsMitarbeiterPinned
        {
            get
            {
                return (bool)GetValue(IsMitarbeiterPinnedProperty);
            }
            set
            {
                SetValue(IsMitarbeiterPinnedProperty, value);
            }
        }

        public TimelineRowMitarbeiter()
        {
            InitializeComponent();
        }
    }
}
