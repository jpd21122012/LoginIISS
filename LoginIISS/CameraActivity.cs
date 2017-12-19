using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content.PM;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LoginIISS.AzureHelper;

namespace LoginIISS
{
    [Activity(Label = "CameraActivity", ScreenOrientation = ScreenOrientation.Landscape)]
    public class CameraActivity : Activity
    {
        public Queries queries = new Queries();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Camera);
            Android.Util.Log.Debug("d5316", "ON c CREATE QUERY COMPLETED");
        }
        protected override async void OnStop()
        {
            await queries.UpdateOffState();
            Android.Util.Log.Debug("d5316", "ON STOP QUERY COMPLETED");
            base.OnStop();
        }
        protected override async void OnPause()
        {
            await queries.UpdateOffState();
            System.Diagnostics.Debug.WriteLine("ON PAUSE QUERY COMPLETED");
            Android.Util.Log.Debug("d5316", "ON PAUSE QUERY COMPLETED");
            base.OnPause();
        }
        protected override async void OnDestroy()
        {
            await queries.UpdateOffState();
            Android.Util.Log.Debug("d5316", "ON DESTROY QUERY COMPLETED");

            base.OnDestroy();
        }
        protected override void OnStart()
        {
            Android.Util.Log.Debug("d5316", "ON START QUERY COMPLETED");
            base.OnStart();
        }
        protected override void OnResume()
        {
            Android.Util.Log.Debug("d5316", "ON RESUME QUERY COMPLETED");
            base.OnResume();
        }
        protected override void OnRestart()
        {
            Android.Util.Log.Debug("d5316", "ON RESTART QUERY COMPLETED");
            base.OnRestart();
        }
    }
}