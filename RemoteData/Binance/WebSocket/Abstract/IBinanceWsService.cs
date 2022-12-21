using Binance.Net.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Binance.Net.Objects.Models.Futures.Socket;
using Entity.Concrete.Entities;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;

namespace RemoteData.Binance.WebSocket.Abstract
{
    public interface IBinanceWsService
    {
        Task<BinanceFuturesUsdtKlineEntity> GetCurrentFuturesUsdtKlineDataAsync(string symbol, KlineInterval interval);

        Task<BinanceFuturesUsdtKlineEntity> GetCurrentFuturesUsdtKlineDataListAsync(IEnumerable<string> symbolList,
            KlineInterval interval);
        Task<List<BinanceFuturesStreamMarginPosition>> GetCurrentUserDataUpdatesAsync(string listenKey);

    }
}
