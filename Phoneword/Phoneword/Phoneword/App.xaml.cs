using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phoneword
{
    //  Declare shared resources in code and use them in .AXML 
    //  Alternative to Resource Dictionaries 
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
