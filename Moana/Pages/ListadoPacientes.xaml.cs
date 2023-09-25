using Moana.Models;

namespace Moana.Pages;

public partial class ListadoPacientes : ContentPage
{

    public ListadoPacientes()
    {
        InitializeComponent();
        BindingContext = new ListadoPacientesViewModel();
    }
    private void OnPatientTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Patient selectedPatient)
        {
            ((ListadoPacientesViewModel)BindingContext).SelectedPatient = selectedPatient;
            ((ListadoPacientesViewModel)BindingContext).ShowPatientDetailsCommand.Execute(null);

            ((ListView)sender).SelectedItem = null;
        }
    }

}
