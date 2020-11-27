using DependencyHelper.Pages;
using DependencyHelper.Services;
using DependencyHelper.Services.Dependency;
using DependencyHelper.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using DependencyHelper.Attributes;

namespace DependencyHelper.Tests.ServiceTests
{
    [TestClass]
    public class ViewModelLocatorTests
    {
        private Mock<INavigationService> navigationServiceMock;
        private Mock<IHomeTextService> homeTextServiceMock;
        private Mock<IColorService> colorServiceMock;
        private Mock<IAttributeService> attributeServiceMock;
        private Mock<IDependencyContainer> dependencyContainerMock;
        private IViewModelLocator viewModelLocator;

        [TestInitialize()]
        public void ClassSetup()
        {
            navigationServiceMock = new Mock<INavigationService>();
            homeTextServiceMock = new Mock<IHomeTextService>();
            colorServiceMock = new Mock<IColorService>();

            AttributeServiceSetup();
            DependencyContainerSetup();

            viewModelLocator = new ViewModelLocator(dependencyContainerMock.Object, attributeServiceMock.Object);
        }


        private void AttributeServiceSetup()
        {
            attributeServiceMock = new Mock<IAttributeService>();
            attributeServiceMock.Setup(m => m.GetAttribute<ViewModelAttribute, MainPage>()).Returns(new ViewModelAttribute(typeof(MainPageViewModel)));
            attributeServiceMock.Setup(m => m.GetAttribute<ViewModelAttribute, SecondPage>()).Returns(new ViewModelAttribute(typeof(SecondViewModel)));
        }
        private void DependencyContainerSetup()
        {
            dependencyContainerMock = new Mock<IDependencyContainer>();

            dependencyContainerMock.Setup(m => m.Get(typeof(SecondViewModel)))
                .Returns
                (() => {
                    return new SecondViewModel
                    (
                        homeTextServiceMock.Object,
                        colorServiceMock.Object
                    );
                });

            dependencyContainerMock.Setup(m => m.Get(typeof(MainPageViewModel)))
                .Returns
                (() => {
                    return new MainPageViewModel
                    (
                        navigationServiceMock.Object,
                        homeTextServiceMock.Object,
                        colorServiceMock.Object
                    );
                });
        }


        [TestMethod]
        public void WhenPageAndViewModelAreRegistered_ThenGetViewModelTypeForPageReturnsType()
        {
            var mainPageViewModelType = ViewModelLocator_GetViewModelTypeForPage_TestHelper<MainPage>();
            var secondPageViewModelType = ViewModelLocator_GetViewModelTypeForPage_TestHelper<SecondPage>();
            Assert.AreEqual(typeof(MainPageViewModel), mainPageViewModelType);
            Assert.AreEqual(typeof(SecondViewModel), secondPageViewModelType);
        }

        [TestMethod]
        public void WhenViewModelNotFoundForPageType_ThenGetViewModelTypeForPageReturnsNull()
        {
            var result = ViewModelLocator_GetViewModelTypeForPage_TestHelper<TestPage>();
            Assert.IsNull(result);
        }


        [TestMethod]
        public void WhenPageAndViewModelAreRegistered_ThenViewModelLocatorGetReturnsViewModel()
        {
            var mainPageViewModel = ViewModelLocator_Get_TestHelper<MainPage>();
            var secondPageViewModel = ViewModelLocator_Get_TestHelper<SecondPage>();
            Assert.IsInstanceOfType(mainPageViewModel, typeof(MainPageViewModel));
            Assert.IsInstanceOfType(secondPageViewModel, typeof(SecondViewModel));
        }

        [TestMethod]
        public void WhenViewModelNotPresentForType_ThenViewModelLocatorGetThrowsException()
        {
            Assert.ThrowsException<Exception>(
                action: () => ViewModelLocator_Get_TestHelper<TestPage>(),
                message: $"No ViewModel found for page {typeof(TestPage).Name}"
            );
        }

        #region Helpers

        private BaseViewModel ViewModelLocator_Get_TestHelper<T>() where T : Xamarin.Forms.Page
        {
            return viewModelLocator.Get<T>();
        }

        private Type ViewModelLocator_GetViewModelTypeForPage_TestHelper<T>() where T : Xamarin.Forms.Page
        {
            return viewModelLocator.GetViewModelTypeForPage<T>();
        }

        #endregion


    }


    public class TestPage : BaseContentPage
    {

    }
    public class TestBaseViewModel : BaseViewModel
    {

    }
}
