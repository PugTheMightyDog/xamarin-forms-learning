using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFDraw
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            var trash = new ToolbarItem()
            {
                Text = "Clear",
                Icon = "trash.png",
            };
            trash.Clicked += (o, s) => OnClearClicked();
            ToolbarItems.Add(trash);

            ToolbarItems.Add(new ToolbarItem("New Color", "pencil.png", OnColorClicked));
        }

        private void OnClearClicked()
        {

        }

        private void OnColorClicked()
        {
            sketchView.InkColor = GetRandomColor();
        }
        
        Random rand = new Random();
        Color GetRandomColor()
        {
            return new Color(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
        }
    }
}
