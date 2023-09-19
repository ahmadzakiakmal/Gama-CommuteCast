using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama_CommuteCast
{
    internal class Bus
    {
        // Attributes
        private int _id;
        private Location _location;
        private bool _isOperating;

        // Constructor
        public Bus(int id, Location location, bool isOperating)
        {
            _id = id;
            _location = location;
            _isOperating = isOperating;
        }

        // Attribute encapsulation
        public int Id { get { return _id; } }
        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public bool IsOperating
        {
            get { return _isOperating; }
            set { _isOperating = value; }
        }

        // Methods
        public void UpdateLocation()
        {
            // TODO: UpdateLocation Method
        }
    }
}
