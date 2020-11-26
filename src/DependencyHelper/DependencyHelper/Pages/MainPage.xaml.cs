using DependencyHelper.Attributes;
using DependencyHelper.ViewModels;
using System.ComponentModel;

namespace DependencyHelper.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    [ViewModel(typeof(MainPageViewModel))]
    public partial class MainPage : BaseContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
