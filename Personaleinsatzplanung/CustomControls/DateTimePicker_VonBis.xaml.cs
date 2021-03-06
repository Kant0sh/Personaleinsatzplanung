﻿using System;
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
    /// Interaction logic for LabelledTimePicker_VonBis.xaml
    /// </summary>
    public partial class DateTimePicker_VonBis : UserControl
    {

        public DateTime? Von
        {
            get
            {
                return von.SelectedValue;
            }
        }

        public DateTime? Bis
        {
            get
            {
                return bis.SelectedValue;
            }
        }

        public DateTimePicker_VonBis()
        {
            InitializeComponent();
        }
    }
}
