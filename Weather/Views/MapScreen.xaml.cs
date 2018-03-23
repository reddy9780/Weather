using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Weather
{
    public partial class MapScreen : ContentPage
    {
        public MapScreen(MapModel MapData)
        {
            InitializeComponent();

            var map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(MapData.coordData.lat, MapData.coordData.lon), Distance.FromMiles(0.3)))
            {
            	IsShowingUser = true,
            	HeightRequest = 100,
            	WidthRequest = 960,
            	VerticalOptions = LayoutOptions.FillAndExpand
            };
            map.MapType = MapType.Street;




            var position = new Position(MapData.coordData.lat, MapData.coordData.lon); // Latitude, Longitude
            var pin = new Pin
            {
            	Type = PinType.Place,
            	Position = position,
                Label = MapData.weatherInfo[0].title,
                Address = MapData.weatherInfo[0].desc
                                 
            };
            map.Pins.Add(pin);




            //var slider = new Slider(1, 18, 1);
            //slider.ValueChanged += (sender, e) => {
            //    var zoomLevel = e.NewValue; // between 1 and 18
            //var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
            //map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            //};


            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            //stack.Children.Add(slider);
                    Content = stack;

        }
    }
}
