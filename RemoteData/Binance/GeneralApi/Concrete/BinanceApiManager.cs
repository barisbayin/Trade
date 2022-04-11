using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Core.Utilities.Results;
using Entity.Concrete;
using RemoteData.Binance.GeneralApi.Abstract;
using RemoteData.Binance.Helpers;
using RemoteData.Constants;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Objects.Futures.FuturesData;
using Binance.Net.Objects.Futures.MarketData;
using Binance.Net.Objects.Spot.MarketData;
using Binance.Net.Objects.Spot.SpotData;
using Entity.Concrete.Entities;

namespace RemoteData.Binance.GeneralApi.Concrete
{
    public class BinanceApiManager : IBinanceApiService

    {
        private readonly IBinanceClient _binanceClient;


        public BinanceApiManager(IBinanceClient binanceClient)
        {
            _binanceClient = binanceClient;

        }

        public BinanceApiManager(IBinanceClient binanceClient, string apiKey, string secretKey)
        {
            _binanceClient = binanceClient;
            _binanceClient.SetApiCredentials(apiKey, secretKey);
        }

        #region Kline Codes
        public async Task<IDataResult<IEnumerable<IBinanceKline>>> GetBaseLimitedKlineDataForFuturesUsdtAsync(string symbolPair, KlineInterval interval, DateTime endTime, DateTime startTime)
        {

            var data = await _binanceClient.FuturesUsdt.Market.GetKlinesAsync(symbolPair, interval, startTime, endTime, limit: 1000);

            return new SuccessDataResult<IEnumerable<IBinanceKline>>(data.Data);
        }

        public async Task<IDataResult<IEnumerable<BinanceFuturesUsdtKlineEntity>>> GetSpecificKlineDataForFuturesUsdtAsync(string symbolPair, string interval, DateTime startTime)
        {
            var endTime = DateTime.UtcNow;

            List<BinanceFuturesUsdtKlineEntity> specificKlineList = new List<BinanceFuturesUsdtKlineEntity>();

            var dateRangeList = DateTimeCalculator.GetDateTimeRangeList(interval, startTime, endTime);

            if (dateRangeList.Data.Count == 0)
            {
                return new ErrorDataResult<IEnumerable<BinanceFuturesUsdtKlineEntity>>(RemoteDataMessages.NoDatetimeRange);
            }
            else
            {
                foreach (var dateRange in dateRangeList.Data)
                {
                    var dataResult = await GetBaseLimitedKlineDataForFuturesUsdtAsync(symbolPair, (KlineInterval)Enum.Parse(typeof(KlineInterval), interval), dateRange.EndTime, dateRange.StartTime);

                    if (dataResult.Success)
                    {
                        foreach (var data in dataResult.Data)
                        {
                            var binanceFuturesUsdtKlineEntity = new BinanceFuturesUsdtKlineEntity();

                            binanceFuturesUsdtKlineEntity.SymbolPair = symbolPair;
                            binanceFuturesUsdtKlineEntity.KlineInterval = interval.ToString();
                            binanceFuturesUsdtKlineEntity.OpenTime = data.OpenTime;
                            binanceFuturesUsdtKlineEntity.Open = data.Open;
                            binanceFuturesUsdtKlineEntity.High = data.High;
                            binanceFuturesUsdtKlineEntity.Low = data.Low;
                            binanceFuturesUsdtKlineEntity.Close = data.Close;
                            binanceFuturesUsdtKlineEntity.BaseVolume = data.BaseVolume;
                            binanceFuturesUsdtKlineEntity.CloseTime = data.CloseTime;
                            binanceFuturesUsdtKlineEntity.QuoteVolume = data.QuoteVolume;
                            binanceFuturesUsdtKlineEntity.TradeCount = data.TradeCount;
                            binanceFuturesUsdtKlineEntity.TakerBuyBaseVolume = data.TakerBuyBaseVolume;
                            binanceFuturesUsdtKlineEntity.TakerBuyQuoteVolume = data.TakerBuyQuoteVolume;

                            specificKlineList.Add(binanceFuturesUsdtKlineEntity);
                        }
                    }
                    else
                    {
                        return new ErrorDataResult<IEnumerable<BinanceFuturesUsdtKlineEntity>>(RemoteDataMessages.ConnectionFailed);
                    }
                }
            }


            specificKlineList.Sort((u1, u2) =>
            {
                int result = u1.KlineInterval.CompareTo(u2.KlineInterval);
                return result == 0 ? u1.OpenTime.CompareTo(u2.OpenTime) : result;
            });

            return new SuccessDataResult<IEnumerable<BinanceFuturesUsdtKlineEntity>>(specificKlineList);
        }


