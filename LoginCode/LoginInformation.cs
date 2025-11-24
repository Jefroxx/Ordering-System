using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem.LoginCode
{
    internal class LoginInformation
    {
        string Username;
        string Password;
        string item;

        public LoginInformation(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public String getUsername()
        {
            return this.Username;
        }
        public String getPassword()
        {
            return this.Password;
        }
    }
}
