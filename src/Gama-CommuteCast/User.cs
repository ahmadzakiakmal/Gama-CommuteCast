using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama_CommuteCast
{
    class User
    {
        // Attributes
        private int _id;
        private string _username;
        private string _password;

        // Attribute encapsulation
        public int Id { get { return _id; } }
        public string UserName { 
            get { return _username; } 
            set { _username = value; } 
        } 
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        // Constructor
        public User(int id, string username, string password) {
            _id = id;
            _username = username;
            _password = password;
        }

        // Methods
        public void Login(string username, string password)
        {
            // TODO: Login Method
        } 

        public void Logout()
        {
            // TODO: Logout Method
        }
    }
}
