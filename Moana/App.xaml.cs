﻿
using Moana.View;

namespace Moana
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new MainPageView());

        }
    }
}