        #endregion

        #region Order Codes

        public async Task<IDataResult<BinanceFuturesAccountInfo>> GetFuturesUsdtAccountInformationAsync()
        {
            var result = await _binanceClient.FuturesUsdt.Account.GetAccountInfoAsync();

            if (result.ResponseStatusCode == HttpStatusCode.OK)
            {
                return new SuccessDataResult<BinanceFuturesAccountInfo>(result.Data);
            }

            return new ErrorDataResult<BinanceFuturesAccountInfo>(result.Error.Code + ": " + result.Error.Message);
        }
        public async Task<IResult> PlaceFuturesUsdtLimitOrderAsync(string symbolPair, string orderSide, decimal quantity, string positionSide, decimal price)
        {

            var result = await _binanceClient.FuturesUsdt.Order.PlaceOrderAsync(symbolPair,
                (OrderSide)Enum.Parse(typeof(OrderSide), orderSide), OrderType.Limit, quantity,
                (PositionSide)Enum.Parse(typeof(PositionSide), positionSide), TimeInForce.GoodTillCancel, null, price,
                null, null, null, null, null, null, null, null, null, CancellationToken.None);

            if (result.ResponseStatusCode == HttpStatusCode.OK)
            {
                return new SuccessResult("Limit Order Placed: " + symbolPair + " | " + orderSide + " | " + positionSide + " | " + price + " | " + quantity);
            }
            else
            {
                return new ErrorResult(RemoteDataMessages.AnErrorOccurredWhilePlacingOrder + ": " + result.Error.Code + ": " + result.Error.Message);
            }

        }

        public async Task<IResult> SetLeverageForFuturesUsdtSymbolPairAsync(string symbolPair, int leverage)
        {
            var result = await _binanceClient.FuturesUsdt.ChangeInitialLeverageAsync(symbolPair, leverage);

            if (result.ResponseStatusCode == HttpStatusCode.OK)
            {
                return new SuccessResult(RemoteDataMessages.LeverageSet + ": " + symbolPair + " Leverage: " + leverage);
            }
            else
            {
                return new ErrorResult(RemoteDataMessages.AnErrorOccurredWhileSettingLeverage + ": " + result.Error.Code + ": " + result.Error.Message);
            }
        }



        public async Task<IDataResult<IEnumerable<BinanceFuturesOrder>>> GetFuturesUsdtPlacedOrdersBySymbolPairAsync(string symbolPair)
        {
            var result = await _binanceClient.FuturesUsdt.Order.GetOpenOrdersAsync(symbolPair);
            if (result.ResponseStatusCode == HttpStatusCode.OK)
            {
                return new SuccessDataResult<IEnumerable<BinanceFuturesOrder>>(result.Data);
            }
            else
            {
                return new ErrorDataResult<IEnumerable<BinanceFuturesOrder>>(RemoteDataMessages.Error+ ": " + result.Error.Code + ": " + result.Error.Message);
            }
        }

        public async Task<IDataResult<BinanceFuturesOrder>> GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(string symbolPair, long orderId)
        {
            var result = await _binanceClient.FuturesUsdt.Order.GetOrderAsync(symbolPair,orderId);
            if (result.ResponseStatusCode == HttpStatusCode.OK)
            {
                return new SuccessDataResult<BinanceFuturesOrder>(result.Data);
            }
            else
            {
                return new ErrorDataResult<BinanceFuturesOrder>(RemoteDataMessages.Error + ": " + result.Error.Code + ": " + result.Error.Message);
            }
        }

        public async Task<IDataResult<string>> StartUserDataStreamAsync()
        {
            var result = await _binanceClient.FuturesUsdt.UserStream.StartUserStreamAsync();

            if (result.ResponseStatusCode == HttpStatusCode.OK)
            {

                return new SuccessDataResult<string>(result.Data,result.Data);
            }
            else
            {
                return new ErrorDataResult<string>(RemoteDataMessages.Error + ": " + result.Error.Code + ": " + result.Error.Message);
            }
            
        }

        #endregion

