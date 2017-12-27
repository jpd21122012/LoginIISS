using Android.App;
using Android.OS;
using Android.Content.PM;

namespace LoginIISS
{
    [Activity(Label = "LoginIISS", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            if (!LoginActivity.IsLogged)
            {
                try
                {
                    var loginIntent = new Android.Content.Intent(this, typeof(LoginActivity));
                    StartActivity(loginIntent);
                }
                catch (System.Exception exception)
                {
                    System.Diagnostics.Debug.Write(exception.Message);
                }
            }
            else
            {
                this.RequestedOrientation = ScreenOrientation.Landscape;
                SetContentView(Resource.Layout.Main);
            }
        }
    }
}