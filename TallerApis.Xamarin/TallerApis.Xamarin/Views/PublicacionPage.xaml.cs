using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TallerApis.Xamarin.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TallerApis.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicacionPage : ContentPage
    {
        public PublicacionPage()
        {
            CargarPublicaciones();
        }

        private void CargarPublicaciones()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://192.168.0.11");
            var request = client.GetAsync("/MiSocialApi/api/Publicacion").Result;
            if (request.IsSuccessStatusCode)
            {
                var responseJson = request.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<List<Publicacion>>(responseJson);
                listPublicaciones.ItemsSource = response;
            }
        }
    }
}