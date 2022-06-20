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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : BasePage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password != pbPasswordAgain.Password)
            {
                MessageBox.Show("Girdiğiniz şifreler uyuşmamaktadır.");
                return;
            }
            User user = new User()
            {
                EMail = tbEMail.Text.Trim(),
                LastName = tbLastName.Text.Trim(),
                Name = tbName.Text.Trim(),
                Username = tbUsername.Text.Trim(),
                PasswordHash = pbPassword.Password
            };
            UserSignUpResult result = UserContext.SignUp(user);

            if (result.StatusCode != 0)
            {
                MessageBox.Show(result.ResultMessage);
            }
            else
            {
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                navigationService.Navigate(new Uri("SignIn.xaml", UriKind.RelativeOrAbsolute));
            }
        }
    }
}
