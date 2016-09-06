using Personaleinsatzplanung.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.ViewModels
{
    public class ViewModel
    {
        Model _model;
        public Model Model
        {
            get
            {
                return this._model;
            }
            set
            {
                this._model = value;
            }
        }
    }
}
