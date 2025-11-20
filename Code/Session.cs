using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDPOrderingSystem.Code
{
    public static class Session
    {
        public static string Username { get; set; }
        public static string Role { get; set; }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(Username);
    }
}
