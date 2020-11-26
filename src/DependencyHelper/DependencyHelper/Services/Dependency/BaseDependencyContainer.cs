using DependencyHelper.Services.Dependency;
using DependencyHelper.ViewModels;
using SimpleInjector;
using System;

namespace DependencyHelper.Services
{
    public abstract class BaseDependencyContainer : IDependencyContainer
    {
        private Container _dependencyContainer;

        /// <summary>
        /// Get the dependency.
        /// </summary>
        /// <typeparam name="T">
        /// The interface or concrete type.
        /// </typeparam>
        public T Get<T>() where T : class
        {
            return _dependencyContainer.GetInstance<T>();
        }

        /// <summary>
        /// Get the dependency.
        /// </summary>
        /// <param name="type">
        /// The type to retrieve.
        /// </param>
        public object Get(Type type)
        {
            return _dependencyContainer.GetInstance(type);
        }

        /// <summary>
        /// Register all dependencies. Should be called at start-up to ensure
        /// dependencies can be retrieved when needed.
        /// </summary>
        public void RegisterDependencies()
        {
            _dependencyContainer = new Container();
            RegisterNativeDependencies();
            Register<IDependencyContainer>(this);
            Register<IColorService, ColorService>();
            Register<IViewModelLocator, ViewModelLocator>();
            Register<INavigationService, NavigationService>();
            RegisterViewModels();
        }

        /// <summary>
        /// Register a concrete class with the dependency container.
        /// </summary>
        /// <typeparam name="T">
        /// The concrete class to register.
        /// </typeparam>
        /// <param name="singleton">
        /// Whether the registration should be made as a singleton or not.
        /// </param>
        protected void Register<T>(bool singleton = true) where T : class
        {
            if (singleton)
            {
                _dependencyContainer.Register<T>(lifestyle: Lifestyle.Singleton);
            }
            else
            {
                _dependencyContainer.Register<T>();
            }
        }

        protected void Register<T>(T instance) where T : class
        {
            _dependencyContainer.Register(() => instance, Lifestyle.Singleton);
        }

        /// <summary>
        /// Register a given interface and implementation with the dependency container.
        /// </summary>
        /// <typeparam name="TService">
        /// The interface/service to register.
        /// </typeparam>
        /// <typeparam name="TImplementation">
        /// The implementation of <c>TService</c>
        /// </typeparam>
        /// <param name="singleton">
        /// Whether the registration should be made as a singleton or not.
        /// </param>
        protected void Register<TService, TImplementation>(bool singleton = true) where TService : class
                                                                                where TImplementation : class, TService
        {
            if (singleton)
            {
                _dependencyContainer.Register<TService, TImplementation>(lifestyle: Lifestyle.Singleton);
            }
            else
            {
                _dependencyContainer.Register<TService, TImplementation>();
            }
        }

        /// <summary>
        /// Registers any native dependencies.
        /// </summary>
        protected abstract void RegisterNativeDependencies();

        void RegisterViewModels()
        {
            _dependencyContainer.Register<MainPageViewModel>();
            _dependencyContainer.Register<SecondViewModel>();
        }
    }
}
