using Android.Content;
using AndroidX.Core.Content;
using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace ExpensesApp.Droid.Dependencies
{
    public class Share : IShare
    {
        public Task Show(string title, string message, string filePath)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            var documentUri = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, "com.companyname.expensesapp.provider", new Java.IO.File(filePath));

            intent.PutExtra(Intent.ExtraStream, documentUri);
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, message);

            var chooserIntent = Intent.CreateChooser(intent, title);
            chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission);
            chooserIntent.AddFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(chooserIntent);

            return Task.FromResult(true);
        }
    }
}