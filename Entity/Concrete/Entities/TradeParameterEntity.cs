using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.Entities
{
    public class TradeParameterEntity
    {
        public int? Id { get; set; } = null;
        public int IndicatorParameterId { get; set; }
        public int ApiInformationId { get; set; }
        public string SymbolPair { get; set; }
        public string Interval { get; set; }
        public string MarginType { get; set; }
        public int Leverage { get; set; }
        public decimal MaximumAmountLimit { get; set; }
        public decimal MaxAmountPercentage{ get; set; }
        public  bool AddPnlToMaximumAmountLimit { get; set; }
        public decimal PercentageOfPnlToBeAdded { get; set; }
        public bool InUse { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; } = null;
        public bool? Removed { get; set; } = null;
        public DateTime? RemovedDate { get; set; } = null;
        



    }
}
