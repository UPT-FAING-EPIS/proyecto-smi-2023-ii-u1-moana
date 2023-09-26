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

        async private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            AuthenticationService authService = new AuthenticationService(_supabaseClient);

            LoginPage loginpage = new LoginPage(authService);
            await App.Current.MainPage.Navigation.PushAsync(loginpage);
        }
    }
}