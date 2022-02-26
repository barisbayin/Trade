using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.Entities
{
    public class FuturesUsdtRenkoBrick
    {
        public int? Id { get; set; }
        public string SymbolPair { get; set; }
        public string KlineInterval { get; set; }
        public string EndType { get; set; }
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public bool IsUp { get; set; }
    }
}
