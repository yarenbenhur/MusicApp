using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public class UserDBContext : IUserContext
    {
        public UserLoginResult Login(string username, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public UserSignUpResult SignUp(User user)
        {
            throw new NotImplementedException();
        }
    }
}
