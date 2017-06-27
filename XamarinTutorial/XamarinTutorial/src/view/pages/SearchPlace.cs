using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using XamarinTutorial.src.model.domain;

namespace XamarinTutorial.src.view.pages
{
    public class SearchPlace : ContentPage
    {
        private const string API_KEY = "your api key";

        public SearchPlace()
        {
            var stack = new StackLayout();
            var search = new SearchBar();
            var listView = new ListView();

            stack.Children.Add(search);
            stack.Children.Add(listView);

            search.TextChanged += async (sender, e) =>
            {
                try
                {
                    var searchBar = (SearchBar)sender;
                    var client = new HttpClient();
                    var url = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + searchBar.Text + "&types=geocode&key=" + API_KEY;

                    var json = await client.GetStringAsync(url);
                    var predictionList = JsonConvert.DeserializeObject<GooglePlaceResult>(json);
                    var srcList = new List<string>();

                    foreach (var place in predictionList.predictions)
                    {
                        srcList.Add(place.description);
                    }

                    listView.ItemsSource = srcList;
                }
                catch (System.Exception)
                {
                    await DisplayAlert("error", "unknown error", "ok");
                }
            };

            Content = stack;
        }
    }
}