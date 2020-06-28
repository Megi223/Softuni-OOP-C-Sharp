using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {

        public override bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            //Type[] objType = Assembly.GetExecutingAssembly().GetTypes();
            //foreach (var item in objType)
            //{
            //    var sth = item.GetProperties();
            //    foreach (var secondItem in sth)
            //    {
            //        var sthelse = secondItem.GetCustomAttributes().FirstOrDefault(x => x.GetType().Name == nameof(MyRequiredAttribute));
            //        if (sth == null)
            //        {
            //            return false;
            //        }
            //    }
            //}
            return true;
        }
    }
}
