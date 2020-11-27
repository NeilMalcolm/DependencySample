using DependencyHelper.Attributes;
using DependencyHelper.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DependencyHelper.Tests.AttributesTests
{
    [TestClass]
    public class ViewModelAttributeTests
    {
        [TestMethod]
        [DataRow(typeof(string))]
        [DataRow(typeof(int))]
        public void WhenTypeIsNotSubclassOfBaseViewModel_ThenExceptionIsThrown(Type type)
        {
            Assert.ThrowsException<Exception>
            (
                action: () =>
                {
                    var attr = new ViewModelAttribute(type);
                }, 
                message: $"ViewModel must have BaseViewModel as a base class. Provided type {type.Name} does not inherit from BaseViewModel."
            );
        }

        [DataTestMethod]
        [DataRow(typeof(MainPageViewModel))]
        [DataRow(typeof(SecondViewModel))]
        public void WhenTypeIsSubclassOfBaseViewModel_ThenExceptionIsNotThrown(Type type)
        {
            var attr = new ViewModelAttribute(type);
            Assert.IsNotNull(attr);
            Assert.AreEqual(attr.ViewModelType, type);
        }
    }

}
