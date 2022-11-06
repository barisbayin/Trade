using System;
using System.Collections.Generic;
using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Core.Entities;
using Core.Utilities.Results;
using Entity.Concrete;
using RemoteData.Binance.WebSocket.Abstract;
using RemoteData.Constants;
using System.Threading.Tasks;
using Binance.Net.Objects.Futures.UserStream;
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



        public async Task<List<BinanceFuturesStreamMarginPosition>> GetCurrentUserDataUpdatesAsync(string listenKey)
        {
            List<BinanceFuturesStreamMarginPosition> binanceFuturesStreamMarginPositions = new List<BinanceFuturesStreamMarginPosition>();
            List<BinanceFuturesStreamPosition> binanceFuturesStreamPositions = new List<BinanceFuturesStreamPosition>();
            
            var streamUserData = await _binanceSocketClient.FuturesUsdt.SubscribeToUserDataUpdatesAsync(listenKey, data =>
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
                    binanceFuturesStreamMarginPosition.PositionAmount = position.PositionAmount;
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
