using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phoneword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        string translatedNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void CallBtn_Clicked(object sender, EventArgs e)
        {
            bool dial = await this.DisplayAlert("Dial a Number", "Would you like to call " + translatedNumber + "?", "Yes", "No");

            if (dial)
            {
                try
                {
                    PhoneDialer.Open(translatedNumber);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
                }
                catch (FeatureNotSupportedException)
                {
                    await DisplayAlert("Unable to dial", "Phone dialing not supported.", "OK");
                }
                catch (Exception)
                {
                    // Other error has occurred.
                    await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
                }
            }
        }

        private void TranslateBtn_Clicked(object sender, EventArgs e)
        {
            string input = phoneNumberText.Text;

            translatedNumber = PhonewordTranslator.ToNumber(input);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callBtn.IsEnabled = true;
                callBtn.Text = "Call" + translatedNumber;
            }
            else
            {
                callBtn.IsEnabled = false;
                callBtn.Text = "Call";
            }
        }
    }
}