using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business.Model.Result
{
    public class UserSignUpResult : BaseResult
    {
        public User User { get; set; }

        public UserSignUpResult(int statusCode, string message, User user): base(statusCode, message)
        {
            User = user;
        }
    }
}
