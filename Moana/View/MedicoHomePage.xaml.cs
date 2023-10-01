namespace Moana.View;

public partial class MedicoHomePage : ContentPage
{
	public MedicoHomePage()
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