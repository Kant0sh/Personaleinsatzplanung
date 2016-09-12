using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Personaleinsatzplanung.ViewModels
{
    public class AdressBoxViewModel
    {

        double _labelWidth;
        public double LabelWidth
        {
            get
            {
                return _labelWidth;
            }
            set
            {
                _labelWidth = value;
            }
        }

        public Thickness TextBoxMargin = new Thickness();

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

        public bool ShowLand = true;

        public bool ShowZusatz = true;

        public AdressBoxViewModel() { }

        public AdressBoxViewModel(double LabelWidth, bool ShowLand, bool ShowZusatz, double TextBoxMarginBot)
        {
            this.LabelWidth = LabelWidth;
            this.ShowLand = ShowLand;
            this.ShowZusatz = ShowZusatz;
            if (TextBoxMarginBot >= 0) this.TextBoxMarginBot = TextBoxMarginBot;
            else this.TextBoxMarginBot = 5;
        }
    }
}
