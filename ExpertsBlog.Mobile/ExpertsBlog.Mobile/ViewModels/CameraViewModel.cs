using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ExpertsBlog.Mobile.ViewModels
{
    public class CameraViewModel : ViewModelBase 
    {
        public async void Initialize()
        {
                var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
                if (status == PermissionStatus.Denied || status == PermissionStatus.Unknown)
                {
                    status = await Permissions.RequestAsync<Permissions.Camera>();
                }
        }
    }

}