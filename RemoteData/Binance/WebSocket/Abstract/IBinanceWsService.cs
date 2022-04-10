using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Binance.Net.Objects.Futures.UserStream;
using Entity.Concrete.Entities;

namespace RemoteData.Binance.WebSocket.Abstract
{
    public interface IBinanceWsService
    {
        Task<BinanceFuturesUsdtKlineEntity> GetCurrentFuturesUsdtKlineDataAsync(string symbol, KlineInterval interval);
        Task<List<BinanceFuturesStreamMarginPosition>> GetCurrentUserDataUpdatesAsync(string listenKey);

    }
}
