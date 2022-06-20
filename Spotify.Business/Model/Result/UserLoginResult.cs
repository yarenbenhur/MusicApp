using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business.Model.Result
{
    public class UserLoginResult : BaseResult
    {
        public User User { get; set; }

        public UserLoginResult(int statusCode, string message, User user) : base(statusCode, message)
        {
            User = user;
        }
    }
}
