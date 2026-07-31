

using WeatherWpfApp.Servises.GeoCoder;
using WeatherWpfApp.Servises.Settings;

namespace WeatherWpfApp.ViewModels
{
    public class LocationViewViewModel : BaseViewModel
    {
        private readonly GeoCoderService geoCoderService;

        private readonly ISettingsServise settingsServise;

        private string locationSearch;

        public string LocationSearch
        {
            get
            {
                return locationSearch;
            }

            set
            {
                locationSearch = value;
                if(string.IsNullOrEmpty(locationSearch))
                {
                    searchResults = null;
                    return;
                }

                Task.Run(async () =>
                {
                    var search = value;
                    if(search != locationSearch)
                    {
                        return;
                    }

                    SearchResults = geoCoderService.GetLocations(value);
                    OnPropertyChanged();
                }
                );                
            }
        }

        private List<GeoLocation> searchResults;

        public List<GeoLocation> SearchResults
        {
            get { return searchResults; }
            set
            {
                //if(settingsServise.Settings.SelectedLocation != null) 
                //{ 
                //    return;
                //}

                searchResults = value;
                OnPropertyChanged();
            }
        }

        public GeoLocation SelectedLocation
        {
            get
            {
                return settingsServise.Settings.SelectedLocation;
            }
            set
            {
                SearchResults = null!;
                if (value != null)
                {
                    settingsServise.Settings.SelectedLocation = value;
                    OnPropertyChanged();
                }
            }
        }

        public LocationViewViewModel(GeoCoderService geoCoderService, ISettingsServise settingsServise)
        {
            this.geoCoderService = geoCoderService;
            this.settingsServise = settingsServise;
        }
    }
}
