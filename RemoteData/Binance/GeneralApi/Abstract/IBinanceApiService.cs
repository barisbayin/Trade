﻿using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Binance.Net.Objects.Models.Futures;
using Binance.Net.Objects.Models.Spot;
using CryptoExchange.Net.Objects;
using Entity.Concrete.Entities;

namespace RemoteData.Binance.GeneralApi.Abstract
{
    public interface IBinanceApiService
    {
        Task<IDataResult<BinanceFuturesAccountInfo>> GetFuturesUsdtAccountInformationAsync();
        Task<IDataResult<IEnumerable<IBinanceKline>>> GetBaseLimitedKlineDataForFuturesUsdtAsync(string symbolPair, KlineInterval interval, DateTime endTime, DateTime startTime);
        Task<IDataResult<IEnumerable<BinanceFuturesUsdtKlineEntity>>> GetSpecificKlineDataForFuturesUsdtAsync(string symbolPair, string interval, DateTime startTime);
        Task<IDataResult<IEnumerable<BinanceFuturesUsdtSymbol>>> GetBinanceFuturesUsdtSymbolInformationListAsync();
        Task<IDataResult<IEnumerable<BinanceSymbol>>> GetBinanceSpotSymbolInformationListAsync();
        Task<IDataResult<List<string>>> GetBinanceFuturesUsdtSymbolPairsAsync();
        Task<IDataResult<List<string>>> GetBinanceSpotUsdtSymbolPairsAsync();
        Task<IDataResult<List<string>>> GetBinanceSpotBtcSymbolPairsAsync();
        Task<IDataResult<List<string>>> GetBinanceSpotEthSymbolPairsAsync();
        Task<IDataResult<BinanceFuturesPlacedOrder>> PlaceFuturesUsdtLimitOrderAsync(string symbolPair, string orderSide, decimal quantity, string positionSide, decimal price);
        Task<IDataResult<IEnumerable<CallResult<BinanceFuturesPlacedOrder>>>> PlaceFuturesUsdtMultipleLimitOrdersByPriceCalculationMethodAsync(string symbolPair, string orderSide, string positionSide, decimal maximumBalanceLimit, decimal maxBalancePercentage, int leverage, int orderCount, decimal limitPrice, string priceCalculationMethod, decimal brickSize, int orderRangeBrickQuantity, int pricePrecision, int quantityPrecision);

        Task<IDataResult<BinanceFuturesCancelAllOrders>> CancelAllFuturesUsdtLimitOrdersBySymbolPairAsync(string symbolPair);
        Task<IDataResult<BinanceFuturesPlacedOrder>> CloseFuturesUsdtPositionByMarketOrderAsync(string symbolPair, string orderSide, decimal quantity, string positionSide);
        Task<IResult> SetLeverageForFuturesUsdtSymbolPairAsync(string symbolPair, int leverage);
        Task<IResult> SetMarginTypeForFuturesUsdtSymbolPairAsync(string symbolPair, string marginType);
        Task<IDataResult<IEnumerable<BinanceFuturesOrder>>> GetFuturesUsdtPlacedOrdersBySymbolPairAsync(string symbolPair);
        Task<IDataResult<BinanceFuturesOrder>> GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(string symbolPair, long orderId);
        Task<IDataResult<string>> StartUserDataStreamAsync();
        Task<IDataResult<BinancePositionDetailsUsdt>> GetFuturesUsdtPositionDetailsBySymbolPairAsync(string symbolPair);




    }
}
