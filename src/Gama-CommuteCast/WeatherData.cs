using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama_CommuteCast
{
    internal class WeatherData
    {
        private double _temperature = 0;
        private double _humidity = 75.0;
        private int _id;

        public double Temperature { get { return _temperature; } }
        public double Humidity { get { return _humidity; } }
        public int Id { get { return _id; } }

        public WeatherData(int id)
        {
            //! TODO: Complete WeatherData Constructor
            _id = id;
        }

        public void updateWeatherData()
        {
            //! TODO: Complete updateWeatherData Method
            /*Read data from API*/
            /*Update attributes*/
        }

        public void setTemperature(double temperature)
        {
            _temperature = temperature;
        }

        public void setHumidity(double humidity)
        {
            _humidity = humidity;
        }
    }
}
