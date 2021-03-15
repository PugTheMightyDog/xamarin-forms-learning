using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Phoneword
{
    public class OldMainPage : ContentPage
    {
        Entry phoneNumberTxt;
        Button translateBtn;
        Button callBtn;

        string translatedNumber;
        
        public OldMainPage()
        {
            this.Padding = new Thickness(20, 20);

            StackLayout stackLayout = new StackLayout
            {
                Spacing = 15
            };

            stackLayout.Children.Add(new Label
            {
                Text = "Enter a Phoneword:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))

            });

            stackLayout.Children.Add(phoneNumberTxt = new Entry
            {
                Text = "1-855-XAMARIN"
            });

            stackLayout.Children.Add(translateBtn = new Button
            {
                Text = "Translate"
            });

            stackLayout.Children.Add(callBtn = new Button
            {
                Text = "Call",
                IsEnabled = false,               
            });


            translateBtn.Clicked += TranslateBtn_Clicked;
            callBtn.Clicked += CallBtn_Clicked;
            this.Content = stackLayout;


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
            string input = phoneNumberTxt.Text;

            translatedNumber = PhonewordTranslator.ToNumber(input);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callBtn.IsEnabled = true;
                callBtn.Text = "Call" + translatedNumber;
            }else
            {
                callBtn.IsEnabled = false;
                callBtn.Text = "Call";
            }
        }
    }
}
