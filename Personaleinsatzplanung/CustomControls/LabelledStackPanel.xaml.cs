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
    /// Interaction logic for LabelledStackPanel.xaml
    /// </summary>
    public partial class LabelledStackPanel : StackPanel
    {

        private Label lbl = new Label();
        public string LabelText
        {
            get
            {
                return lbl.Content.ToString();
            }
            set
            {
                lbl.Content = value;
            }
        }//Height="20" Padding="3,0" VerticalContentAlignment="Center" VerticalAlignment="Top"

        public LabelledStackPanel()
        {
            lbl.Height = (double)TryFindResource("InputBoxMinHeight");
            lbl.Padding = new Thickness(3,0,3,0);
            lbl.VerticalContentAlignment = VerticalAlignment.Center;
            lbl.VerticalAlignment = VerticalAlignment.Top;
            InitializeComponent();
            Loaded += LabelledStackPanel_Loaded;
        }

        private void LabelledStackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            Children.Insert(0, lbl);
        }
    }
}
