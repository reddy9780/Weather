using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Weather
{
    public partial class TrackLocation : ContentPage
    {
        

        public TrackLocation()
        {
           
            InitializeComponent();
        }

        async void GetWeatherDetails(object Sender, EventArgs e)
        {
            Entry  Zipcode = (Entry)weatherEntry;


            if (Zipcode.Text == null || Zipcode.Text.Trim() == "" )
            {
                await DisplayAlert("Failure", "Please Provide Zipcode", "OK");
                return;
            }


            var uri = new Uri(string.Format("http://api.openweathermap.org/data/2.5/weather?zip=" + Zipcode.Text.Trim() + "&APPID=87df3d089e403369802bccbf055fbe61", string.Empty));

            try
            {
                HttpResponseMessage response = null;
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = 25600;
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    String responseData = response.Content.ReadAsStringAsync().Result;

                    MapModel jsonResponse = JsonConvert.DeserializeObject<MapModel>(responseData);

                    Debug.WriteLine(jsonResponse.message);
                    if (jsonResponse.message == "city not found")
                    {
                        await DisplayAlert("Alert", "City Not Found", "Ok");
                    }
                    else
                    {

                        await this.Navigation.PushAsync(new MapScreen(jsonResponse));
                    }

                }
                else
                {
                    await DisplayAlert("Alert", "City Not Found", "Ok");
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }


        }
    }
}
