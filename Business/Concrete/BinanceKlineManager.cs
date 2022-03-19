using Binance.Net.Objects.Futures.MarketData;
using Business.Abstract;
using Business.Helpers;
using Core.Costants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using RemoteData.Binance.GeneralApi.Abstract;
using RemoteData.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace Business.Concrete
{
    public class BinanceKlineManager : IBinanceKlineService
    {
        private readonly IBinanceFuturesUsdtKlineDal _binanceFuturesUsdtKlineDal;
        private readonly IBinanceApiService _binanceKlineApiService;

        public BinanceKlineManager(IBinanceFuturesUsdtKlineDal binanceFuturesUsdtKlineDal)
        {
            _binanceFuturesUsdtKlineDal = binanceFuturesUsdtKlineDal;
        }
        public BinanceKlineManager(IBinanceFuturesUsdtKlineDal binanceFuturesUsdtKlineDal, IBinanceApiService binanceKlineApiService)
        {
            _binanceFuturesUsdtKlineDal = binanceFuturesUsdtKlineDal;
            _binanceKlineApiService = binanceKlineApiService;
        }

        public async Task<IResult> AddFuturesUsdtKlinesToDatabaseAsync(string symbolPair, List<string> intervalList)
        {

            foreach (var interval in intervalList)
            {
                var result = (await CheckIfDatabaseHasFuturesUsdtKlineDataForTheSymbolPairAsync(symbolPair, interval)).Success;

                if (result)
                {
                    var lastKline = (await _binanceFuturesUsdtKlineDal.GetAllAsync(x => x.SymbolPair == symbolPair && x.KlineInterval == interval)).LastOrDefault();

                    await _binanceFuturesUsdtKlineDal.DeleteAsync(lastKline);

                    Console.WriteLine("{0}-{1}, Last kline is deleted!", symbolPair, interval);

                    var lastOpenTime = (await GetFuturesUsdtKlineLastOpenTimeBySymbolPairAndIntervalAsync(symbolPair, interval)).Data;

                    var klineListFromApi = (await _binanceKlineApiService.GetSpecificKlineDataForFuturesUsdtAsync(symbolPair, interval, lastOpenTime)).Data;
                    int i = 0;
                    foreach (var kline in klineListFromApi)
                    {

                        try
                        {
                            await _binanceFuturesUsdtKlineDal.AddAsync(kline);
                            Console.WriteLine("SymbolPair: {1}, Kline Interval: {2}, Open Time: {0} added!", kline.OpenTime, kline.SymbolPair, kline.KlineInterval);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("{1} - {2} - Open Time: {0} is already added!", kline.OpenTime, kline.SymbolPair, kline.KlineInterval);
                            i++;
                        }

                    }

                    Console.WriteLine(klineListFromApi.Count() - i + " " + CommonMessages.FuturesUsdtKlinesAddedToDatabase);
                }
                if (!result)
                {
                    Calculators calculator = new Calculators();

                    var newStartTime = calculator.CalculateStartTimeBasedOnInterval(interval).Result;

                    var klineListFromApi = (await _binanceKlineApiService.GetSpecificKlineDataForFuturesUsdtAsync(symbolPair, interval, newStartTime)).Data;

                    foreach (var kline in klineListFromApi)
                    {
                        try
                        {
                            await _binanceFuturesUsdtKlineDal.AddAsync(kline);
                            Console.WriteLine("SymbolPair: {1}, Kline Interval: {2}, Open Time: {0} added!", kline.OpenTime, kline.SymbolPair, kline.KlineInterval);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("{1} - {2} - Open Time: {0} is already added!", kline.OpenTime, kline.SymbolPair, kline.KlineInterval);
                        }

                    }

                    Console.WriteLine(klineListFromApi.Count() + CommonMessages.FuturesUsdtKlinesAddedToDatabase);
                }
            }

            return new SuccessResult(CommonMessages.FuturesUsdtKlinesAddedToDatabase);
        }

        public IDataResult<IEnumerable<CurrencyKlineToCalculateIndicatorDto>> GetCurrencyKlinesToCalculateIndicator(string symbolPair, string interval)
        {
            return new SuccessDataResult<IEnumerable<CurrencyKlineToCalculateIndicatorDto>>(_binanceFuturesUsdtKlineDal.GetCurrencyKlinesToCalculateIndicator(symbolPair, interval));
        }

        public async Task<IResult> AddOneFuturesUsdtKlineToDatabaseAsync(BinanceFuturesUsdtKlineEntity binanceFuturesUsdtKlineEntity)
        {
            await _binanceFuturesUsdtKlineDal.AddAsync(binanceFuturesUsdtKlineEntity);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateOneFuturesUsdtKlineToDatabaseAsync(BinanceFuturesUsdtKlineEntity binanceFuturesUsdtKlineEntity)
        {
            await _binanceFuturesUsdtKlineDal.UpdateAsync(binanceFuturesUsdtKlineEntity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<BinanceFuturesUsdtKlineEntity>>> GetAllFuturesUsdtKlinesAsync()
        {
            return new SuccessDataResult<List<BinanceFuturesUsdtKlineEntity>>(await _binanceFuturesUsdtKlineDal.GetAllAsync());
        }

        public async Task<IDataResult<List<BinanceFuturesUsdtKlineEntity>>> GetFuturesUsdtKlinesBySymbolPairAsync(string symbolPair)
        {
            return new SuccessDataResult<List<BinanceFuturesUsdtKlineEntity>>(await _binanceFuturesUsdtKlineDal.GetAllAsync(p => p.SymbolPair == symbolPair));
        }

        public async Task<IDataResult<List<BinanceFuturesUsdtKlineEntity>>> GetFuturesUsdtKlinesBySymbolPairAndIntervalAsync(string symbolPair, string interval)
        {
            return new SuccessDataResult<List<BinanceFuturesUsdtKlineEntity>>(await _binanceFuturesUsdtKlineDal.GetAllAsync(p => p.SymbolPair == symbolPair && p.KlineInterval == interval));
        }

        public async Task<IDataResult<DateTime>> GetFuturesUsdtKlineLastOpenTimeBySymbolPairAndIntervalAsync(string symbolPair, string interval)
        {
            var klineList = await _binanceFuturesUsdtKlineDal.GetAllAsync(p => p.SymbolPair == symbolPair && p.KlineInterval == interval);
            if (klineList.Count == 0)
            {
                return new ErrorDataResult<DateTime>(RemoteDataMessages.NoKlineData);
            }
            var lastOpenTime = klineList.Select(d => d.OpenTime).Max();
            return new SuccessDataResult<DateTime>(lastOpenTime);
        }

        public async Task<IDataResult<List<BinanceFuturesUsdtKlineEntity>>> GetFuturesUsdtKlinesBySymbolPairAndMultiIntervalsAsync(string symbolPair, List<string> intervalList)
        {
            List<List<BinanceFuturesUsdtKlineEntity>> listOfListKlines = new List<List<BinanceFuturesUsdtKlineEntity>>();
            foreach (var interval in intervalList)
            {
                var klineList = await GetFuturesUsdtKlinesBySymbolPairAndIntervalAsync(symbolPair, interval);
                listOfListKlines.Add(klineList.Data);
            }
            var binanceFuturesUsdtKlineList = listOfListKlines.SelectMany(x => x).ToList();

            //var binanceFuturesUsdtKlineListWithNoId = binanceFuturesUsdtKlineList.Select(c => { c.Id = null; return c; }).ToList();

            return new SuccessDataResult<List<BinanceFuturesUsdtKlineEntity>>(binanceFuturesUsdtKlineList);
        }

        public async Task<IResult> CheckIfDatabaseHasFuturesUsdtKlineDataForTheSymbolPairAsync(string symbolPair, string interval)
        {
            var dataList = (await _binanceFuturesUsdtKlineDal.GetAllAsync()).GroupBy(s => new { s.SymbolPair, s.KlineInterval }).Distinct().ToList();

            if (dataList.Any(a => a.Key.SymbolPair == symbolPair && a.Key.KlineInterval == interval))
            {
                return new SuccessResult(symbolPair + " " + CommonMessages.FuturesUsdtKlineDataExistsInDatabase);
            }
            else
            {
                return new ErrorResult(CommonMessages.NoFuturesUsdtDataInDatabaseFor + " " + symbolPair);
            }
        }

        public async Task<IDataResult<IEnumerable<CurrencyKlineToCalculateIndicatorDto>>> GetCurrencyKlinesToCalculateIndicatorAsync(string symbolPair, string interval)
        {
            var result = await _binanceFuturesUsdtKlineDal.GetCurrencyKlinesToCalculateIndicatorAsync(symbolPair, interval);
            return new SuccessDataResult<IEnumerable<CurrencyKlineToCalculateIndicatorDto>>(result);
        }

        public IResult DeleteAllFuturesUsdtKlines()
        {
            _binanceFuturesUsdtKlineDal.DeleteAllOrByFilter();
            return new SuccessResult(CommonMessages.AllKlinesDeleted);
        }

        public IResult DeleteFuturesUsdtKlinesBySymbolPair(string symbolPair)
        {
            _binanceFuturesUsdtKlineDal.DeleteAllOrByFilter(i => i.SymbolPair == symbolPair);
            return new SuccessResult("Symbol Pair:" + " " + symbolPair + " " + CommonMessages.KlinesDeleted);
        }

        public IResult DeleteFuturesUsdtKlinesBySymbolPairAndInterval(string symbolPair, string interval)
        {
            _binanceFuturesUsdtKlineDal.DeleteAllOrByFilter(i => i.SymbolPair == symbolPair && i.KlineInterval == interval);
            return new SuccessResult("Symbol Pair:" + " " + symbolPair + "; " + "Interval:" + " " + CommonMessages.KlinesDeleted);
        }

        public IResult DeleteFuturesUsdtKlinesBySymbolPairAndMultiInterval(string symbolPair, List<string> intervalList)
        {
            string intervals = "";
            var stringCreator = new System.Text.StringBuilder();

            foreach (var interval in intervalList)
            {
                _binanceFuturesUsdtKlineDal.DeleteAllOrByFilter(i => i.SymbolPair == symbolPair && i.KlineInterval == interval);
                intervals = stringCreator.Append(interval + ",").ToString();
                intervals = intervals.Remove(intervals.Length - 1, 1);
            }
            return new SuccessResult("Symbol Pair:" + " " + symbolPair + "; " + "Intervals:" + " " + intervals + " " + CommonMessages.KlinesDeleted);
        }
    }
}

