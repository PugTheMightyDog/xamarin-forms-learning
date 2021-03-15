using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFDraw;
using XFDraw.Droid;

[assembly: ExportRenderer(typeof(SketchView), typeof(SketchViewRenderer))]
namespace XFDraw.Droid
{
    public class SketchViewRenderer : ViewRenderer<SketchView, PaintView>
    {
        Context context;
        public SketchViewRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SketchView> e)
        {
            base.OnElementChanged(e);

            if(Control == null)
            {
                var paintView = new PaintView(context);
                paintView.SetInkColor(this.Element.InkColor.ToAndroid());
                SetNativeControl(paintView);

                MessagingCenter.Subscribe<SketchView>(this, "Clear", OnMessageClear);

                paintView.LineDrawn += PaintViewLineDrawn;
            }
        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == SketchView.InkColorProperty.PropertyName)
            {
                Control.SetInkColor(Element.InkColor.ToAndroid());
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                MessagingCenter.Unsubscribe<SketchView>(this, "Clear");
            }

            base.Dispose(disposing);
        }

        void OnMessageClear(SketchView sender)
        {
            if (sender == Element)
                Control.Clear();
        }

        //  Renderer event handler method
        //  Notify the element
        private void PaintViewLineDrawn(object sender, System.EventArgs e)
        {
            var sketchCon = (ISketchController)Element;

            if (sketchCon == null)
                return;

            sketchCon.SendSketchUpdated();
        }
    }
}