using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute:MyValidationAttribute
    {
        private int min;
        private int max;
        public MyRangeAttribute(int minValue,int maxValue)
        {
            this.min = minValue;
            this.max = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if(obj is Int32)
            {
                int number = (int)obj;
                if(number<=this.max && number >= this.min)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
