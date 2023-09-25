namespace Moana.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    async private void Button_Clicked(object sender, EventArgs e)
    {

        ListadoPacientes listapacientes = new ListadoPacientes();
        await App.Current.MainPage.Navigation.PushAsync(listapacientes);
    }

    async private void Button_Clicked_1(object sender, EventArgs e)
    {
        ListadoPacientes listapacientes = new ListadoPacientes();
        await App.Current.MainPage.Navigation.PushAsync(listapacientes);

    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {

    }
}