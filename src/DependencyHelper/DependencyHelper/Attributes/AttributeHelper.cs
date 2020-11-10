using System;
using System.Linq;

namespace DependencyHelper.Attributes
{
    public static class AttributeHelper
    {

        /// <summary>
        /// Gets the attribute of the given type for the provided class.
        /// </summary>
        /// <typeparam name="TAttr">
        /// The attribute to return.
        /// </typeparam>
        /// <typeparam name="TClass">
        /// The class to search for the attribute.
        /// </typeparam>
        /// <param name="declaringClass">
        /// An instance of TClass.
        /// </param>
        /// <returns>
        /// The declared TAttr.
        /// </returns>
        public static TAttr GetAttribute<TAttr, TClass>() where TAttr : Attribute
                                                                        where TClass : class
        {
            return (TAttr)typeof(TClass).GetCustomAttributes(
                typeof(TAttr), true).FirstOrDefault();
        }
    }
}
