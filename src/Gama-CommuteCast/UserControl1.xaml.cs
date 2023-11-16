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
        private void DragMap()
        {
            MessageBox.Show("Not Implemented Yet");
            throw new NotImplementedException();
        }

        // When the mouse is clicked and dragged, drag the map accordingly
        private void Map_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMap();
            }
        }

        private void ButtonMap_Click(object sender, RoutedEventArgs e)
        {
            // Change the map style to road
            Map.Mode = new Microsoft.Maps.MapControl.WPF.RoadMode();
        }

        private void ButtonTypeABus_Click(object sender, RoutedEventArgs e)
        {
            // Zoom to the center of UGM
            Map.Center = new Microsoft.Maps.MapControl.WPF.Location(-7.771423, 110.377733);
            Map.ZoomLevel = 15;

            // Add a pushpin to the center of UGM
            Microsoft.Maps.MapControl.WPF.Pushpin pin = new Microsoft.Maps.MapControl.WPF.Pushpin();
            pin.Location = new Microsoft.Maps.MapControl.WPF.Location(-7.771423, 110.377733);
            Map.Children.Add(pin);
            Map.ZoomLevel = 15;
        }

        private void ButtonSatellite_Click(object sender, RoutedEventArgs e)
        {
            // Change the map style to satellite
            Map.Mode = new Microsoft.Maps.MapControl.WPF.AerialMode(true);
        }

        private void ButtonTypeBBus_Click(object sender, RoutedEventArgs e)
        {
            // Zoom to the center of Faculty of Medicine UGM
            Map.Center = new Microsoft.Maps.MapControl.WPF.Location(-7.772160, 110.377733);
            Map.ZoomLevel = 15;

            // Add a pushpin to the center of Faculty of Medicine UGM
            Microsoft.Maps.MapControl.WPF.Pushpin pin = new Microsoft.Maps.MapControl.WPF.Pushpin();
            pin.Location = new Microsoft.Maps.MapControl.WPF.Location(-7.772160, 110.377733);
            Map.Children.Add(pin);
            Map.ZoomLevel = 15;
        }

        private void ButtonZoomIn_Click(object sender, RoutedEventArgs e)
        {
            // Zoom in
            Map.ZoomLevel += 1;
        }

        private void ButtonZoomOut_Click(object sender, RoutedEventArgs e)
        {
            // Zoom out
            Map.ZoomLevel -= 1;
        }
    }
}
