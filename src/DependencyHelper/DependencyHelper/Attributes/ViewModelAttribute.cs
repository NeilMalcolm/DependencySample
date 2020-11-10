using System;

namespace DependencyHelper.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ViewModelAttribute : Attribute
    {
        public Type ViewModelType { get; private set; }

        public ViewModelAttribute(Type type)
        {
            ViewModelType = type;
        }
    }
}
