using System.Collections.ObjectModel;

namespace Moana.View;

public partial class AdministrarCitas : ContentPage
{
	public AdministrarCitas()
	{
		InitializeComponent();

        // Crear una lista de citas m�dicas de ejemplo
        var citasMedicas = new List<CitaMedica>
            {
                new CitaMedica { Nombre = "Juan", Fecha = "15/02/2023", Hora = "5:00 pm" },
                new CitaMedica { Nombre = "Mar�a", Fecha = "16/02/2023", Hora = "4:30 pm" },
                // Agrega m�s citas m�dicas aqu�
            };

        // Asignar la lista como origen de datos para el ListView
        CitasCollectionView.ItemsSource = new ObservableCollection<CitaMedica>(citasMedicas);
    }
    public class CitaMedica
    {
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}