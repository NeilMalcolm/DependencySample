using System;

namespace DependencyHelper.Services
{
    public interface IDependencyContainer
    {
        /// <summary>
        /// Get the dependency.
        /// </summary>
        /// <typeparam name="T">
        /// The interface or concrete type.
        /// </typeparam>
        T Get<T>() where T : class;

        /// <summary>
        /// Get the dependency.
        /// </summary>
        /// <param name="type">
        /// The type to retrieve.
        /// </param>
        object Get(Type type);

        /// <summary>
        /// Register all dependencies. Should be called at start-up to ensure
        /// dependencies can be retrieved when needed.
        /// </summary>
        void RegisterDependencies();
    }
}
