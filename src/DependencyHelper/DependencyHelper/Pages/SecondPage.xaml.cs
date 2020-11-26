using DependencyHelper.Attributes;
using DependencyHelper.ViewModels;
using Xamarin.Forms.Xaml;

namespace DependencyHelper.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ViewModel(typeof(SecondViewModel))]
    public partial class SecondPage : BaseContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }
    }
}