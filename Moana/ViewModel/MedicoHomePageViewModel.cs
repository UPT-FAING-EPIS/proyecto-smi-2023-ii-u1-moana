using System;
using System.Windows.Input;

namespace Moana.View
{
    public class MedicoHomePageViewModel : BindableObject
    {
        public ICommand AdministrarCitasCommand { get; private set; }
        public ICommand ListadoPacientesCommand { get; private set; }
        public ICommand AdministrarPrescripCommand { get; private set; }

        private string nameUser;

        public MedicoHomePageViewModel()
        {
            AdministrarCitasCommand = new Command(AdministrarCitas);
            ListadoPacientesCommand = new Command(ListadoPacientes);
            AdministrarPrescripCommand = new Command(AdministrarPrescripciones);
        }

        public string NameUser
        {
            get { return nameUser; }
            set
            {
                if (nameUser != value)
                {
                    nameUser = value;
                    OnPropertyChanged(nameof(Saludo));
                }
            }
        }

        public string Saludo
        {
            get
            {
                var now = DateTime.Now;
                if (now.Hour >= 0 && now.Hour < 12)
                {
                    return "Buenos días, " + NameUser;
                }
                else if (now.Hour >= 12 && now.Hour < 18)
                {
                    return "Buenas tardes, " + NameUser;
                }
                else
                {
                    return "Buenas noches, " + NameUser;
                }
            }
        }


        private async void AdministrarCitas()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListadoPacientes());
        }

        private async void ListadoPacientes()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListadoPacientes());
        }

        private void AdministrarPrescripciones()
        {
            // Implementa la navegación a la página de administración de prescripciones aquí.
        }
    }
}
