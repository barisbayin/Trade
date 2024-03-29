﻿using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Core.Utilities.Results;
using RemoteData.Binance.GeneralApi.Abstract;
using RemoteData.Binance.Helpers;
using RemoteData.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Models.Futures;
using Binance.Net.Objects.Models.Spot;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
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
            _binanceClient.SetApiCredentials(new ApiCredentials(apiKey,secretKey));
        }

        #region Kline Codes
        public async Task<IDataResult<IEnumerable<IBinanceKline>>> GetBaseLimitedKlineDataForFuturesUsdtAsync(string symbolPair, KlineInterval interval, DateTime endTime, DateTime startTime)
        {
           
            var data = await _binanceClient.UsdFuturesApi.ExchangeData.GetKlinesAsync(symbolPair, interval, startTime, endTime, limit: 1000);

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
                            var binanceFuturesUsdtKlineEntity = new BinanceFuturesUsdtKlineEntity
                            {
                                SymbolPair = symbolPair,
                                KlineInterval = interval.ToString(),
                                OpenTime = data.OpenTime,
                                OpenPrice = data.OpenPrice,
                                HighPrice = data.HighPrice,
                                LowPrice = data.LowPrice,
                                ClosePrice = data.ClosePrice,
                                Volume = data.Volume,
                                CloseTime = data.CloseTime,
                                QuoteVolume = data.QuoteVolume,
                                TradeCount = data.TradeCount,
                                TakerBuyBaseVolume = data.TakerBuyBaseVolume,
                                TakerBuyQuoteVolume = data.TakerBuyQuoteVolume
                            };


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
            var result = await _binanceClient.UsdFuturesApi.Account.GetAccountInfoAsync();

            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {
                return new SuccessDataResult<BinanceFuturesAccountInfo>(result.Data);
            }

            return new ErrorDataResult<BinanceFuturesAccountInfo>(result.Error.Code + ": " + result.Error.Message);
        }
        public async Task<IDataResult<BinanceFuturesPlacedOrder>> PlaceFuturesUsdtLimitOrderAsync(string symbolPair, string orderSide, decimal quantity, string positionSide, decimal price)
        {

            var result = await _binanceClient.UsdFuturesApi.Trading.PlaceOrderAsync(symbolPair,
                (OrderSide)Enum.Parse(typeof(OrderSide), orderSide), FuturesOrderType.Limit, quantity, price,
                (PositionSide)Enum.Parse(typeof(PositionSide), positionSide), TimeInForce.GoodTillCanceled, null, 
                null, null, null, null, null, null, null, null, null, CancellationToken.None);

            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {
                return new SuccessDataResult<BinanceFuturesPlacedOrder>(result.Data,
                    "Limit Order Placed: " + result.Data.Symbol + " | " + result.Data.Side + " | " +
                    result.Data.PositionSide + " | " + result.Data.Price + " | " + result.Data.Quantity);

            }

            return new SuccessDataResult<BinanceFuturesPlacedOrder>(result.Data, RemoteDataMessages.AnErrorOccurredWhilePlacingOrder + ": " + result.Error.Code + ": " + result.Error.Message);

        }

        public async Task<IDataResult<IEnumerable<CallResult<BinanceFuturesPlacedOrder>>>>
            PlaceFuturesUsdtMultipleLimitOrdersByPriceCalculationMethodAsync(string symbolPair, string orderSide,
                string positionSide, decimal maximumBalanceLimit, decimal maxBalancePercentage, int leverage,
                int orderCount, decimal limitPrice, string priceCalculationMethod, decimal brickSize,
                int orderRangeBrickQuantity, int pricePrecision, int quantityPrecision)
        {
            var balancePerOrder = Convert.ToDecimal(maximumBalanceLimit * maxBalancePercentage / 100 * leverage / orderCount);

            BinanceFuturesBatchOrder[] binanceFuturesBatchOrderArray = new BinanceFuturesBatchOrder[orderCount];

            for (int i = 0; i < orderCount; i++)
            {
                var price = 0M;

                var additionalPrice = brickSize / 2;

                if (positionSide == "Long")
                {
                    switch (priceCalculationMethod)
                    {
                        case "Random":
                            price = Math.Round(Convert.ToDecimal(RandomNumberGenerator.RandomDoubleNumberBetween(Convert.ToDouble(limitPrice),
                                Convert.ToDouble(limitPrice + brickSize * orderRangeBrickQuantity))), pricePrecision);
                            break;
                        case "Linear":
                            price = Math.Round(limitPrice + additionalPrice, pricePrecision);

                            var newAdditionalPrice = additionalPrice + brickSize / 2;
                            additionalPrice = newAdditionalPrice;
                            break;
                    }
                }

                if (positionSide == "Short")
                {
                    switch (priceCalculationMethod)
                    {
                        case "Random":
                            price = Math.Round(Convert.ToDecimal(RandomNumberGenerator.RandomDoubleNumberBetween(Convert.ToDouble(limitPrice - brickSize * orderRangeBrickQuantity), Convert.ToDouble(limitPrice))), pricePrecision);
                            break;
                        case "Linear":
                            price = Math.Round(limitPrice - additionalPrice, pricePrecision);

                            var newAdditionalPrice = additionalPrice + brickSize / 2;
                            additionalPrice = newAdditionalPrice;
                            break;
                    }
                }

                var quantity = Math.Round(Convert.ToDecimal(balancePerOrder / price), quantityPrecision);

                var binanceFuturesBatchOrder = new BinanceFuturesBatchOrder
                {
                    Symbol = symbolPair,
                    Side = (OrderSide)Enum.Parse(typeof(OrderSide), orderSide),
                    PositionSide = (PositionSide)Enum.Parse(typeof(PositionSide), positionSide),
                    Type = FuturesOrderType.Limit,
                    TimeInForce = TimeInForce.GoodTillCanceled,
                    Price = price,
                    Quantity = quantity
                };


                binanceFuturesBatchOrderArray[i] = binanceFuturesBatchOrder;

            }

            var result = await _binanceClient.UsdFuturesApi.Trading.PlaceMultipleOrdersAsync(binanceFuturesBatchOrderArray);


            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {
                List<string> controlResults = new List<string>();
                foreach (var data in result.Data)
                {

                    controlResults.Add(data.Success ? "Success" : "Error");

                }

                if (controlResults.Any(x => x == "Success"))
                {
                    return new SuccessDataResult<IEnumerable<CallResult<BinanceFuturesPlacedOrder>>>(result.Data, "Order/s placed successfully!");
                }

                return new ErrorDataResult<IEnumerable<CallResult<BinanceFuturesPlacedOrder>>>(result.Data, RemoteDataMessages.AnErrorOccurredWhilePlacingOrder);

            }

            return new ErrorDataResult<IEnumerable<CallResult<BinanceFuturesPlacedOrder>>>(result.Data, RemoteDataMessages.AnErrorOccurredWhilePlacingOrder + ": " + result.Error.Code + ": " + result.Error.Message);

        }



        public async Task<IDataResult<BinanceFuturesCancelAllOrders>> CancelAllFuturesUsdtLimitOrdersBySymbolPairAsync(string symbolPair)
        {
            var result = await _binanceClient.UsdFuturesApi.Trading.CancelAllOrdersAsync(symbolPair);

            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {
                return new SuccessDataResult<BinanceFuturesCancelAllOrders>(result.Data,
                    "Limit Orders Canceled: " + result.Data.Code + " | " + result.Data.Message);

            }

            return new SuccessDataResult<BinanceFuturesCancelAllOrders>(result.Data, RemoteDataMessages.AnErrorOccurredWhilePlacingOrder + ": " + result.Error.Code + ": " + result.Error.Message);
        }

        public async Task<IDataResult<BinanceFuturesPlacedOrder>> CloseFuturesUsdtPositionByMarketOrderAsync(string symbolPair, string orderSide, decimal quantity, string positionSide)
        {
            var result = await _binanceClient.UsdFuturesApi.Trading.PlaceOrderAsync(symbolPair,
                (OrderSide)Enum.Parse(typeof(OrderSide), orderSide),FuturesOrderType.Market, quantity, null, (PositionSide)Enum.Parse(typeof(PositionSide), positionSide),  null, null, null, null, null, null, null, null, null, null, null, CancellationToken.None);


            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {
                return new SuccessDataResult<BinanceFuturesPlacedOrder>(result.Data,
                    "Close Market Order Placed=> " +"Order Id: "+ result.Data.Id+ " | " + "Symbol:" + result.Data.Symbol + " | " + "Position Side: "+ result.Data.PositionSide + " | " + "Order Side: "+
                    result.Data.PositionSide + " | " + "Avg. Price: "+ result.Data.AveragePrice + " | " +"Filled Quantity: " + result.Data.QuantityFilled);

            }

            return new SuccessDataResult<BinanceFuturesPlacedOrder>(result.Data, RemoteDataMessages.AnErrorOccurredWhilePlacingOrder + ": " + result.Error.Code + ": " + result.Error.Message);
        }

        public async Task<IResult> SetLeverageForFuturesUsdtSymbolPairAsync(string symbolPair, int leverage)
        {
            var result = await _binanceClient.UsdFuturesApi.Account.ChangeInitialLeverageAsync(symbolPair, leverage);

            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {
                return new SuccessResult(RemoteDataMessages.LeverageSet + ": " + result.Data.Symbol + " Leverage: " + result.Data.Leverage);
            }

            return new ErrorResult(RemoteDataMessages.AnErrorOccurredWhileSettingLeverage + ": " + result.Error.Code + ": " + result.Error.Message);
        }

        public async Task<IResult> SetMarginTypeForFuturesUsdtSymbolPairAsync(string symbolPair, string marginType)
        {
            var result = await _binanceClient.UsdFuturesApi.Account.ChangeMarginTypeAsync(symbolPair, (FuturesMarginType)Enum.Parse(typeof(FuturesMarginType), marginType));

            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {
                return new SuccessResult(RemoteDataMessages.MarginTypeSet + ": " + result.Data.Message);
            }

            if (result.ResponseStatusCode == HttpStatusCode.BadRequest && result.Error.Code == -4046)
            {
                return new SuccessResult(RemoteDataMessages.MarginTypeSet + ": Margin type already " + marginType.ToUpper());
            }

            return new ErrorResult(RemoteDataMessages.AnErrorOccurredWhileSettingMarginType + ": " + result.Error.Code + ": " + result.Error.Message);
        }


        public async Task<IDataResult<IEnumerable<BinanceFuturesOrder>>> GetFuturesUsdtPlacedOrdersBySymbolPairAsync(string symbolPair)
        {
            var result = await _binanceClient.UsdFuturesApi.Trading.GetOpenOrdersAsync(symbolPair);
            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {
                return new SuccessDataResult<IEnumerable<BinanceFuturesOrder>>(result.Data);
            }

            return new ErrorDataResult<IEnumerable<BinanceFuturesOrder>>(RemoteDataMessages.Error + ": " + result.Error.Code + ": " + result.Error.Message);
        }

        public async Task<IDataResult<BinanceFuturesOrder>> GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(string symbolPair, long orderId)
        {
            var result = await _binanceClient.UsdFuturesApi.Trading.GetOrderAsync(symbolPair, orderId);

            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {
                return new SuccessDataResult<BinanceFuturesOrder>(result.Data);
            }

            return new ErrorDataResult<BinanceFuturesOrder>(RemoteDataMessages.Error + ": " + result.Error.Code + ": " + result.Error.Message);
        }

        public async Task<IDataResult<string>> StartUserDataStreamAsync()
        {
            var result = await _binanceClient.UsdFuturesApi.Account.StartUserStreamAsync();

            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {

                return new SuccessDataResult<string>(result.Data, result.Data);
            }

            return new ErrorDataResult<string>(RemoteDataMessages.Error + ": " + result.Error.Code + ": " + result.Error.Message);

        }

        public async Task<IDataResult<BinancePositionDetailsUsdt>> GetFuturesUsdtPositionDetailsBySymbolPairAsync(string symbolPair)
        {
            var result = await _binanceClient.UsdFuturesApi.Account.GetPositionInformationAsync(symbolPair);

            if (result.ResponseStatusCode == HttpStatusCode.OK && result.Success)
            {
                var positionControl = result.Data.Any(x => x.EntryPrice > 0);

                if (positionControl == true)
                {
                    var lastOpenPosition = result.Data.FirstOrDefault(x => x.EntryPrice > 0);

                    return new SuccessDataResult<BinancePositionDetailsUsdt>(lastOpenPosition, "Active Position=> Symbol: " + lastOpenPosition.Symbol + " Entry Price: " + lastOpenPosition.EntryPrice + " Quantity: " + lastOpenPosition.Quantity + " Leverage: " + lastOpenPosition.Leverage + " Liquidation Price: " + lastOpenPosition.LiquidationPrice + " PnL: " + lastOpenPosition.UnrealizedPnl + " Isolated Margin:  " + lastOpenPosition.IsolatedMargin);
                }
                else
                {
                    var closedPosition = result.Data.FirstOrDefault();
                    return new SuccessDataResult<BinancePositionDetailsUsdt>(closedPosition,"There is no open position");
                }
    
                
            }


            return new ErrorDataResult<BinancePositionDetailsUsdt>(RemoteDataMessages.Error + ": " + result.Error.Code + ": " + result.Error.Message);
        }

        #endregion

        #region Exchange Information Codes
        public async Task<IDataResult<IEnumerable<BinanceFuturesUsdtSymbol>>> GetBinanceFuturesUsdtSymbolInformationListAsync()
        {

            var binanceFuturesUsdtSymbolInformationList = await _binanceClient.UsdFuturesApi.ExchangeData.GetExchangeInfoAsync();

            if (!binanceFuturesUsdtSymbolInformationList.Success)
            {
                return new ErrorDataResult<IEnumerable<BinanceFuturesUsdtSymbol>>(RemoteDataMessages.ConnectionFailed);
            }

            return new SuccessDataResult<IEnumerable<BinanceFuturesUsdtSymbol>>(binanceFuturesUsdtSymbolInformationList.Data.Symbols);
        }

        public async Task<IDataResult<List<string>>> GetBinanceFuturesUsdtSymbolPairsAsync()
        {
            var binanceFuturesUsdtSymbolInformationList = await _binanceClient.UsdFuturesApi.ExchangeData.GetExchangeInfoAsync();

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
            var binanceSpotSymbolInformationList = await _binanceClient.SpotApi.ExchangeData.GetExchangeInfoAsync();

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
            var binanceSpotUsdtSymbolInformationList = await _binanceClient.SpotApi.ExchangeData.GetExchangeInfoAsync();

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
            var binanceSpotBtcSymbolInformationList = await _binanceClient.SpotApi.ExchangeData.GetExchangeInfoAsync();

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
            var binanceSpotEthSymbolInformationList = await _binanceClient.SpotApi.ExchangeData.GetExchangeInfoAsync();

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
