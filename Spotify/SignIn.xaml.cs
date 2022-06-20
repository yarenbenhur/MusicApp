using Spotify.Business;
using Spotify.Business.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spotify
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : BasePage
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {
            UserLoginResult userLoginResult = UserContext.Login(tbUsername.Text.Trim(), pbPassword.Password);
            if (userLoginResult.StatusCode == 0)
            {
                Application.SetCookie(new Uri(FileOperations.BasePath), userLoginResult.User.Username);
                
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                navigationService.Navigate(new Uri("Music.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show(userLoginResult.ResultMessage);
            }
        }
    }
}
