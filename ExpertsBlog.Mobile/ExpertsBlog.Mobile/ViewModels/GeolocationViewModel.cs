using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ExpertsBlog.Mobile.ViewModels
{
    public class GeolocationViewModel : ViewModelBase
    {
        private Location location;
        public Location Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }

        public void CheckAndRequestPermissions()
        {
            Task.Run(async () =>
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status == PermissionStatus.Denied || status == PermissionStatus.Unknown)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                // Geolocation

                try
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();

                    if (location != null)
                    {
                        // Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                        Location = location;
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Handle not supported on device exception
                }
                catch (FeatureNotEnabledException fneEx)
                {
                    // Handle not enabled on device exception
                }
                catch (PermissionException pEx)
                {
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    // Unable to get location
                }
            });
        }
    }
}