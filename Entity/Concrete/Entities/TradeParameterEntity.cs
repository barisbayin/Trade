using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.Entities
{
    public class TradeParameterEntity
    {
        public int Id { get; set; }
        public int IndicatorParameterId { get; set; }
        public int ApiInformationId { get; set; }
        public string SymbolPair { get; set; }
        public string Interval { get; set; }
        public string MarginType { get; set; }
        public int Leverage { get; set; }
        public bool BasedOnLimitedAmount { get; set; }
    }
}
