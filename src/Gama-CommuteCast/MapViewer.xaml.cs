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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;

namespace Gama_CommuteCast
{
    /// <summary>
    /// Interaction logic for MapViewer.xaml
    /// </summary>

    /*Bus dynamic array*/
    internal class BusList
    {
        // Attributes
        private Bus[] _busArray;
        private int _size;

        // Constructor
        public BusList(int size)
        {
            _size = size;
            _busArray = new Bus[_size];
        }

        // Attribute Encapsulation
        public Bus[] BusArray { get { return _busArray; } }
        public int Size { get { return _size; } }

        // Methods
        public void AddBus(Bus bus)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_busArray[i] == null)
                {
                    _busArray[i] = bus;
                    break;
                }
            }
        }
    }

    public partial class MapViewer : Page
    {
        /*Bus List*/
        private BusList _busList = new BusList(10);

        /*Dummy Bus Data*/
        private Bus _bus1 = new Bus(1, new Location(1, 0, 0), true);
        private Bus _bus2 = new Bus(2, new Location(2, 0, 0), true);

        public MapViewer()
        {
            InitializeComponent();

            // Set the map provider (OpenStreetMap)
            gmapControl.MapProvider = GMapProviders.OpenStreetMap;

            // Set the initial map position and zoom level
            gmapControl.Position = new PointLatLng(52.5200, 13.4050); // Berlin, Germany
            gmapControl.Zoom = 12;

        }

        public void updateMapData()
        {
            /*Update all of the Bus location by calling Bus.UpdateLocation()*/
            for (int i = 0; i < _busList.Size; i++)
            {
                if (_busList.BusArray[i] != null)
                {
                    _busList.BusArray[i].UpdateLocation();
                }
            }
        }
    }
}
