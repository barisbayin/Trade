using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace Business.Abstract
{
    public interface IBinanceKlineService
    {
        IResult DeleteAllFuturesUsdtKlines();
        IResult DeleteFuturesUsdtKlinesBySymbolPair(string symbolPair);
        IResult DeleteFuturesUsdtKlinesBySymbolPairAndInterval(string symbolPair, string interval);
        IResult DeleteFuturesUsdtKlinesBySymbolPairAndMultiInterval(string symbolPair, List<string> intervalList);
        IDataResult<IEnumerable<CurrencyKlineToCalculateIndicatorDto>> GetCurrencyKlinesToCalculateIndicator(
            string symbolPair, string interval, int? dataCount);

        //Async methods...
        Task<IResult> AddOneFuturesUsdtKlineToDatabaseAsync(BinanceFuturesUsdtKlineEntity binanceFuturesUsdtKlineEntity);
        Task<IResult> UpdateOneFuturesUsdtKlineToDatabaseAsync(BinanceFuturesUsdtKlineEntity binanceFuturesUsdtKlineEntity);
        Task<IDataResult<List<BinanceFuturesUsdtKlineEntity>>> GetAllFuturesUsdtKlinesAsync();
        Task<IDataResult<List<BinanceFuturesUsdtKlineEntity>>> GetFuturesUsdtKlinesBySymbolPairAsync(string symbolPair);
        Task<IDataResult<List<BinanceFuturesUsdtKlineEntity>>> GetFuturesUsdtKlinesBySymbolPairAndIntervalAsync(string symbolPair, string interval);
        Task<IResult> AddFuturesUsdtKlinesToDatabaseAsync(string symbolPair, List<string> intervalList);
        Task<IDataResult<DateTime>> GetFuturesUsdtKlineLastOpenTimeBySymbolPairAndIntervalAsync(string symbolPair, string interval);
        Task<IDataResult<List<BinanceFuturesUsdtKlineEntity>>> GetFuturesUsdtKlinesBySymbolPairAndMultiIntervalsAsync(string symbolPair, List<string> intervalList);
        Task<IResult> CheckIfDatabaseHasFuturesUsdtKlineDataForTheSymbolPairAsync(string symbolPair, string interval);
        Task<IDataResult<IEnumerable<CurrencyKlineToCalculateIndicatorDto>>> GetCurrencyKlinesToCalculateIndicatorAsync(string symbolPair, string interval, int? dataCount);

    }
}
