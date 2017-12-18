using Android.App;
using Android.Widget;
using Android.OS;
using LoginIISS.LoginHelper;

namespace LoginIISS
{
    [Activity(Label = "LoginIISS", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static Button btnLogin;
        public static EditText etUser;
        public static EditText etPassword;
        public static bool isLogged;
        public static int idC;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            etUser = FindViewById<EditText>(Resource.Id.etUsername);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);

            btnLogin.Click += BtnLogin_ClickAsync;

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
                    "Welcome back !!!");
                alertDialog.SetButton("Continue", (s, ev) =>
                {
                    try
                    {
                        var CameraIntent = new Android.Content.Intent(this, typeof(CameraActivity));
                        StartActivity(CameraIntent);
                        //SetContentView(Resource.Layout.Camera);
                    }
                    catch (System.Exception exception)
                    {
                        System.Diagnostics.Debug.Write(exception.Message);
                    }
                });
                alertDialog.Show();
            }
        }
    }
}