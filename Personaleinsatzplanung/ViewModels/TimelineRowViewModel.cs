using Personaleinsatzplanung.CustomControls.Timeline;
using Personaleinsatzplanung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.ViewModels
{
    class TimelineRowViewModel
    {
        MitarbeiterViewModel _mitarbeiter;
        public MitarbeiterViewModel Mitarbeiter
        {
            get
            {
                return _mitarbeiter;
            }
            set
            {
                _mitarbeiter = value;
            }
        }

        TimelineRowTimeScale _scale;
        public TimelineRowTimeScale Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
            }
        }

        List<TimelineRowTime> _timelineRowTimes = new List<TimelineRowTime>();
        public List<TimelineRowTime> TimelineRowTimes
        {
            get
            {
                return _timelineRowTimes;
            }
            set
            {
                _timelineRowTimes = value;
            }
        } 

        public TimelineRowViewModel() { }

        public TimelineRowViewModel(Mitarbeiter mitarbeiter, TimelineRowTimeScale scale)
        {
            Mitarbeiter = new MitarbeiterViewModel(mitarbeiter);
            Scale = scale;
            GenerateTimes(7);
        }

        public void GenerateTimes(int Count)
        {
            for(int i = 0; i < Count; i++)
            {
                TimelineRowTimes.Add(new TimelineRowDay());
            }
        }
    }
}
