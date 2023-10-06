
using Moana.View;

namespace Moana
{
    public partial class MedicoShell : Shell
    {
        public MedicoShell(string nameUser)
        {
            InitializeComponent();

            // Configura la p�gina MedicoHomePage y pasa el par�metro
            var medicoHomePage = new MedicoHomePage(nameUser);
            Routing.RegisterRoute("MedicoHomePage", typeof(MedicoHomePage));
            Items.Add(new ShellContent
            {
                Title = "",
                Content = medicoHomePage
            });
            CurrentItem = Items[0];
        }
    }
}