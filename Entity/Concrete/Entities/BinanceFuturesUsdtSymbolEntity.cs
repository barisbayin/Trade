using System;
using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class BinanceFuturesUsdtSymbolEntity : IEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Pair { get; set; }
        public string BaseAsset { get; set; }
        public int BaseAssetPrecision { get; set; }
        public string MarginAsset { get; set; }
        public string QuoteAsset { get; set; }
        public int QuoteAssetPrecision { get; set; }
        public DateTime ListingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal LiquidationFee { get; set; }
        public decimal MarketTakeBound { get; set; }
        public int PricePrecision { get; set; }
        public int QuantityPrecision { get; set; }
        public decimal RequiredMarginPercent { get; set; }
        public decimal MaintMarginPercent { get; set; }
        public decimal TriggerProtect { get; set; }
        public decimal SettlePlan { get; set; }

        //Filters
        public decimal PriceFilterMinPrice { get; set; }
        public decimal PriceFilterMaxPrice { get; set; }
        public decimal PriceFilterTickSize { get; set; }

        public decimal LotSizeFilterMinQuantity { get; set; }
        public decimal LotSizeFilterMaxQuantity { get; set; }
        public decimal LotSizeFilterStepSize { get; set; }

        public decimal MarketLotSizeFilterMinQuantity { get; set; }
        public decimal MarketLotSizeFilterMaxQuantity { get; set; }
        public decimal MarketLotSizeFilterStepSize { get; set; }

        public int MaxNumberOrders { get; set; }
        public int MaxNumberAlgorithmicOrders { get; set; }

        public decimal PercentPriceFilterMultiplierUp { get; set; }
        public decimal PercentPriceFilterMultiplierDown { get; set; }
        public int PercentPriceFilterMultiplierDecimal { get; set; }

        public decimal MinNotional { get; set; }
    }
}
