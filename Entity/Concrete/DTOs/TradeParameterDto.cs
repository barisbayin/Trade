﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.DTOs
{
    public class TradeParameterDto
    {
        public int? Id { get; set; } = null;
        public string TradeParameterTitle { get; set; }
        public string IndicatorParameterTitle { get; set; }
        public string ApiTitle { get; set; }
        public string SymbolPair { get; set; }
        public string Interval { get; set; }
        public string MarginType { get; set; }
        public int Leverage { get; set; }
        public decimal StopLossPercent { get; set; }
        public decimal MaxAmountLimit { get; set; }
        public decimal MaxAmountPercentage { get; set; }
        public bool AddPnlToMaxAmountLimit { get; set; }
        public decimal PercentageOfPnlToBeAdded { get; set; }
        public int NumberOfBricksForEntry { get; set; }
        public int OrderRangeBrickQuantity { get; set; }
        public int OrderQuantity { get; set; }
        public string PriceCalculationMethod { get; set; }
        public int CancelOrdersAfterBrick { get; set; }
        public int NumberOfBricksToBeTolerated { get; set; }
        public bool InUse { get; set; } = false;
        public DateTime CreationDate { get; set; } 
        public DateTime? ModifiedDate { get; set; } = null;
    }
}
