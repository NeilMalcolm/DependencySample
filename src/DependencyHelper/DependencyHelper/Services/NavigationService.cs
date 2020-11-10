using DependencyHelper.Services.Dependency;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DependencyHelper.Services
{
    public class NavigationService : INavigationService
    {
        IViewModelLocator _viewModelLocator;
        public NavigationService(IViewModelLocator viewModelLocator)
        {
            _viewModelLocator = viewModelLocator;
        }

        public async Task PushAsync<T>() where T : Page
        {
            await App.Current.MainPage.Navigation.PushAsync(GetPageWithViewModel<T>());
        }

        public Page GetPageWithViewModel<T>() where T : Page
        {
            var page = (Page)Activator.CreateInstance(typeof(T));
            page.BindingContext = _viewModelLocator.Get<T>();
            return page;
        }
    }
}
