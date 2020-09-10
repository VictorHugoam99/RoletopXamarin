using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using Xamarin.Forms;

namespace RoleTopMobile.Services
{
    public static class Utils
    {
        private static HttpClient client;

        public static HttpClient getClient
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("http://192.168.0.2:5000/api/");
                }

                return client;
            }
        }

        public static ImageSource getImageSourceFromByteArray(byte[] imageArray)
        {
            try
            {
                MemoryStream ms = new MemoryStream(imageArray);
                ImageSource imgSource = ImageSource.FromStream(() => ms);
                return imgSource;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}