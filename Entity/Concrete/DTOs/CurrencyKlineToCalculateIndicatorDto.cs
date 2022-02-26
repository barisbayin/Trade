using System;
using Core.Entities;
using Skender.Stock.Indicators;

namespace Entity.Concrete.DTOs
{
    public class CurrencyKlineToCalculateIndicatorDto : IDto, IQuote

    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
    }
}
