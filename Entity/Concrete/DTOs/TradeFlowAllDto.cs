using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.DTOs
{
    public class TradeFlowAllDto
    {
        public int? Id { get; set; }
        public string TradeParameterTitle { get; set; }
        public string IndicatorParameterTitle { get; set; }
        public string ApiTitle { get; set; }
        public string SymbolPair { get; set; }
        public string Interval { get; set; }
        public string MarginType { get; set; }
        public int Leverage { get; set; }
        public decimal MaxAmountLimit { get; set; }
        public decimal MaxAmountPercentage { get; set; }
        public bool AddPnlToMaxAmountLimit { get; set; }
        public decimal PercentageOfPnlToBeAdded { get; set; }
        public int OrderRangeBrickQuantity { get; set; }
        public int OrderQuantity { get; set; }
        public string PriceCalculationMethod { get; set; }
        public int CancelOrdersAfterBrick { get; set; }
        public string IndicatorName { get; set; }
        public int Period { get; set; }
        public decimal? Multiplier { get; set; } = 0;
        public string KlineEndType { get; set; }
        public decimal? Parameter1 { get; set; } = 0;
        public decimal? Parameter2 { get; set; } = 0;
        public decimal? Parameter3 { get; set; } = 0;
        public decimal? Parameter4 { get; set; } = 0;
        public decimal? Parameter5 { get; set; } = 0;
        public bool InUse { get; set; } = false;
        public bool IsEnded { get; set; } = false;
        public bool TradeStarted { get; set; }
        public DateTime? TradeStartTime { get; set; }
        public bool TradeEnded { get; set; }
        public DateTime? TradeEndTime { get; set; }
        public bool LookingForPosition { get; set; }
        public bool ReadyToOpenOrder { get; set; }
        public bool OrdersStartedToFill { get; set; }
        public bool AllOrdersFilled { get; set; }
        public bool PositionOpened { get; set; }
        public bool TrackingOpenPosition { get; set; }
        public bool PositionClosedByTakingProfit { get; set; }
        public bool PositionClosedByStopLoss { get; set; }
        public DateTime? PositionClosingTime { get; set; }
        public bool IsSelected { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; } = null;
    }
}
