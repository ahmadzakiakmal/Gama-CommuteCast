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
using System.IO.Ports;


namespace Gama_CommuteCast
{
    internal class InputUnit
    {
        static SerialPort _serialPort;
        static string _portName = "COM3";
        static int _baudRate = 115200;
        static Parity _parity = Parity.None;
        static int _dataBits = 8;
        static StopBits _stopBits = StopBits.One;
        static Handshake _handshake = Handshake.None;
        static bool _rtsEnable = true;
        static bool _dtrEnable = true;
        static int _readTimeout = 500;

        static InputUnit()
        {
            Console.WriteLine("Input Unit Starting...");
        }
        public static void Start()
        {
            _serialPort = new SerialPort(_portName, _baudRate, _parity, _dataBits, _stopBits);
            _serialPort.Handshake = _handshake;
            _serialPort.RtsEnable = _rtsEnable;
            _serialPort.DtrEnable = _dtrEnable;
            _serialPort.ReadTimeout = _readTimeout;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            _serialPort.Open();
        }
        public static void Stop()
        {
            _serialPort.Close();
        }
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadLine();
            Console.WriteLine(data);
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MapBtn_Click(object sender, RoutedEventArgs e)
        {
            /* Navigate to MapViewer.xaml */
            MainFrame.Navigate(new MapViewer());
        }

        private void AirPollutionBtn_Click(object sender, RoutedEventArgs e)
        {
            /* Navigate to AirPollutionViewer.xaml */
            MainFrame.Navigate(new AirPollutionViewer());
        }

        private void WeatherBtn_Click(object sender, RoutedEventArgs e)
        {
            /* Navigate to WeatherViewer.xaml */
            MainFrame.Navigate(new WeatherViewer());
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            /* Navigate to UserViewer.xaml */
            /*MainFrame.Navigate(new UserViewer());*/
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
