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
using System.Windows.Threading;

namespace Gama_CommuteCast
{
    /// <summary>
    /// Interaction logic for WeatherViewer.xaml
    /// </summary>
    public partial class WeatherViewer : Page
    {
        private WeatherData _weatherData = new WeatherData(0);
        private DispatcherTimer timer;
        public WeatherViewer()
        {
            InitializeComponent();

            // Create and configure a timer to update weather data
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(3); // Update every 3 seconds
            timer.Start();
        }
        // Function to update weather data each time Timer_Tick is called
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update Weather Data
            // _weatherData.updateWeatherData();
            
            // Set random values for temperature and humidity
            _weatherData.setTemperature(new Random().Next(16, 40));
            _weatherData.setHumidity(new Random().Next(70, 100));

            // Update your UI with the new values
            temperatureLabel.Content = "Temp: " + _weatherData.Temperature.ToString() + "\u00b0";
            humidityLabel.Content = "Humidity: " + _weatherData.Humidity.ToString() + "%";
        }
    }
}
