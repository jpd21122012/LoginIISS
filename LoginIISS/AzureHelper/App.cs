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
using Microsoft.WindowsAzure.MobileServices;

namespace LoginIISS.AzureHelper
{
    public class App
    {
        //we initialize the mobile service of azure o obtain the data from the easy table.
        public static MobileServiceClient MobileService = new MobileServiceClient("https://pruebjpd.azurewebsites.net");
    }
}