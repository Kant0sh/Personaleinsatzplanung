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
    /// Interaction logic for TimelineRow.xaml
    /// </summary>
    public partial class TimelineRow : UserControl
    {
        private void Init()
        {
            InitializeComponent();
        }

        public TimelineRow()
        {
            Init();
        }

        public TimelineRow(Mitarbeiter mitarbeiter, TimelineRowTimeScale scale)
        {
            DataContext = new TimelineRowViewModel(mitarbeiter, scale);
            Init();
        }
    }

    public enum TimelineRowTimeScale
    {
        Week,
        Month
    }
}
