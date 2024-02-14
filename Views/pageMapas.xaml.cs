using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Maps;
using System.Text.Json;
using System.Net;

namespace Tarea_1._3_Aplicacion_de_Autor.Views;

public partial class pageMapas : ContentPage
{
	public pageMapas()
	{
		InitializeComponent();
    }

    private async void OnMapTapped(object sender, MapClickedEventArgs e)
    {
        // Get the location of the double tap
        // Get the tap position
        string formattedAddress = null;
        string adminDistrict = null;
        string adminDistrict2 = null;
        string countryRegion = null;
        var position = e.Location;

        string jsonResponse = await GetGeocodeDataAsync(position.Latitude, position.Longitude);

        if(jsonResponse != null)
        {
            // Parse the JSON response using JsonDocument
            JsonDocument jsonDocument = JsonDocument.Parse(jsonResponse);

            // Access the specified field directly
            formattedAddress = jsonDocument.RootElement
            .GetProperty("resourceSets")[0]
            .GetProperty("resources")[0]
            .GetProperty("address")
            .GetProperty("formattedAddress")
            .GetString();

            // Access the specified field directly
            adminDistrict = jsonDocument.RootElement
            .GetProperty("resourceSets")[0]
            .GetProperty("resources")[0]
            .GetProperty("address")
            .GetProperty("adminDistrict")
            .GetString();

            // Access the specified field directly
            adminDistrict2 = jsonDocument.RootElement
            .GetProperty("resourceSets")[0]
            .GetProperty("resources")[0]
            .GetProperty("address")
            .GetProperty("adminDistrict2")
            .GetString();

            // Access the specified field directly
            countryRegion = jsonDocument.RootElement
            .GetProperty("resourceSets")[0]
            .GetProperty("resources")[0]
            .GetProperty("address")
            .GetProperty("countryRegion")
            .GetString();
        }

        

        


        // Agrega el Marcador en la ubicacion
        var marker = new Pin
        {
            Type = PinType.Place,
            Location = new Location (position.Latitude, position.Longitude),
            Label = adminDistrict2+", "+adminDistrict+", "+countryRegion,
            Address = formattedAddress
            
        };
        mapa.Pins.Clear();
        mapa.Pins.Add(marker);
    }

    private async Task<string> GetGeocodeDataAsync(double latitude, double longitude)
    {
        string BingMapsApiKey = "Au7sMtQzyQZRzuQ2krOIbZg8j2MGoHzzOJAmVym6vQjHq_BJ8a1YQGX3iCosFh8u";
        try
        {
            string apiUrl = $"https://dev.virtualearth.net/REST/v1/Locations/{latitude},{longitude}?o=json&key={BingMapsApiKey}";
            //string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&sensor=true/false";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    return jsonResponse;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            return null;
        }
    }
}