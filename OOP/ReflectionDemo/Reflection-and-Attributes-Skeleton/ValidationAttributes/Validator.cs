using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes().Where(a=> a is MyValidationAttribute).Cast<MyValidationAttribute>();
                foreach (var attribute in attributes)
                {
                    var result = attribute.IsValid(property.GetValue(obj));
                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
