using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System;

namespace Moana.View
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthenticationService _authService;
        private readonly UserService _userService;
        public LoginPage(AuthenticationService authService, UserService userService)
        {
            InitializeComponent();

            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ResultLabel.Text = "Introduce usuario y contraseña.";
                return;
            }

            var isAuthenticated = await _authService.Authenticate(username, password);

            if (isAuthenticated)
            {
                var user = await _userService.GetUser(username);
                ResultLabel.Text = user.Model.rolId.ToString();

                var appShell = new AppShell();
                if (ResultLabel.Text == "2")
                {
                    appShell.CurrentItem = appShell.Items.FirstOrDefault(item => item.Route == "MedicoTab");
                }
                else
                {
                    appShell.CurrentItem = appShell.Items.FirstOrDefault(item => item.Route == "PacienteTab");
                }
                App.Current.MainPage = appShell;
            }
            else
            {
                ResultLabel.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}