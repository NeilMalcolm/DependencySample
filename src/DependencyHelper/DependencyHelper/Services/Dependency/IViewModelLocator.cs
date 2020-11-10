using DependencyHelper.ViewModels;
using System;
using Xamarin.Forms;

namespace DependencyHelper.Services.Dependency
{
    public interface IViewModelLocator
    {
        BaseViewModel Get<T>() where T : Page;
        Type GetViewModelTypeForPage<T>() where T : Page;
    }
}