        #region Exchange Information Codes
        public async Task<IDataResult<IEnumerable<BinanceFuturesUsdtSymbol>>> GetBinanceFuturesUsdtSymbolInformationListAsync()
        {

            var binanceFuturesUsdtSymbolInformationList = await _binanceClient.FuturesUsdt.System.GetExchangeInfoAsync();

            if (!binanceFuturesUsdtSymbolInformationList.Success)
            {
                return new ErrorDataResult<IEnumerable<BinanceFuturesUsdtSymbol>>(RemoteDataMessages.ConnectionFailed);
            }
            else
            {
                return new SuccessDataResult<IEnumerable<BinanceFuturesUsdtSymbol>>(binanceFuturesUsdtSymbolInformationList.Data.Symbols);
            }
        }

        public async Task<IDataResult<List<string>>> GetBinanceFuturesUsdtSymbolPairsAsync()
        {
            var binanceFuturesUsdtSymbolInformationList = await _binanceClient.FuturesUsdt.System.GetExchangeInfoAsync();

            if (!binanceFuturesUsdtSymbolInformationList.Success)
            {
                return new ErrorDataResult<List<string>>(RemoteDataMessages.ConnectionFailed);
            }
            else
            {
                var futuresUsdtSymbolPairs = new List<string>();

                foreach (var symbol in binanceFuturesUsdtSymbolInformationList.Data.Symbols)
                {
                    futuresUsdtSymbolPairs.Add(symbol.Name);
                }
                futuresUsdtSymbolPairs.Sort();
                return new SuccessDataResult<List<string>>(futuresUsdtSymbolPairs);
            }
        }

        public async Task<IDataResult<IEnumerable<BinanceSymbol>>> GetBinanceSpotSymbolInformationListAsync()
        {
            var binanceSpotSymbolInformationList = await _binanceClient.Spot.System.GetExchangeInfoAsync();

            if (!binanceSpotSymbolInformationList.Success)
            {
                return new ErrorDataResult<IEnumerable<BinanceSymbol>>(RemoteDataMessages.ConnectionFailed);
            }
            else
            {
                return new SuccessDataResult<IEnumerable<BinanceSymbol>>(binanceSpotSymbolInformationList.Data.Symbols);
            }
        }

        public async Task<IDataResult<List<string>>> GetBinanceSpotUsdtSymbolPairsAsync()
        {
            var binanceSpotUsdtSymbolInformationList = await _binanceClient.Spot.System.GetExchangeInfoAsync();

            if (!binanceSpotUsdtSymbolInformationList.Success)
            {
                return new ErrorDataResult<List<string>>(RemoteDataMessages.ConnectionFailed);
            }

            var spotUsdtSymbolPairs = new List<string>();

            foreach (var symbol in binanceSpotUsdtSymbolInformationList.Data.Symbols)
            {
                if (symbol.QuoteAsset == "USDT")
                {
                    spotUsdtSymbolPairs.Add(symbol.Name);
                }
            }
            spotUsdtSymbolPairs.Sort();
            return new SuccessDataResult<List<string>>(spotUsdtSymbolPairs);
        }
        public async Task<IDataResult<List<string>>> GetBinanceSpotBtcSymbolPairsAsync()
        {
            var binanceSpotBtcSymbolInformationList = await _binanceClient.Spot.System.GetExchangeInfoAsync();

            if (!binanceSpotBtcSymbolInformationList.Success)
            {
                return new ErrorDataResult<List<string>>(RemoteDataMessages.ConnectionFailed);
            }
            else
            {
                var spotBtcSymbolPairs = new List<string>();

                foreach (var symbol in binanceSpotBtcSymbolInformationList.Data.Symbols)
                {
                    if (symbol.QuoteAsset == "BTC")
                    {
                        spotBtcSymbolPairs.Add(symbol.Name);
                    }
                }
                spotBtcSymbolPairs.Sort();
                return new SuccessDataResult<List<string>>(spotBtcSymbolPairs);
            }
        }

        public async Task<IDataResult<List<string>>> GetBinanceSpotEthSymbolPairsAsync()
        {
            var binanceSpotEthSymbolInformationList = await _binanceClient.Spot.System.GetExchangeInfoAsync();

            if (!binanceSpotEthSymbolInformationList.Success)
            {
                return new ErrorDataResult<List<string>>(RemoteDataMessages.ConnectionFailed);
            }
            else
            {
                var spotEthSymbolPairs = new List<string>();

                foreach (var symbol in binanceSpotEthSymbolInformationList.Data.Symbols)
                {
                    if (symbol.QuoteAsset == "ETH")
                    {
                        spotEthSymbolPairs.Add(symbol.Name);
                    }
                }
                spotEthSymbolPairs.Sort();
                return new SuccessDataResult<List<string>>(spotEthSymbolPairs);
            }
        }



        #endregion
    }
}
