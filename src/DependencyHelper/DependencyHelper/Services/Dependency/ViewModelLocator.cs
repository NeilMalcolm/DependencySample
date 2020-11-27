using DependencyHelper.Attributes;
using DependencyHelper.ViewModels;
using System;
using Xamarin.Forms;

namespace DependencyHelper.Services.Dependency
{
    public class ViewModelLocator : IViewModelLocator
    {
        private readonly IDependencyContainer dependencyContainer;
        private readonly IAttributeService attributeService;

        public ViewModelLocator(IDependencyContainer dependencyContainer,
            IAttributeService attributeService)
        {
            this.dependencyContainer = dependencyContainer;
            this.attributeService = attributeService;
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

            if (viewModelType is null)
            {
                throw new Exception($"No ViewModel found for page {typeof(T).Name}");
            }

            return (BaseViewModel)dependencyContainer.Get(viewModelType);
        }

        public Type GetViewModelTypeForPage<T>() where T : Page
        {
            return attributeService.GetAttribute<ViewModelAttribute, T>()?.ViewModelType;
        }
    }
}
