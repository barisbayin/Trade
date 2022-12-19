using Binance.Net.Objects.Models.Futures;
using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class BinanceFuturesUsdtKlineEntity : BinanceFuturesUsdtKline, IEntity
    {
        public int? Id { get; set; }
        public string SymbolPair { get; set; }
        public string KlineInterval { get; set; }
    }
}
