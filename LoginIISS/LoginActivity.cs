using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using LoginIISS.AzureHelper;
using LoginIISS.LoginHelper;

namespace LoginIISS
{
    [Activity(Label = "LoginIISS", ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : Activity
    {
        public static Button BtnLogin;
        public static EditText EtUser;
        public static EditText EtPassword;
        public static bool IsLogged;
        public static int IdC;
        public static string MyDevice;
        public static Login Obj;
        public Queries Queries = new Queries();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);
            MyDevice = "android-" + Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            BtnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            EtUser = FindViewById<EditText>(Resource.Id.etUsername);
            EtPassword = FindViewById<EditText>(Resource.Id.etPassword);
            BtnLogin.Click += BtnLogin_Click;
            System.Diagnostics.Debug.WriteLine("Dispositivo: " + MyDevice);
            await Queries.GetDispositivosAsync();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            ValidateLogin login = new ValidateLogin();
            await login.QueryAsync(EtUser.Text, EtPassword.Text);
            if (IsLogged)
            {
                AlertDialog.Builder builder =
                    new AlertDialog.Builder(this);
                AlertDialog alertDialog = builder.Create();
                alertDialog.SetTitle("Intelligent Identificator Security System");
                //alertDialog.SetIcon(Resource.Drawable.Icon);
                alertDialog.SetMessage(
                    $"Welcome back {Obj.User} !!!");
                alertDialog.SetButton("Continue", (s, ev) =>
                {
                    try
                    {
                        var cameraIntent = new Intent(this, typeof(MainActivity));
                        StartActivity(cameraIntent);
                    }
                    catch (Exception exception)
                    {
                        System.Diagnostics.Debug.Write(exception.Message);
                    }
                });
                alertDialog.Show();
            }
            else
            {
                AlertDialog.Builder builder =
                    new AlertDialog.Builder(this);
                AlertDialog alertDialog = builder.Create();
                alertDialog.SetTitle("Intelligent Identificator Security System");
                //alertDialog.SetIcon(Resource.Drawable.Icon);
                alertDialog.SetMessage(
                    "Sorry you're not registered !!!");
                alertDialog.SetButton("Continue", (s, ev) => { });
                EtPassword.Text = "";
                EtUser.Text = "";
                alertDialog.Show();
            }
        }
    }
}