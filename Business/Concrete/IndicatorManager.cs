using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.Entities;
using Skender.Stock.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Costants.Messages;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;

namespace Business.Concrete
{
    public class IndicatorManager : IIndicatorService
    {
        private readonly IBinanceKlineService _binanceKlineService;
        private readonly IIndicatorParameterService _indicatorParameterService;
        private readonly IIndicatorDal _indicatorDal;



        public IndicatorManager(IBinanceKlineService binanceKlineService, IIndicatorDal indicatorDal, IIndicatorParameterService indicatorParameterService)
        {
            _binanceKlineService = binanceKlineService;
            _indicatorParameterService = indicatorParameterService;
            _indicatorDal = indicatorDal;
        }

        public IDataResult<IndicatorEntity> GetIndicatorById(int indicatorId)
        {
            return new SuccessDataResult<IndicatorEntity>(_indicatorDal.Get(x => x.Id == indicatorId));
        }

        public async Task<IDataResult<List<IndicatorEntity>>> GetAllIndicatorsAsync()
        {
            try
            {
                return new SuccessDataResult<List<IndicatorEntity>>(await _indicatorDal.GetAllAsync());
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<IndicatorEntity>>(message: CommonMessages.Error);
            }
            
        }

        public IDataResult<List<BinanceFuturesUsdtKlineWithSuperTrend>> GetSuperTrendResult(string symbolPair, string interval, int indicatorParameterId)
        {
            List<BinanceFuturesUsdtKlineWithSuperTrend> binanceFuturesUsdtKlineWithSuperTrendList = new List<BinanceFuturesUsdtKlineWithSuperTrend>();

            var indicatorParameter = _indicatorParameterService.GetIndicatorParameterEntityById(indicatorParameterId).Data;

            Console.WriteLine("SuperTrend Parameters => ATR Period: {0}, Multiplier: {1}", indicatorParameter.Period, indicatorParameter.Multiplier);

            var dataList = _binanceKlineService.GetCurrencyKlinesToCalculateIndicatorAsync(symbolPair, interval).Result.Data;

            Console.WriteLine("{0} kline data found for=> Symbol Pair: {1} , Interval: {2}", dataList.Count(), symbolPair, interval);

            IEnumerable<SuperTrendResult> superTrendResults = Indicator.GetSuperTrend(dataList, indicatorParameter.Period, Convert.ToDouble(indicatorParameter.Multiplier));

            int i = -1;
            foreach (var data in dataList)
            {

                BinanceFuturesUsdtKlineWithSuperTrend binanceFuturesUsdtKlineWithSuperTrend = new BinanceFuturesUsdtKlineWithSuperTrend();

                if (i < indicatorParameter.Period)
                {
                    binanceFuturesUsdtKlineWithSuperTrend.SymbolPair = symbolPair;
                    binanceFuturesUsdtKlineWithSuperTrend.KlineInterval = interval;
                    binanceFuturesUsdtKlineWithSuperTrend.OpenTime = data.Date;
                    binanceFuturesUsdtKlineWithSuperTrend.Open = data.Open;
                    binanceFuturesUsdtKlineWithSuperTrend.High = data.High;
                    binanceFuturesUsdtKlineWithSuperTrend.Low = data.Low;
                    binanceFuturesUsdtKlineWithSuperTrend.Close = data.Close;
                    binanceFuturesUsdtKlineWithSuperTrend.BaseVolume = data.Volume;
                    binanceFuturesUsdtKlineWithSuperTrend.SuperTrendSide = "NULL";
                    binanceFuturesUsdtKlineWithSuperTrend.SuperTrendValue = 0;
                    i++;
                }

                if (i >= indicatorParameter.Period)
                {
                    binanceFuturesUsdtKlineWithSuperTrend.SymbolPair = symbolPair;
                    binanceFuturesUsdtKlineWithSuperTrend.KlineInterval = interval;
                    binanceFuturesUsdtKlineWithSuperTrend.OpenTime = data.Date;
                    binanceFuturesUsdtKlineWithSuperTrend.Open = data.Open;
                    binanceFuturesUsdtKlineWithSuperTrend.High = data.High;
                    binanceFuturesUsdtKlineWithSuperTrend.Low = data.Low;
                    binanceFuturesUsdtKlineWithSuperTrend.Close = data.Close;
                    binanceFuturesUsdtKlineWithSuperTrend.BaseVolume = data.Volume;
                    if (superTrendResults.ToArray()[i].UpperBand == null)
                    {
                        binanceFuturesUsdtKlineWithSuperTrend.SuperTrendSide = "BUY";
                        binanceFuturesUsdtKlineWithSuperTrend.SuperTrendValue = superTrendResults.ToArray()[i].LowerBand.Value;
                    }
                    if (superTrendResults.ToArray()[i].LowerBand == null)
                    {
                        binanceFuturesUsdtKlineWithSuperTrend.SuperTrendSide = "SELL";
                        binanceFuturesUsdtKlineWithSuperTrend.SuperTrendValue = superTrendResults.ToArray()[i].UpperBand.Value;
                    }

                    i++;
                }

                binanceFuturesUsdtKlineWithSuperTrendList.Add(binanceFuturesUsdtKlineWithSuperTrend);


            }
            Console.WriteLine("SuperTrend calculated and data added to list!");

            return new SuccessDataResult<List<BinanceFuturesUsdtKlineWithSuperTrend>>(binanceFuturesUsdtKlineWithSuperTrendList);
        }

