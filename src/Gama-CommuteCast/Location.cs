using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama_CommuteCast
{
    internal class Location
    {
        // Attributes
        private int _id;
        private double _latitude;
        private double _longitude;

        // Constructor
        public Location(int id, double latitude, double longitude)
        {
            _id  = id;
            _latitude = latitude;
            _longitude = longitude;
        }

        // Attribute Encapsulation
        public int Id { get { return _id; } }
        public double Latitude 
        { 
            get { return _latitude;}  
            set { _latitude = value; }
        }
        public double Longitude
        {
            get { return _longitude;}
            set { _longitude = value; }
        }

    }
}
