using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DependencyHelper.Services
{
    public interface INavigationService 
    {
        Task PushAsync<T>() where T : Page;
        Page GetPageWithViewModel<T>() where T : Page;
    }
}
