using System;

namespace Hulk.Helpers
{
    public static class ConvertHelper
    {
        public static int ToInt(this string value)
        {
            if (!int.TryParse(value, out int result))
                throw new InvalidCastException("string value is wrong");

            return result;
        }
    }
}