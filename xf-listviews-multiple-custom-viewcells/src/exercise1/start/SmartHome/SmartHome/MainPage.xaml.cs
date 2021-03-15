using System.Linq;
using Xamarin.Forms;

namespace SmartHome
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //  Change the collection to support grouping
            //  Sort collection by device name then turn it into a nested IEnumerable<IGrouping<Device>>
            var groupedCollection = DeviceManager.Instance.Value.Devices.OrderBy(o => o.Name).ToLookup(dev => dev.Name[0].ToString());

            BindingContext = groupedCollection;
        }
    }
}
