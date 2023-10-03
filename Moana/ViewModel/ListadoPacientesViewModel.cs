using System.Collections.ObjectModel;
using System.Windows.Input;
using Moana.Models;
using Supabase;

namespace Moana.View
{
    public class ListadoPacientesViewModel : BindableObject
    {
        private readonly Client _supabaseClient;

        private ObservableCollection<User> patients;
        private User selectedPatient;

        public ListadoPacientesViewModel()
        {
            _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();
            LoadPatients();
            AddPatientCommand = new Command(OnAddPatientClicked);
            ShowPatientDetailsCommand = new Command(OnShowPatientDetails);
        }

        public ObservableCollection<User> Patients
        {
            get { return patients; }
            set
            {
                patients = value;
                OnPropertyChanged();
            }
        }

        public User SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                selectedPatient = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddPatientCommand { get; private set; }
        public ICommand ShowPatientDetailsCommand { get; private set; }

        private async void LoadPatients()
        {
            var userService = new UserService(_supabaseClient); 
            var patientsList = await userService.GetPatients();
            Patients = new ObservableCollection<User>(patientsList);
        }

        private void OnAddPatientClicked()
        {
            var newPatient = new User { Name = "Nuevo Paciente" }; 
            Patients.Add(newPatient);
        }

        private async void OnShowPatientDetails()
        {
            if (SelectedPatient != null)
            {
                var detallePacientePage = new DetallePaciente();

                detallePacientePage.SetPatientName(SelectedPatient.Name);

                await App.Current.MainPage.Navigation.PushAsync(detallePacientePage);

                SelectedPatient = null;
            }
        }
    }
}
