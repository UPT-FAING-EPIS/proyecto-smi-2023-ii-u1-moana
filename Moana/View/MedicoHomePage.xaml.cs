
namespace Moana.View;

public partial class MedicoHomePage : ContentPage
{
<<<<<<< HEAD
    public MedicoHomePage(string nameuser)
    {
        InitializeComponent();
        BindingContext = new MedicoHomePageViewModel();
        ((MedicoHomePageViewModel)BindingContext).NameUser = nameuser.ToUpper();
    }
=======
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

>>>>>>> 5f0ae78305cd2c32d3b16350d8edef548f4a2e03
}