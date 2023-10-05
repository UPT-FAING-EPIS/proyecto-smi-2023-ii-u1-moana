
namespace Moana.View;

public partial class MedicoHomePage : ContentPage
{
    public MedicoHomePage(string nameuser)
    {
        InitializeComponent();
        BindingContext = new MedicoHomePageViewModel();
        ((MedicoHomePageViewModel)BindingContext).NameUser = nameuser.ToUpper();
    }
}