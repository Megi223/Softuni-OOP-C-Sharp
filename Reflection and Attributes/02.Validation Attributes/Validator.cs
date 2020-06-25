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
            if (obj == null)
            {
                return false;
            }
            //var type = obj.GetType();
            //var props = type.GetProperties();

            //foreach (var item in props)
            //{
            //    var attr = item.GetCustomAttributes().Where(c => c is MyValidationAttribute).Cast<MyValidationAttribute>().ToArray();

            //    foreach (var at in attr)
            //    {
            //        if (!at.IsValid(obj))
            //        {
            //            return false;
            //        }
            //    }
            //}
            Type objType = obj.GetType();
            
            PropertyInfo[] properties = objType.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var attributes = propertyInfo.GetCustomAttributes().Where(x => x is MyValidationAttribute).Cast<MyValidationAttribute>().ToArray();
                foreach (var attr in attributes)
                {
                  if (!attr.IsValid(propertyInfo.GetValue(obj)))
                  {
                     return false;
                  }
                }
            }
            
            return true;
        }
    }
}
