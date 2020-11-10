using Xamarin.Forms;

namespace DependencyHelper.Services
{
    public class ColorService : IColorService
    {
        public Color GetColor()
        {
            return Color.Red;
        }
    }
}