        public IDataResult<List<FuturesUsdtRenkoBrick>> GetFuturesUsdtRenkoBricks(string symbolPair, string interval, int indicatorParameterId)
        {
            List<FuturesUsdtRenkoBrick> futuresUsdtRenkoBrickList = new List<FuturesUsdtRenkoBrick>();

            var indicatorParameter = _indicatorParameterService.GetIndicatorParameterEntityById(indicatorParameterId).Data;

            Console.WriteLine("Renko Parameters => BrickSize: {0}, EndType: {1}", indicatorParameter.Parameter1, indicatorParameter.KlineEndType);

            var dataList = _binanceKlineService.GetCurrencyKlinesToCalculateIndicatorAsync(symbolPair, interval).Result.Data;

            Console.WriteLine("{0} kline data found for=> Symbol Pair: {1} , Interval: {2}", dataList.Count(), symbolPair, interval);

            IEnumerable<RenkoResult> renkoResults = Indicator.GetRenko(dataList, indicatorParameter.Parameter1.Value, (EndType)Enum.Parse(typeof(EndType), indicatorParameter.KlineEndType));

            int i = 0;
            foreach (var renkoBrick in renkoResults)
            {
                FuturesUsdtRenkoBrick futuresUsdtRenkoBrick = new FuturesUsdtRenkoBrick
                {
                    Id = i,
                    SymbolPair = symbolPair,
                    KlineInterval = interval,
                    EndType = indicatorParameter.KlineEndType,
                    Date = renkoBrick.Date,
                    Open = renkoBrick.Open,
                    High = renkoBrick.High,
                    Low = renkoBrick.Low,
                    Close = renkoBrick.Close,
                    Volume = renkoBrick.Volume,
                    IsUp = renkoBrick.IsUp
                };


                futuresUsdtRenkoBrickList.Add(futuresUsdtRenkoBrick);
                i++;
            }

            return new SuccessDataResult<List<FuturesUsdtRenkoBrick>>(futuresUsdtRenkoBrickList);
        }

