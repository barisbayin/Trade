﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.DTOs
{
    public class TradeFlowPartialDto
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
        public bool AddPnlToMaxAmountLimit { get; set; } = false;
        public decimal? PercentageOfPnlToBeAdded { get; set; } = null;
        public bool InUse { get; set; } = false;
        public bool IsSelected { get; set; } = false;
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; } = null;
    }
}