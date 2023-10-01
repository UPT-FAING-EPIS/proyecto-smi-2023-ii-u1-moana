namespace Moana.View;

public partial class UserHomePage : ContentPage
{
	public UserHomePage()
	{
		InitializeComponent();
	}

    async private void Prescripcionesbtn_Clicked(object sender, EventArgs e)
    {
        Prescripciones presc = new Prescripciones();
        await App.Current.MainPage.Navigation.PushAsync(presc);
    }

    async private void pastillashorario_Clicked(object sender, EventArgs e)
    {
        HorarioPastillas hpastillas = new HorarioPastillas();
        await App.Current.MainPage.Navigation.PushAsync(hpastillas);
    }
}