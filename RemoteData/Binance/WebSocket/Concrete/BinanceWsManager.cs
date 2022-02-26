using System;
using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Core.Entities;
using Core.Utilities.Results;
using Entity.Concrete;
using RemoteData.Binance.WebSocket.Abstract;
using RemoteData.Constants;
using System.Threading.Tasks;
using Entity.Concrete.Entities;

namespace RemoteData.Binance.WebSocket.Concrete
{
    public class BinanceWsManager : IBinanceWsService
    {
        private readonly IBinanceSocketClient _binanceSocketClient;

        public BinanceWsManager(IBinanceSocketClient binanceSocketClient)
        {
            _binanceSocketClient = binanceSocketClient;
        }

        public async Task<BinanceFuturesUsdtKlineEntity> GetCurrentFuturesUsdtKlineDataAsync(string symbol, KlineInterval interval)
        {
            BinanceFuturesUsdtKlineEntity binanceFuturesUsdtKlineEntity = new BinanceFuturesUsdtKlineEntity();

            var streamKlineData = await _binanceSocketClient.FuturesUsdt.SubscribeToKlineUpdatesAsync(symbol, interval, data =>
            {

                binanceFuturesUsdtKlineEntity.SymbolPair = symbol;
                binanceFuturesUsdtKlineEntity.KlineInterval = interval.ToString();
                binanceFuturesUsdtKlineEntity.OpenTime = data.Data.Data.OpenTime;
                binanceFuturesUsdtKlineEntity.Open = data.Data.Data.Open;
                binanceFuturesUsdtKlineEntity.High = data.Data.Data.High;
                binanceFuturesUsdtKlineEntity.Low = data.Data.Data.Low;
                binanceFuturesUsdtKlineEntity.Close = data.Data.Data.Close;
                binanceFuturesUsdtKlineEntity.BaseVolume = data.Data.Data.BaseVolume;
                binanceFuturesUsdtKlineEntity.CloseTime = data.Data.Data.CloseTime;
                binanceFuturesUsdtKlineEntity.QuoteVolume = data.Data.Data.QuoteVolume;
                binanceFuturesUsdtKlineEntity.TradeCount = data.Data.Data.TradeCount;
                binanceFuturesUsdtKlineEntity.TakerBuyBaseVolume = data.Data.Data.TakerBuyBaseVolume;
                binanceFuturesUsdtKlineEntity.TakerBuyQuoteVolume = data.Data.Data.TakerBuyQuoteVolume;

            });


            return binanceFuturesUsdtKlineEntity;
        }


    }
}
