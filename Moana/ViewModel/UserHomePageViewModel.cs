using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Moana.View
{
    public class UserHomePageViewModel : BindableObject
    {
        public ICommand PrescripcionesCommand { get; private set; }
        public ICommand HorariosPastillasCommand { get; private set; }

        private string nameUser;
        public UserHomePageViewModel()
        {
            PrescripcionesCommand = new Command(Prescripciones);
            HorariosPastillasCommand = new Command(HorariosPastillas);
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

        private async void Prescripciones()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Prescripciones());
        }

        private async void HorariosPastillas()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HorarioPastillas());
        }

   
    }
    
}
