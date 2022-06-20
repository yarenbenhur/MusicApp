using Newtonsoft.Json;
using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public class UserContext : BaseContext, IUserContext
    {
        public UserContext() : base("user.txt")
        {

        }

        public UserLoginResult Login(string username, string passwordHash)
        {
            List<User> userList = FileOperations.ReadAllData<User>(FilePath);
            User user = userList.FirstOrDefault(i => i.Username == username && i.PasswordHash == passwordHash);
            if (user == null)
            {
                return new UserLoginResult(1, "Kullanıcı adı veya şifre hatalı!", null);
            }
            return new UserLoginResult(0, "Başarıyla giriş yapıldı.", user); ;
        }

        public UserSignUpResult SignUp(User user)
        {
            List<User> userList = FileOperations.ReadAllData<User>(FilePath);
            User checkUsernameUser = userList.FirstOrDefault(i => i.Username == user.Username);
            if (checkUsernameUser != null)
            {
                return new UserSignUpResult(1, "Aynı kullanıcı adına sahip başka bir kullanıcı bulunmakta.", null);
            }
            string userJson = JsonConvert.SerializeObject(user);
            FileOperations.WriteDataToFile(FilePath, userJson);
            return new UserSignUpResult(0, "Kişi başarıyla eklendi.", user);
        }
    }
}
