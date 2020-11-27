using System;

namespace DependencyHelper.Services.Dependency
{
    public interface IAttributeService
    {
        TAttr GetAttribute<TAttr, TClass>() where TAttr : Attribute
                                            where TClass : class;
    }
}
