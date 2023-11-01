using System;
using System.Collections.Generic;
using System.IO.Ports;
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
    /// <summary>
    /// Interaction logic for UnitInput.xaml
    /// </summary>
    public partial class UnitInput : Page
    {
        private string _portName = "COM3";
        private int _baudRate = 115200;
        public UnitInput()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UnitComboBox.SelectedIndex >= 0)
            {
                _portName = UnitComboBox.SelectedItem.ToString();
                
            }
        }
    }

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

        InputUnit(string portName, int baudRate)
        {
            _portName = portName;
            _baudRate = baudRate;
        }

        public void OpenPort()
        {
            _serialPort = new SerialPort(_portName, _baudRate, _parity, _dataBits, _stopBits);
            _serialPort.Handshake = _handshake;
            _serialPort.RtsEnable = _rtsEnable;
            _serialPort.DtrEnable = _dtrEnable;
            _serialPort.ReadTimeout = _readTimeout;
            _serialPort.Open();
        }

        public void ClosePort()
        {
            _serialPort.Close();
        }

        public bool IsConnected()
        {
            return _serialPort.IsOpen;
        }

        public void ReadData()
        {
            try
            {
                string message = _serialPort.ReadLine();
                Console.WriteLine(message);
            }
            catch (TimeoutException) { }
        }

        public void WriteData(string message)
        {
            _serialPort.WriteLine(message);
        }

    }
}
