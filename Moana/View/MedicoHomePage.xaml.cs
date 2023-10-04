namespace Moana.View;

public partial class MedicoHomePage : ContentPage
{
	public MedicoHomePage()
	{
		InitializeComponent();
        
	}

    async private void Button_Clicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync( new ListadoPacientes());
    }

    async private void Button_Clicked_1(object sender, EventArgs e)
    {
        ListadoPacientes listapacientes = new ListadoPacientes();
        await Navigation.PushAsync(new ListadoPacientes());

    }

}