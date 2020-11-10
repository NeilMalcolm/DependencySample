using DependencyHelper.Pages;
using DependencyHelper.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DependencyHelper.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        readonly INavigationService _navigationService;

        public ICommand NavigateCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SetupCommands();
        }

        void SetupCommands()
        {
            NavigateCommand = new Command(async () => await Navigate());
        }

        async Task Navigate()
        {
            await _navigationService.PushAsync<SecondPage>();
        }
    }
}
