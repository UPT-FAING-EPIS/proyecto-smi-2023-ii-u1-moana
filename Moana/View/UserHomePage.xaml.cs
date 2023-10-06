namespace Moana.View;

public partial class UserHomePage : ContentPage
{
	public UserHomePage(string nameuser)
	{
		InitializeComponent();
        BindingContext = new UserHomePageViewModel();
        ((UserHomePageViewModel)BindingContext).NameUser = nameuser.ToUpper();
    }

    private async void bars_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPageView());

        Navigation.RemovePage(this);

    }

    private void search_Clicked(object sender, EventArgs e)
    {

    }

    private void bells_Clicked(object sender, EventArgs e)
    {

    }
}

