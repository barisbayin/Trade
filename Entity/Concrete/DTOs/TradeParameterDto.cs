using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.DTOs
{
    public class TradeParameterDto
    {
        public int Id { get; set; }
        public int IndicatorParameterTitle { get; set; }
        public int ApiTitle { get; set; }
        public string SymbolPair { get; set; }
        public string Interval { get; set; }
        public string MarginType { get; set; }
        public int Leverage { get; set; }
        public bool InUse { get; set; }
    }
}
