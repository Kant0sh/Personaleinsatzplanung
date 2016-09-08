using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Models
{
    public class Sollzeit : Model
    {

        Decimal _stunden;
        public Decimal Stunden
        {
            get
            {
                return _stunden;
            }
            set
            {
                _stunden = value;
            }
        }

        TimeSpan _zeitraum;
        public TimeSpan Zeitraum
        {
            get
            {
                return _zeitraum;
            }
            set
            {
                _zeitraum = value;
            }
        }

        public Sollzeit()
        {
            SubscribeToPropertyChanged();
        }

        public Sollzeit(Decimal Stunden)
        {
            SubscribeToPropertyChanged();
            this.Stunden = Stunden;
        }

        public Sollzeit(TimeSpan Zeitraum)
        {
            SubscribeToPropertyChanged();
            this.Zeitraum = Zeitraum;
        }

        private void SubscribeToPropertyChanged()
        {
            this.PropertyChanged += Sollzeit_PropertyChanged;
        }

        private void Sollzeit_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Zeitraum":
                    UpdateStunden();
                    break;
                case "Stunden":
                    UpdateZeitraum();
                    break;
            }
        }

        private void UpdateStunden()
        {
            Stunden = Convert.ToDecimal(Zeitraum.TotalHours);
        }

        private void UpdateZeitraum()
        {
            Zeitraum = TimeSpan.FromHours(Convert.ToDouble(Stunden));
        }
    }
}
