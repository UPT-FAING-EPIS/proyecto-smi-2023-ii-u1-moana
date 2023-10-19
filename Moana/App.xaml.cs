
using Moana.View;

namespace Moana
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var rrick = "erik";
            MainPage = new NavigationPage(new MedicoHomePage(rrick));

        }
    }
}