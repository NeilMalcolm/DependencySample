using DependencyHelper.iOS.Services;
using DependencyHelper.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DependencyContainer_iOS))]
namespace DependencyHelper.iOS.Services
{
    public class DependencyContainer_iOS : BaseDependencyContainer
    {
        protected override void RegisterNativeDependencies()
        {
            Register<IHomeTextService, HomeTextService_iOS>(true);
        }
    }
}