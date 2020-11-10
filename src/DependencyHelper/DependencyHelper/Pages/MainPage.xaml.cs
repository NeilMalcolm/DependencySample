using DependencyHelper.Attributes;
using DependencyHelper.Services;
using DependencyHelper.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DependencyHelper.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    [ViewModel(typeof(MainPageViewModel))]
    public partial class MainPage : ContentPage
    {
        IHomeTextService _homeTextService;
        IColorService _colorService;

        public MainPage()
            : this (App.DependencyService.Get<IHomeTextService>(),
                    App.DependencyService.Get<IColorService>())
        {
            InitializeComponent();
            SetupLabel();
        }

        public MainPage (IHomeTextService homeTextService, 
            IColorService colorService)
        {
            _homeTextService = homeTextService;
            _colorService = colorService;
        }

        private void SetupLabel()
        {
            HomeLabel.Text = _homeTextService.GetText();
            HomeLabel.TextColor = _colorService.GetColor();
        }
    }
}
