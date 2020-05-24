using System;
using System.Collections.Generic;

namespace Cherry.Domain.Common
{
    public class Price : ValueObject
    {
        public Price(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value should be greater than 0");

            Value = value;
        }

        public int Value { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Price price1, Price price2)
        {
            return price1.Value == price2.Value;
        }

        public static bool operator !=(Price price1, Price price2)
        {
            return !(price1 == price2);
        }
    }
}