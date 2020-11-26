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
        readonly IHomeTextService _homeTextService;
        readonly IColorService _colorService;

        private string mainText;
        private Color mainColor;

        public string MainText
        {
            get => mainText; 
            set 
            { 
                mainText = value;
                OnPropertyChanged();
            }
        }

        public Color MainColor
        {
            get => mainColor;
            set
            {
                mainColor = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService,
            IHomeTextService homeTextService,
            IColorService colorService)
        {

            _navigationService = navigationService;
            _homeTextService = homeTextService;
            _colorService = colorService;
            SetupCommands();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            MainColor = _colorService.GetColor();
            MainText = _homeTextService.GetText();
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
