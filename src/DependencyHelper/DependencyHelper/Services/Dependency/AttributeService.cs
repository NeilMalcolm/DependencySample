using System;
using System.Linq;

namespace DependencyHelper.Services.Dependency
{
    public class AttributeService : IAttributeService
    {
        public TAttr GetAttribute<TAttr, TClass>() where TAttr : Attribute
                                                   where TClass : class
        {
            return typeof(TClass).GetCustomAttributes(typeof(TAttr), true)
                                 .FirstOrDefault() as TAttr;
        }
    }
}
