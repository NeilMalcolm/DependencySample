using DependencyHelper.ViewModels;
using System;

namespace DependencyHelper.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ViewModelAttribute : Attribute
    {
        public Type ViewModelType { get; private set; }

        public ViewModelAttribute(Type type)
        {
            if (type.BaseType != typeof(BaseViewModel))
            {
                throw new Exception($"ViewModel must have BaseViewModel as a base class. Provided type {type.Name} does not inherit from BaseViewModel.");
            }

            ViewModelType = type;
        }
    }
}
