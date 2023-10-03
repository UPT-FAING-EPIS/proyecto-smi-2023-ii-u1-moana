using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        private bool isRefreshing;

        public ListadoPacientesViewModel()
        {
            _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();

            LoadPatients();
            AddPatientCommand = new Command(OnAddPatientClicked);
            ShowPatientDetailsCommand = new Command(OnShowPatientDetails);
            RefreshCommand = new Command(async () => await OnRefresh());
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

        public ICommand RefreshCommand { get; private set; }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        private async Task OnRefresh()
        {
            IsRefreshing = true;

            await ReloadPatients();

            IsRefreshing = false;
        }

        private async Task ReloadPatients()
        {
            var userService = new UserService(_supabaseClient);
            var patientsList = await userService.GetPatients();
            Patients.Clear();
            foreach (var patient in patientsList)
            {
                Patients.Add(patient); 
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
