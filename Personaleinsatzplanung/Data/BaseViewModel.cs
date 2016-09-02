using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Data
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string pCaller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pCaller));
        }
    }
}
