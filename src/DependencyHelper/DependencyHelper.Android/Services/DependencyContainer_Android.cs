using DependencyHelper.Droid.Services;
using DependencyHelper.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DependencyContainer_Android))]
namespace DependencyHelper.Droid.Services
{
    public class DependencyContainer_Android : BaseDependencyContainer
    {
        protected override void RegisterNativeDependencies()
        {
            Register<IHomeTextService, HomeTextService_Android>(true);
        }
    }
}