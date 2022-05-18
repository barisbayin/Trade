using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class BinanceFuturesUsdtKlineWithSuperTrend : BinanceFuturesUsdtKlineEntity, IEntity
    {
        public int TrendId { get; set; }
        public string SuperTrendSide { get; set; }
        public decimal SuperTrendValue { get; set; }
        public decimal SuperTrendBoth { get; set; }

    }
}
