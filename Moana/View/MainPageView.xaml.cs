using Supabase;
namespace Moana.View
{
    public partial class MainPageView : ContentPage
    {
        private readonly Client _supabaseClient;

        public MainPageView()
        {
            InitializeComponent();
            _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();

        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            AuthenticationService authService = new AuthenticationService(_supabaseClient);
            UserService userService = new UserService(_supabaseClient);

            LoginPage loginpage = new LoginPage(authService, userService);
            await App.Current.MainPage.Navigation.PushAsync(loginpage);
        }
    }
}