using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ExpensesApp.Droid.CustomRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
namespace ExpensesApp.Droid.CustomRenderers
{
    public class CustomTextCellRenderer : TextCellRenderer
    {
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context);

            switch (item.StyleId)
            {
                case "none":
                    cell.SetBackgroundColor(Android.Graphics.Color.AliceBlue);
                    break;
                case "checkmark":
                    cell.SetBackgroundColor(Android.Graphics.Color.AntiqueWhite);
                    break;
                case "detail-button":
                    cell.SetBackgroundColor(Android.Graphics.Color.Aqua);
                    break;
                case "detail-disclosure-button":
                    cell.SetBackgroundColor(Android.Graphics.Color.Aquamarine);
                    break;
                case "disclosure":
                default:
                    cell.SetBackgroundColor(Android.Graphics.Color.Azure);
                    break;
            }

            return cell;
        }
    }
}