using DependencyHelper.Attributes;
using DependencyHelper.ViewModels;
using System;
using Xamarin.Forms;

namespace DependencyHelper.Services.Dependency
{
    public class ViewModelLocator : IViewModelLocator
    {
        private readonly IDependencyContainer dependencyContainer;

        public ViewModelLocator(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        /// <summary>
        /// Gets the ViewModel for the <c>page</c> of type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the page to retrieve the ViewModel for.
        /// </typeparam>
        public BaseViewModel Get<T>() where T : Page
        {
            var viewModelType = GetViewModelTypeForPage<T>();
            return (BaseViewModel)dependencyContainer.Get(viewModelType);
        }

        public Type GetViewModelTypeForPage<T>() where T : Page
        {
            return AttributeHelper.GetAttribute<ViewModelAttribute, T>()?.ViewModelType;
        }
    }
}
