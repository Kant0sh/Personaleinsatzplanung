using Personaleinsatzplanung.CustomControls.Timeline;
using Personaleinsatzplanung.Models;
using Personaleinsatzplanung.SQL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.ViewModels
{
    class MainWindowViewModel
    {
        ObservableCollection<TimelineRow> _timelineRows;
        public ObservableCollection<TimelineRow> TimelineRows
        {
            get
            {
                return _timelineRows;
            }
            set
            {
                _timelineRows = value;
            }
        }

        public MainWindowViewModel(ISqlHandler sql)
        {
            TimelineRows = new ObservableCollection<TimelineRow>();
            LoadMitarbeiter(sql);
        }

        private async void LoadMitarbeiter(ISqlHandler sql)
        {
            List<Mitarbeiter> allMitarbeiter = await Mitarbeiter.LoadAllAsync(new string[] { Mitarbeiter.FieldId, Mitarbeiter.FieldName, Mitarbeiter.FieldVorname, Mitarbeiter.FieldKennung, Mitarbeiter.FieldFähigkeiten }, sql);
            foreach(Mitarbeiter mit in allMitarbeiter)
            {
                TimelineRows.Add(new TimelineRow(mit, TimelineRowTimeScale.Week));
            }
        }
    }
}
