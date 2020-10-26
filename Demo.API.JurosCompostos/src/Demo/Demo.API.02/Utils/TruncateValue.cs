using System;

namespace Demo.API._02.Utils
{
    public class TruncateValue
    {
        public static decimal TruncateDecimal(decimal valor)
        {
            var result = Math.Truncate(valor * 100) / 100;

            return result;
        }
    }
}
