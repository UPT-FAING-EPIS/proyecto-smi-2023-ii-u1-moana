using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;

namespace Moana.Pages
{
    public partial class HorarioPastillas : ContentPage
    {
        public HorarioPastillas()
        {
            InitializeComponent();
            timePicker.Time = DateTime.Now.TimeOfDay;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            String Titulo = Titulotxt.Text;
            String Contenido = Contenidotxt.Text;
            DateTime selectedDate = DateTime.Now;
            TimeSpan selectedTime = timePicker.Time;

            DateTime scheduledDateTime = selectedDate.Date + selectedTime; // Combinar fecha y hora

            var request = new NotificationRequest
            {
                NotificationId = 1337,
                Title = Titulo,
                Subtitle = Contenido,
                Description = Contenido,
                ReturningData = Contenido,
                BadgeNumber = 1,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = scheduledDateTime,
                },
                Android = new AndroidOptions
                {
                    AutoCancel = false,
                }
            };

            if (await LocalNotificationCenter.Current.Show(request))
            {
                TimeSpan timeUntilAlarm = scheduledDateTime - DateTime.Now;

                string timeUntilAlarmText = FormatTimeSpan(timeUntilAlarm);

                statusLabel.Text = "La alarma sonará en " + timeUntilAlarmText;
                statusLabel.IsVisible = true;

                Vibration.Vibrate();

                await Task.Delay(5000); 
                Vibration.Cancel();

                await Task.Delay(3000);
                statusLabel.IsVisible = false;
            }
        }

        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            if (timeSpan.TotalMinutes < 1)
            {
                return "menos de 1 minuto";
            }
            else if (timeSpan.TotalMinutes < 2)
            {
                return "1 minuto";
            }
            else if (timeSpan.TotalHours < 1)
            {
                return $"{(int)timeSpan.TotalMinutes} minutos";
            }
            else if (timeSpan.TotalHours < 2)
            {
                return "1 hora";
            }
            else
            {
                return $"{(int)timeSpan.TotalHours} horas {(int)timeSpan.Minutes} minutos";
            }
        }
    }
}
