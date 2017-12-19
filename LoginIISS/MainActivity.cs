using Android.App;
using Android.Widget;
using Android.OS;
using LoginIISS.LoginHelper;
using LoginIISS.AzureHelper;
using Android.Content.PM;

namespace LoginIISS
{
    [Activity(Label = "LoginIISS", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        public static Button btnLogin;
        public static EditText etUser;
        public static EditText etPassword;
        public static bool isLogged;
        public static int idC;
        public static string myDevice;
        public static Login obj;
        public Queries queries = new Queries();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            myDevice = "android-" + Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            etUser = FindViewById<EditText>(Resource.Id.etUsername);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);
            btnLogin.Click += BtnLogin_ClickAsync;
            System.Diagnostics.Debug.WriteLine("Dispositivo: " + myDevice);
            await queries.GetDispositivosAsync();
        }
        private async void BtnLogin_ClickAsync(object sender, System.EventArgs e)
        {
            ValidateLogin login = new ValidateLogin();
            await login.QueryAsync(etUser.Text, etPassword.Text);
            if (isLogged)
            {
                Android.App.AlertDialog.Builder builder =
                    new AlertDialog.Builder(this);
                AlertDialog alertDialog = builder.Create();
                alertDialog.SetTitle("Intelligent Identificator Security System");
                //alertDialog.SetIcon(Resource.Drawable.Icon);
                alertDialog.SetMessage(
                    $"Welcome back {obj.User} !!!");
                alertDialog.SetButton("Continue", (s, ev) =>
                {
                    try
                    {
                        var CameraIntent = new Android.Content.Intent(this, typeof(CameraActivity));
                        StartActivity(CameraIntent);
                    }
                    catch (System.Exception exception)
                    {
                        System.Diagnostics.Debug.Write(exception.Message);
                    }
                });
                alertDialog.Show();
            }
            else
            {
                Android.App.AlertDialog.Builder builder =
                   new AlertDialog.Builder(this);
                AlertDialog alertDialog = builder.Create();
                alertDialog.SetTitle("Intelligent Identificator Security System");
                //alertDialog.SetIcon(Resource.Drawable.Icon);
                alertDialog.SetMessage(
                    $"Sorry you're not registered !!!");
                alertDialog.SetButton("Continue", (s, ev) =>{ });
                etPassword.Text = "";
                etUser.Text = "";
                alertDialog.Show();
            }
        }
    }
}