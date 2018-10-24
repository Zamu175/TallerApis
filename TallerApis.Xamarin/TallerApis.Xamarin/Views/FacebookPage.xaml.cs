using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TallerAís.Dominio;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TallerApis.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FacebookPage : ContentPage
	{
		public FacebookPage ()
		{
			InitializeComponent ();
            CargarPublicaciones();
		}

        private async void CargarPublicaciones()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.11");

            var request = await client.GetAsync("/ApiRedSocial/api/Publicacion");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var publicaciones = JsonConvert.DeserializeObject<List<Publicacion>>(responseJson);
                listaPublicaciones.ItemsSource = publicaciones;
            }
        }
    }
}