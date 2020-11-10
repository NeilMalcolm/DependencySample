using DependencyHelper.Services;

namespace DependencyHelper.Droid.Services
{
    public class HomeTextService_Android : IHomeTextService
    {
        public string GetText()
        {
            return "Android";
        }
    }
}