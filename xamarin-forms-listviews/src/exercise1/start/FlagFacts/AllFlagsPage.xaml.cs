using FlagData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlagFacts
{

    public partial class AllFlagsPage : ContentPage
    {
        public AllFlagsPage()
        {
            //vm = DependencyService.Get<FlagDetailsViewModel>();

            InitializeComponent();

            BindingContext = DependencyService.Get<FlagDetailsViewModel>();
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await this.Navigation.PushAsync(new FlagDetailsPage());
        }
    }
}