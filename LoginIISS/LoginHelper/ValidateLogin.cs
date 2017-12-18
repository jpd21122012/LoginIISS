using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LoginIISS.AzureHelper;
using Microsoft.WindowsAzure.MobileServices;

namespace LoginIISS.LoginHelper
{
    public class ValidateLogin
    {
        IMobileServiceTable<Login> userTableObject = App.MobileService.GetTable<Login>();
        string Encrypt(string pass)
        {
            MD5 md5 = MD5.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(pass));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public async Task QueryAsync(string user, string pass)
        {
            List<Login> lista = new List<Login>();
            try
            {
                string password = Encrypt(pass);
                //In this part we do a linq query to get the correct information.
                lista = await userTableObject.Where(userTableObj => userTableObj.User == user && userTableObj.Password == password).ToListAsync();
                var obj = lista[0];
                System.Diagnostics.Debug.WriteLine("Welcome back " + obj.User + " Tu id es: " + obj.IdC, " Intelligent Identificator Security System");
                if (lista.Count == 1)
                {
                    MainActivity.idC = Convert.ToInt32(obj.IdC);
                    MainActivity.isLogged= true;
                }
            }
            catch (Exception ex)
            {
                MainActivity.isLogged = false;
            }
        }
    }
}