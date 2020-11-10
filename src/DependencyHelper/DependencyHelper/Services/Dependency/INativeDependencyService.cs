 namespace DependencyHelper.Services
{
    public interface INativeDependencyService
    {
        /// <summary>
        /// Get the dependency.
        /// </summary>
        /// <typeparam name="T">
        /// The interface or concrete type.
        /// </typeparam>
        T Get<T>() where T : class;
    }
}
