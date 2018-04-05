using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IAudioXamarin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(Entry), typeof(MyEntryRenderer))]
namespace IAudioXamarin.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class MyEntryRenderer : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
               base.OnElementChanged(e);
           
            VerticalScrollBarEnabled = false;

            Control.FocusChange += Control_FocusChange;
            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }

            if (Control == null || e.NewElement == null) return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Control.SetPadding(3, 3, 0, 3);
                e.NewElement.Unfocused += (sender, evt) =>
                {
                    // unfocused, set color
                    Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                };
                e.NewElement.Focused += (sender, evt) =>
                {
                    // focus, set color
                    Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                };
            }

            else
            {
                Control.SetPadding(3, 3, 0, 3);
                e.NewElement.Unfocused += (sender, evt) =>
                {
                    // unfocused, set color
                    Control.Background.SetColorFilter(Android.Graphics.Color.Transparent, PorterDuff.Mode.SrcAtop);
                };
                e.NewElement.Focused += (sender, evt) =>
                {
                    // focus, set color
                    Control.Background.SetColorFilter(Android.Graphics.Color.Transparent, PorterDuff.Mode.SrcAtop);
                };
            }

        }
        void Control_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
                (Forms.Context as Activity).Window.SetSoftInputMode(SoftInput.AdjustResize);
            else
                (Forms.Context as Activity).Window.SetSoftInputMode(SoftInput.AdjustNothing);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}