using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesApp.Helpers
{
    public static class AppCenterHelpers
    {
        public static async void TrackEvent(string name, Dictionary<string, string> properties)
        {
            if (await Analytics.IsEnabledAsync())
                Analytics.TrackEvent(name, properties);
        }

        public static async void TrackError(Exception exception, Dictionary<string, string> properties)
        {
            if (await Crashes.IsEnabledAsync())
                Crashes.TrackError(exception, properties);
        }
    }
}
