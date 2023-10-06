using Supabase;

namespace Moana.View;

public partial class NuevaPrescripcion : ContentPage
{
    private readonly Client _supabaseClient;
    public NuevaPrescripcion()
	{
        InitializeComponent();
        _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();

	}

	async private void Button_Clicked(object sender, EventArgs e)
	{
        string email = CorreoEntry.Text;
        string password = "admin"; 
        string name = NombreEntry.Text;
        var userService = new UserService(_supabaseClient);
        
        var (success, errorMessage) = await userService.CreatePatient(email, password, name);

        if (success)
        {
            await Navigation.PushAsync(new RecomendacionIA());
        }
        else
        {
            await Navigation.PushAsync(new RecomendacionIA());

            // await DisplayAlert("Error", errorMessage, "OK");
        }
    }
}