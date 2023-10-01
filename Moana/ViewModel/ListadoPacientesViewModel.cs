using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Moana.Models;

namespace Moana.View
{
    public class ListadoPacientesViewModel : BindableObject
    {
        private ObservableCollection<Patient> patients;
        private Patient selectedPatient;

        public ListadoPacientesViewModel()
        {
            LoadPatients();
            AddPatientCommand = new Command(OnAddPatientClicked);
            ShowPatientDetailsCommand = new Command(OnShowPatientDetails);
        }

        public ObservableCollection<Patient> Patients
        {
            get { return patients; }
            set
            {
                patients = value;
                OnPropertyChanged();
            }
        }

        public Patient SelectedPatient
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

        private void LoadPatients()
        {
            Patients = new ObservableCollection<Patient>
            {
                new Patient { Name = "Paciente 1" },
                new Patient { Name = "Paciente 2" },
                new Patient { Name = "Paciente 3" }
            };
        }

        private void OnAddPatientClicked()
        {
            var newPatient = new Patient { Name = "Nuevo Paciente" };
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
