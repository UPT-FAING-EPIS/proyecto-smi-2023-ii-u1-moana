using Microsoft.Maui.Controls;

namespace Moana.Pages;
   public partial class LoginPage : ContentPage
    {
        private readonly AuthenticationService _authService = new AuthenticationService();

        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ResultLabel.Text = "Introduce usuario y contrase�a.";
                return;
            }

            var isAuthenticated = await _authService.Authenticate(username, password);

            if (isAuthenticated)
            {

                ResultLabel.Text = "Inicio de sesi�n exitoso!";
                //await Shell.Current.GoToAsync($"//{nameof(UserHomePage)}");
                UserHomePage vistauser = new UserHomePage();
                await App.Current.MainPage.Navigation.PushAsync(vistauser);
                // HomePage vistaMedico = new HomePage();
                // await App.Current.MainPage.Navigation.PushAsync(vistaMedico);
            }
            else
            {

                ResultLabel.Text = "Usuario o contrase�a incorrectos.";
            }
        }
    }
