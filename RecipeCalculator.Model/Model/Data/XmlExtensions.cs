using System;
using System.Xml.Linq;

namespace RecipeCalculator.Model.Data
{
    internal static class XmlExtensions
    {
        public static T Attr<T>(this XElement elem, string attributeName, T defaultValue = default(T))
        {
            var attr = elem.Attribute(attributeName);
            return attr != null ? (T)Convert.ChangeType(attr.Value, typeof(T)) : defaultValue;
        }
    }
}
