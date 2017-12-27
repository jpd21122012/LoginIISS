using Android.Content.PM;
using Android.App;
using Android.OS;
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
        }
    }
}