﻿using System;
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
    public class Deteccion
    {
        public int IdC { get; set; }
        public Guid Id { get; set; }
        public string Hora { get; set; }
        public string Imagen { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string NombreCriminal { get; set; }
        public string EdadCriminal { get; set; }
        public string DescripcionCriminal { get; set; }
        public string NombreGuardia { get; set; }
        public string Sectorguardia { get; set; }
        public string Dispositivo { get; set; }
        public string Status { get; set; }
        public int IdDisp { get; set; }
    }
}