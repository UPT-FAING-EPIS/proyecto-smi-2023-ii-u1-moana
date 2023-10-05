namespace Moana.View;

public partial class UserHomePage : ContentPage
{
	public UserHomePage(string nameuser)
	{
		InitializeComponent();
        BindingContext = new UserHomePageViewModel();
        ((UserHomePageViewModel)BindingContext).NameUser = nameuser.ToUpper();
    }
}

  