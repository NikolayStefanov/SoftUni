namespace ValidationAttributes.Attributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if (obj is int valueAsInt)
            {
                if (valueAsInt >= minValue && valueAsInt <= maxValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            throw new ArgumentException("Invalid type!");
        }
    }
}
