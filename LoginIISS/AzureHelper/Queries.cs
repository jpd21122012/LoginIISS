using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;

namespace LoginIISS.AzureHelper
{
    public class Queries
    {
        IMobileServiceTable<Dispositivos> deviceTableObject = App.MobileService1.GetTable<Dispositivos>();
        IMobileServiceTable<Empresas> companyTable = App.MobileService.GetTable<Empresas>();
        IMobileServiceTable<Deteccion> detectionTable = App.MobileService.GetTable<Deteccion>();
        public Dispositivos deviceObj;
        public List<Dispositivos> device = new List<Dispositivos>();
        public List<Empresas> company = new List<Empresas>();
        public static string FaceListId;

        public async Task UpdateOnState()
        {
            try
            {
                deviceObj.isActive = "1";
                deviceObj.Checksum = 49;
                await deviceTableObject.UpdateAsync(deviceObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateOffState()
        {
            try
            {
                deviceObj.isActive = "0";
                deviceObj.Checksum = 48;
                await deviceTableObject.UpdateAsync(deviceObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task GetDispositivosAsync()
        {
            device = await deviceTableObject.Where(devicesTable => devicesTable.Nombre == MainActivity.myDevice).ToListAsync();
            deviceObj = device.First();
            await UpdateOnState();
            await GetFaceIdList();
        }
        public async Task GetFaceIdList()
        {
            try
            {
                company = await companyTable.Where(companyTable => companyTable.IdC == deviceObj.IdC).ToListAsync();
                FaceListId = company.First().FaceListId;
                System.Diagnostics.Debug.WriteLine("FaceListId: " + FaceListId);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}