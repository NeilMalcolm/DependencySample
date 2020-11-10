using DependencyHelper.Services;
using System;

namespace DependencyHelper
{
    public class DependencyHelper
    {
        INativeDependencyService _nativeDependencyService;
        IDependencyContainer _sharedDependencyContainer;

        public DependencyHelper(INativeDependencyService nativeDependencyService)
        {
            _nativeDependencyService = nativeDependencyService;
            SetUpContainer();
        }

        public DependencyHelper() : 
            this (new NativeDependencyService())
        {

        }

        /// <summary>
        /// Get the dependency.
        /// </summary>
        /// <typeparam name="T">
        /// The interface or concrete type.
        /// </typeparam>
        public T Get<T>() where T : class
        {
            return _sharedDependencyContainer.Get<T>();
        }

        /// <summary>
        /// Get the dependency.
        /// </summary>
        /// <param name="type">
        /// The type to retrieve.
        /// </param>
        public object Get(Type type)
        {
            return _sharedDependencyContainer.Get(type);
        }

        void SetUpContainer()
        {
            if (_sharedDependencyContainer != null)
            {
                return;
            }

            _sharedDependencyContainer = _nativeDependencyService.Get<IDependencyContainer>();
            _sharedDependencyContainer.RegisterDependencies();
        }
    }
}
