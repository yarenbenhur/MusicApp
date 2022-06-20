using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public string PasswordHash { get; set; }
    }
}
