using DependencyHelper.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DependencyHelper.ViewModels
{
    public class SecondViewModel : BaseViewModel
    {
        readonly IHomeTextService _homeTextService;
        readonly IColorService _colorService;

        private string mainText;
        public string MainText
        {
            get { return mainText; }
            set 
            {
                mainText = value;
                OnPropertyChanged();
            }
        }

        private Color mainTextColor;

        public Color MainTextColor
        {
            get { return mainTextColor; }
            set 
            { 
                mainTextColor = value;
                OnPropertyChanged();
            }
        }


        public SecondViewModel(IHomeTextService homeTextService, IColorService colorService)
        {
            _homeTextService = homeTextService;
            _colorService = colorService;

            Setup();
        }

        public void Setup()
        {
            MainText = _homeTextService.GetText();
            MainTextColor = _colorService.GetColor();
        }
    }
}
