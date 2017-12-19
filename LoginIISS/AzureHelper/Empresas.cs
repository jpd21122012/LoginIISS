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

namespace LoginIISS.AzureHelper
{
    public class Empresas
    {
        public Guid Id { get; set; }
        public int IdC { get; set; }
        public string Nombre { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Correo { get; set; }
        public float Telefono { get; set; }
        public string Workspace { get; set; }
        public string FaceListId { get; set; }
        public string Estado { get; set; }
    }
}