﻿using Android.Graphics.Drawables;
using ExpensesApp.Droid.Effects;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName("companyname")]
[assembly:ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpensesApp.Droid.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        Android.Graphics.Color selectedColor;

        protected override void OnAttached()
        {
            selectedColor = new Android.Graphics.Color(176, 152, 164);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((ColorDrawable)Control.Background).Color != selectedColor)
                    {
                        Control.SetBackgroundColor(selectedColor);
                    }
                    else
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    }
                }
            }
            catch(InvalidCastException)
            {
                Control.SetBackgroundColor(selectedColor);
            }
        }

        protected override void OnDetached()
        {

        }
    }
}