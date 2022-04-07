using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Binance.Net.Objects.Futures.MarketData;
using Binance.Net.Objects.Spot.MarketData;
using Binance.Net.Objects.Spot.SpotData;
using Entity.Concrete.Entities;

namespace RemoteData.Binance.GeneralApi.Abstract
{
    public interface IBinanceApiService
    {
        Task<IDataResult<IEnumerable<BinanceOrder>>> GetAccountInformation();
        Task<IDataResult<IEnumerable<IBinanceKline>>> GetBaseLimitedKlineDataForFuturesUsdtAsync(string symbolPair, KlineInterval interval, DateTime endTime, DateTime startTime);

        Task<IDataResult<IEnumerable<BinanceFuturesUsdtKlineEntity>>> GetSpecificKlineDataForFuturesUsdtAsync(string symbolPair, string interval, DateTime startTime);

        Task<IDataResult<IEnumerable<BinanceFuturesUsdtSymbol>>> GetBinanceFuturesUsdtSymbolInformationListAsync();
        Task<IDataResult<IEnumerable<BinanceSymbol>>> GetBinanceSpotSymbolInformationListAsync();
        Task<IDataResult<List<string>>> GetBinanceFuturesUsdtSymbolPairsAsync();
        Task<IDataResult<List<string>>> GetBinanceSpotUsdtSymbolPairsAsync();
        Task<IDataResult<List<string>>> GetBinanceSpotBtcSymbolPairsAsync();
        Task<IDataResult<List<string>>> GetBinanceSpotEthSymbolPairsAsync();

        Task<IResult> PlaceFuturesUsdtLimitOrder(string symbolPair, string orderSide, decimal quantity, string positionSide, decimal price);
        Task<IResult> SetLeverageForFuturesUsdtSymbolPair(string symbolPair, int leverage);

    }
}
