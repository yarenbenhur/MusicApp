using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public interface IUserContext
    {
        UserSignUpResult SignUp(User user);
        UserLoginResult Login(string username, string passwordHash);
    }
}
