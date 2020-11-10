using DependencyHelper.Services;

namespace DependencyHelper.iOS.Services
{
    public class HomeTextService_iOS : IHomeTextService
    {
        public string GetText()
        {
            return "iOS";
        }
    }
}