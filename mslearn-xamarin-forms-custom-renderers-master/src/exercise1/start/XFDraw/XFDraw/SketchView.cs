using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFDraw
{
    public class SketchView : View, ISketchController
    {
        //public static readonly BindableProperty MultiTouchEnabledProperty = BindableProperty.Create("MultiTouchEnabled", typeof(bool), typeof(SketchView), false);

        //public bool MultiTouchEnabled
        //{
        //    get => (bool)GetValue(MultiTouchEnabledProperty);
        //    set => SetValue(MultiTouchEnabledProperty, value);
        //}

        public event EventHandler SketchUpdated;

        public static readonly BindableProperty InkColorProperty = BindableProperty.Create("InkColor", typeof(Color), typeof(SketchView), Color.Blue);

        public Color InkColor
        {
            get { return (Color)GetValue(InkColorProperty); }
            set { SetValue(InkColorProperty, value); }
        }

        public void Clear()
        {
            MessagingCenter.Send(this, "Clear");
        }

        //  Element event handler method
        void ISketchController.SendSketchUpdated()
        {
            if (SketchUpdated != null)
                SketchUpdated(this, EventArgs.Empty);
        }
    }
}
