using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteData.Binance.Helpers
{
    public static class RandomNumberGenerator
    {
        private static readonly Random random = new Random();

        public static decimal RandomDoubleNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return Convert.ToDecimal(minValue + (next * (maxValue - minValue))) ;
        }
    }
}