        public IDataResult<List<FuturesUsdtRenkoBricksWithSuperTrend>> GetFuturesUsdtRenkoBricksSuperTrend(string symbolPair, string interval, int renkoBrickParameterId, int superTrendParameterId)
        {
            List<CurrencyKlineToCalculateIndicatorDto> currencyKlineToCalculateIndicatorDtoList = new List<CurrencyKlineToCalculateIndicatorDto>();

            var renkoBrickParameters = _indicatorParameterService.GetIndicatorParameterEntityById(renkoBrickParameterId).Data;

            Console.WriteLine("Renko Parameters => BrickSize: {0}, EndType: {1}", renkoBrickParameters.Multiplier, renkoBrickParameters.KlineEndType);

            var dataList = _binanceKlineService.GetCurrencyKlinesToCalculateIndicatorAsync(symbolPair, interval).Result.Data;

            Console.WriteLine("{0} kline data found for=> Symbol Pair: {1} , Interval: {2}", dataList.Count(), symbolPair, interval);

            IEnumerable<RenkoResult> renkoResults = Indicator.GetRenko(dataList, renkoBrickParameters.Multiplier.Value, (EndType)Enum.Parse(typeof(EndType), renkoBrickParameters.KlineEndType));

            foreach (var renkoBrick in renkoResults)
            {
                CurrencyKlineToCalculateIndicatorDto currencyKlineToCalculateIndicator = new CurrencyKlineToCalculateIndicatorDto();

                currencyKlineToCalculateIndicator.Date = renkoBrick.Date;
                currencyKlineToCalculateIndicator.Open = renkoBrick.Open;
                currencyKlineToCalculateIndicator.High = renkoBrick.High;
                currencyKlineToCalculateIndicator.Low = renkoBrick.Low;
                currencyKlineToCalculateIndicator.Close = renkoBrick.Close;
                currencyKlineToCalculateIndicator.Volume = renkoBrick.Volume;


                currencyKlineToCalculateIndicatorDtoList.Add(currencyKlineToCalculateIndicator);

            }

            currencyKlineToCalculateIndicatorDtoList.OrderBy(x => x.Date);


            List<FuturesUsdtRenkoBricksWithSuperTrend> futuresUsdtRenkoBricksWithSuperTrends = new List<FuturesUsdtRenkoBricksWithSuperTrend>();

            var superTrendParameters = _indicatorParameterService.GetIndicatorParameterEntityById(superTrendParameterId).Data;

            Console.WriteLine("SuperTrend Parameters => ATR Period: {0}, Multiplier: {1}", superTrendParameters.Period, superTrendParameters.Multiplier);


            IEnumerable<SuperTrendResult> superTrendResults = Indicator.GetSuperTrend(currencyKlineToCalculateIndicatorDtoList, superTrendParameters.Period, Convert.ToDouble(superTrendParameters.Multiplier));

            int i = -1;
            foreach (var data in currencyKlineToCalculateIndicatorDtoList)
            {

                FuturesUsdtRenkoBricksWithSuperTrend futuresUsdtRenkoBricksWithSuperTrend = new FuturesUsdtRenkoBricksWithSuperTrend();

                if (i < superTrendParameters.Period)
                {
                    futuresUsdtRenkoBricksWithSuperTrend.SymbolPair = symbolPair;
                    futuresUsdtRenkoBricksWithSuperTrend.KlineInterval = interval;
                    futuresUsdtRenkoBricksWithSuperTrend.OpenTime = data.Date;
                    futuresUsdtRenkoBricksWithSuperTrend.Open = data.Open;
                    futuresUsdtRenkoBricksWithSuperTrend.High = data.High;
                    futuresUsdtRenkoBricksWithSuperTrend.Low = data.Low;
                    futuresUsdtRenkoBricksWithSuperTrend.Close = data.Close;
                    futuresUsdtRenkoBricksWithSuperTrend.BaseVolume = data.Volume;
                    futuresUsdtRenkoBricksWithSuperTrend.SuperTrendSide = "NULL";
                    futuresUsdtRenkoBricksWithSuperTrend.SuperTrendValue = 0;

                    if (data.Open < data.Close)
                    {
                        futuresUsdtRenkoBricksWithSuperTrend.IsUp = true;
                    }
                    else
                    {
                        futuresUsdtRenkoBricksWithSuperTrend.IsUp = false;
                    }

                    i++;
                }

                if (i >= superTrendParameters.Period)
                {
                    futuresUsdtRenkoBricksWithSuperTrend.SymbolPair = symbolPair;
                    futuresUsdtRenkoBricksWithSuperTrend.KlineInterval = interval;
                    futuresUsdtRenkoBricksWithSuperTrend.OpenTime = data.Date;
                    futuresUsdtRenkoBricksWithSuperTrend.Open = data.Open;
                    futuresUsdtRenkoBricksWithSuperTrend.High = data.High;
                    futuresUsdtRenkoBricksWithSuperTrend.Low = data.Low;
                    futuresUsdtRenkoBricksWithSuperTrend.Close = data.Close;
                    futuresUsdtRenkoBricksWithSuperTrend.BaseVolume = data.Volume;
                    if (superTrendResults.ToArray()[i].UpperBand == null)
                    {
                        futuresUsdtRenkoBricksWithSuperTrend.SuperTrendSide = "BUY";
                        futuresUsdtRenkoBricksWithSuperTrend.SuperTrendValue = superTrendResults.ToArray()[i].LowerBand.Value;
                    }
                    if (superTrendResults.ToArray()[i].LowerBand == null)
                    {
                        futuresUsdtRenkoBricksWithSuperTrend.SuperTrendSide = "SELL";
                        futuresUsdtRenkoBricksWithSuperTrend.SuperTrendValue = superTrendResults.ToArray()[i].UpperBand.Value;
                    }

                    if (data.Open < data.Close)
                    {
                        futuresUsdtRenkoBricksWithSuperTrend.IsUp = true;
                    }
                    else
                    {
                        futuresUsdtRenkoBricksWithSuperTrend.IsUp = false;
                    }

                    i++;
                }

                futuresUsdtRenkoBricksWithSuperTrends.Add(futuresUsdtRenkoBricksWithSuperTrend);


            }
            Console.WriteLine("SuperTrend calculated and data added to list!");

            return new SuccessDataResult<List<FuturesUsdtRenkoBricksWithSuperTrend>>(futuresUsdtRenkoBricksWithSuperTrends);
        }
    }
}
