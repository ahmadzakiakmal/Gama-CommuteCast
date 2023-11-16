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

namespace Gama_CommuteCast
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            // Zoom to the center of Faculty of Engineering UGM
            Map.Center = new Microsoft.Maps.MapControl.WPF.Location(-7.765690, 110.373501);
            Map.ZoomLevel = 15;

            // Add a pushpin to the center of Faculty of Engineering UGM
            Microsoft.Maps.MapControl.WPF.Pushpin pin = new Microsoft.Maps.MapControl.WPF.Pushpin();
            pin.Location = new Microsoft.Maps.MapControl.WPF.Location(-7.765690, 110.373501);
            Map.Children.Add(pin);
            Map.ZoomLevel = 15;

        }

        private void ButtonMap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonTypeABus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSatellite_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonTypeBBus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonZoomIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonZoomOut_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
