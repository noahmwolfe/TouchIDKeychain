using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;

namespace TouchIDKeychain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public event EventHandler LoginSucceeded;
        string username;
        string password;
        bool isLoggedIn = false;
        public LoginPage()
        {
            InitializeComponent();
        }
        private void OnLoginButtonClicked(object sender, EventArgs e)
        {


            username = usernameEntry.Text;
            password = passwordEntry.Text;

            var isValid = AreCredentialsCorrect(username, password);
            if (isValid)
            {
                LoginSuccess();
            }
        }
        private void OnEnableButtonClicked(object sender, EventArgs e)
        {
            bool doCredentialsExist = App.Credentials.DoCredentialsExist();
            if (!doCredentialsExist)
            {
                username = usernameEntry.Text;
                password = passwordEntry.Text;
                App.Credentials.SaveCredentials(username, password);
                messageLabel.Text = "Credentials Added to Keychain";
            }
            else
            {
                messageLabel.Text = "Credentials already exist";
                passwordEntry.Text = string.Empty;
            }
        }
        private void OnDisableButtonClicked(object sender, EventArgs e)
        {
            bool doCredentialsExist = App.Credentials.DoCredentialsExist();
            if (doCredentialsExist)
            {
                App.Credentials.DeleteCredentials();
                messageLabel.Text = "Credentials Deleted";
            }
            else
            {
                messageLabel.Text = "Credentials do not exist";
                passwordEntry.Text = string.Empty;
            }
        }
        protected override void OnAppearing()
        {
            bool doCredentialsExist = App.Credentials.DoCredentialsExist();
            if (doCredentialsExist)
            {
                Action get_credentials = GetCredentials;
                DependencyService.Get<TouchIDAuthentication>().Authenticate(get_credentials, null);
            }
        }

        protected override void OnDisappearing()
        {
            if (!isLoggedIn) return;
            base.OnDisappearing();
        }

        private void GetCredentials()
        {
            username = App.Credentials.UserName;
            password = App.Credentials.Password;
            LoginSuccess();
        }
        private void LoginSuccess()
        {
            if (LoginSucceeded != null && AreCredentialsCorrect(username, password))
            {
                LoginSucceeded(this, EventArgs.Empty);
            }
        }
        bool AreCredentialsCorrect(string username, string password)
        {
            return username == "noah" && password == "1234";
        }
    }
}