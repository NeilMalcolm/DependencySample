using Xamarin.Forms;

namespace DependencyHelper.Services
{
    public class NativeDependencyService : INativeDependencyService
    {
        /// <summary>
        /// Get the dependency.
        /// </summary>
        /// <typeparam name="T">
        /// The interface or concrete type.
        /// </typeparam>
        public T Get<T>() where T : class
        {
            return DependencyService.Get<T>();
        }
    }
}
