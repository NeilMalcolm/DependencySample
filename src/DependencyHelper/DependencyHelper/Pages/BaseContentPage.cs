
using DependencyHelper.ViewModels;
using Xamarin.Forms;

namespace DependencyHelper.Pages
{
    public class BaseContentPage : ContentPage
    {
        protected BaseViewModel ViewModel { get; set; }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is BaseViewModel vm)
            {
                ViewModel = vm;
            }
            else
            {
                ViewModel = null;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnAppearing();
            ViewModel?.OnDisappearing();
        }
    }
}
