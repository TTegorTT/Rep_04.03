using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_04._03.Classes
{
    internal static class CurrentUser
    {
        public static string Name { get; set; }

        public static string Role { get; set; }

        public static void Logout()
        {
            Name = "";
            Role = "";
        }
    }
}
