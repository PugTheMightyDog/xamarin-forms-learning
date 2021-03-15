using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartHome
{
    public class DeviceTemplateSelector : DataTemplateSelector
    {

        DataTemplate doorBellTemplate;
        DataTemplate smokeTemplate;
        DataTemplate thermostatTemplate;

        //  Default constructor
        public DeviceTemplateSelector()
        {
            doorBellTemplate = new DataTemplate(typeof(DoorBellViewCell));
            smokeTemplate = new DataTemplate(typeof(SmokeDetectorViewCell));
            thermostatTemplate = new DataTemplate(typeof(ThermostatViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //  Identify which viewcell template to use
            
            if(item is DoorBell)
            {
                return doorBellTemplate; 
            }

            if(item is SmokeDetector)
            {
                return smokeTemplate;
            }

            if(item is Thermostat)
            {
                return thermostatTemplate;
            }

            throw new Exception("Could not find the device type");
        }
    }
}
