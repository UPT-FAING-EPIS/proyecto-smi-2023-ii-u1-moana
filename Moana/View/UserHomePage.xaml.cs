namespace Moana.View;

public partial class UserHomePage : ContentPage
{
	public UserHomePage(string nameuser)
	{
		InitializeComponent();
        BindingContext = new UserHomePageViewModel();
        ((UserHomePageViewModel)BindingContext).NameUser = nameuser.ToUpper();
    }

    private async void puerta_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPageView());

        Navigation.RemovePage(this);

    }

    private void config_Clicked(object sender, EventArgs e)
    {

    }

    private void user_Clicked(object sender, EventArgs e)
    {

    }
}

