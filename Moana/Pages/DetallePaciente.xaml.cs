namespace Moana.Pages;

public partial class DetallePaciente : ContentPage
{
	public DetallePaciente()
	{
		InitializeComponent();
	}
    public void SetPatientName(string name)
    {
        lblNombrePaciente.Text = name;
    }
}