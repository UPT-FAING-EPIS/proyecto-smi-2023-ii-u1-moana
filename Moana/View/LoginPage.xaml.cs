using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System;

namespace Moana.View
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthenticationService _authService;

        public LoginPage(AuthenticationService authService)
        {
            InitializeComponent();

            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
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
                ResultLabel.Text = "Inicio de sesión exitoso!";
                var appShell = new AppShell();
                appShell.CurrentItem = appShell.Items.FirstOrDefault(item => item.Route == "MedicoTab");//PacienteTab
                App.Current.MainPage = appShell;
            }
            else
            {
                ResultLabel.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}