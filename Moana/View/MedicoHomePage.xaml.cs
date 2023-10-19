
using static Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.VisualElement;

namespace Moana.View;

public partial class MedicoHomePage : ContentPage
{
    public MedicoHomePage(string nameuser)
    {
        InitializeComponent();

        BindingContext = new MedicoHomePageViewModel();
        ((MedicoHomePageViewModel)BindingContext).NameUser = nameuser.ToUpper();

    }

    private void bells_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Notifications", "Notis", "OK");

    }

    private void search_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Search", "Search", "OK");

    }

    private async void puerta_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPageView());

        Navigation.RemovePage(this);

    }
}