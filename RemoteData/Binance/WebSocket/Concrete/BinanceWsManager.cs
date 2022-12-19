using System.Collections.Generic;
using Binance.Net.Enums;
using RemoteData.Binance.WebSocket.Abstract;
using System.Threading.Tasks;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Models.Futures.Socket;
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

            var streamKlineData = await _binanceSocketClient.UsdFuturesStreams.SubscribeToKlineUpdatesAsync(symbol, interval, data =>
            {

                binanceFuturesUsdtKlineEntity.SymbolPair = symbol;
                binanceFuturesUsdtKlineEntity.KlineInterval = interval.ToString();
                binanceFuturesUsdtKlineEntity.OpenTime = data.Data.Data.OpenTime;
                binanceFuturesUsdtKlineEntity.OpenPrice = data.Data.Data.OpenPrice;
                binanceFuturesUsdtKlineEntity.HighPrice = data.Data.Data.HighPrice;
                binanceFuturesUsdtKlineEntity.LowPrice = data.Data.Data.LowPrice;
                binanceFuturesUsdtKlineEntity.ClosePrice = data.Data.Data.ClosePrice;
                binanceFuturesUsdtKlineEntity.Volume = data.Data.Data.Volume;
                binanceFuturesUsdtKlineEntity.CloseTime = data.Data.Data.CloseTime;
                binanceFuturesUsdtKlineEntity.QuoteVolume = data.Data.Data.QuoteVolume;
                binanceFuturesUsdtKlineEntity.TradeCount = data.Data.Data.TradeCount;
                binanceFuturesUsdtKlineEntity.TakerBuyBaseVolume = data.Data.Data.TakerBuyBaseVolume;
                binanceFuturesUsdtKlineEntity.TakerBuyQuoteVolume = data.Data.Data.TakerBuyQuoteVolume;

            });


            return binanceFuturesUsdtKlineEntity;
        }



        public async Task<List<BinanceFuturesStreamMarginPosition>> GetCurrentUserDataUpdatesAsync(string listenKey)
        {
            List<BinanceFuturesStreamMarginPosition> binanceFuturesStreamMarginPositions = new List<BinanceFuturesStreamMarginPosition>();
            List<BinanceFuturesStreamPosition> binanceFuturesStreamPositions = new List<BinanceFuturesStreamPosition>();
            
            var streamUserData = await _binanceSocketClient.UsdFuturesStreams.SubscribeToUserDataUpdatesAsync(listenKey, data =>
            {
               

            }, data =>
            {
                var result = data.Data.Positions;

                foreach (var position in result)
                {
                    BinanceFuturesStreamMarginPosition binanceFuturesStreamMarginPosition = new BinanceFuturesStreamMarginPosition();

                    binanceFuturesStreamMarginPosition.Symbol = position.Symbol;
                    binanceFuturesStreamMarginPosition.MarginType = position.MarginType;
                    binanceFuturesStreamMarginPosition.IsolatedWallet = position.IsolatedWallet;
                    binanceFuturesStreamMarginPosition.MarginType = position.MarginType;
                    binanceFuturesStreamMarginPosition.MaintMargin = position.MaintMargin;
                    binanceFuturesStreamMarginPosition.MarkPrice = position.MarkPrice;
                    binanceFuturesStreamMarginPosition.PositionSide = position.PositionSide;
                    binanceFuturesStreamMarginPosition.UnrealizedPnl = position.UnrealizedPnl;

                    binanceFuturesStreamMarginPositions.Add(binanceFuturesStreamMarginPosition);

                }

            }, data => 
            {
                var result = data.Data.UpdateData.Positions;

                foreach (var position in result)
                {
                    BinanceFuturesStreamPosition binanceFuturesStreamPosition = new BinanceFuturesStreamPosition();

                    binanceFuturesStreamPosition.Symbol = position.Symbol;
                    binanceFuturesStreamPosition.Quantity = position.Quantity;
                    binanceFuturesStreamPosition.EntryPrice = position.EntryPrice;
                    binanceFuturesStreamPosition.MarginType = position.MarginType;
                    binanceFuturesStreamPosition.PositionSide = position.PositionSide;
                    binanceFuturesStreamPosition.UnrealizedPnl = position.UnrealizedPnl;
                    binanceFuturesStreamPosition.IsolatedMargin = position.IsolatedMargin;
                    binanceFuturesStreamPosition.RealizedPnl = position.RealizedPnl;

                    binanceFuturesStreamPositions.Add(binanceFuturesStreamPosition);

                }

            }, data =>
            {
                
            }, data =>
            {

            });


            return binanceFuturesStreamMarginPositions;
        }
    }
}
