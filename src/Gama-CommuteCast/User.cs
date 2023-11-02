using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;

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

    class Admin : User
    {
        public bool IsSuperAdmin { get; set; }
        private NpgsqlConnection conn;
        string connString = "Host=20.231.106.166;Port=5432;Username=postgres;Password=kemong;Database=postgres";
        string query = "";
        NpgsqlCommand cmd;

        public Admin(int id, string username, string password, bool isSuperAdmin) : base(id, username, password)
        {
            IsSuperAdmin = isSuperAdmin;
        }
        public bool Login(string username, string password)
        {
            // Login
            try
            {
                conn.Open();
                string query = $"select login_user('{username}', '{password}')";
                cmd = new NpgsqlCommand(query, conn);
                if ((int)cmd.ExecuteScalar() == 500)
                {
                    throw new Exception("[500] An internal server error occured.");
                }
                if ((int)cmd.ExecuteScalar() == 401)
                {
                    throw new Exception("[401] Wrong password.");
                }
                if ((int)cmd.ExecuteScalar() == 404)
                {
                    throw new Exception("[404] User doesn't exist.");
                }
                conn.Close();
                MessageBox.Show("Success");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return false;
            }
        }
    }

}
