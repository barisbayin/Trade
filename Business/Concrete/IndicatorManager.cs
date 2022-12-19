using Business.Abstract;
using Core.Utilities.Results;
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

        public IDataResult<List<BinanceFuturesUsdtHeikinAshiKlineEntity>> GetHeikinAshiKlineResult(string symbolPair, string interval, int indicatorParameterId)
        {
            List<BinanceFuturesUsdtHeikinAshiKlineEntity> binanceFuturesUsdtHeikinAshiKlineList = new List<BinanceFuturesUsdtHeikinAshiKlineEntity>();

            Console.WriteLine("Heikin-Ashi klines calculating for SymbolPair: {0}, Interval: {1}", symbolPair, interval);

            var indicatorParameter = _indicatorParameterService.GetIndicatorParameterEntityById(indicatorParameterId).Data;

            var dataList = _binanceKlineService.GetCurrencyKlinesToCalculateIndicatorAsync(symbolPair, interval, Convert.ToInt32(indicatorParameter.Parameter2)).Result.Data;

            IEnumerable<HeikinAshiResult> heikinAshiResults = dataList.GetHeikinAshi();
            int j = 1;

            foreach (var data in heikinAshiResults.OrderBy(x => x.Date))
            {
                var binanceFuturesUsdtHeikinAshiKlineEntity = new BinanceFuturesUsdtHeikinAshiKlineEntity
                    {
                        Id = j,
                        SymbolPair = symbolPair,
                        KlineInterval = interval,
                        OpenTime = data.Date,
                        OpenPrice = data.Open,
                        HighPrice = data.High,
                        LowPrice = data.Low,
                        ClosePrice = data.Close,
                        Volume = data.Volume
                    };

                j++;
                binanceFuturesUsdtHeikinAshiKlineList.Add(binanceFuturesUsdtHeikinAshiKlineEntity);
            }
            return new SuccessDataResult<List<BinanceFuturesUsdtHeikinAshiKlineEntity>>(binanceFuturesUsdtHeikinAshiKlineList);
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

            var dataList = _binanceKlineService.GetCurrencyKlinesToCalculateIndicatorAsync(symbolPair, interval, Convert.ToInt32(indicatorParameter.Parameter2)).Result.Data;

            Console.WriteLine("{0} kline data found for=> Symbol Pair: {1} , Interval: {2}", dataList.Count(), symbolPair, interval);

            IEnumerable<SuperTrendResult> superTrendResults = Indicator.GetSuperTrend(dataList, indicatorParameter.Period, Convert.ToDouble(indicatorParameter.Multiplier));

            int i = -1;
            int j = 0;
            int k = 1;
            int m = 1;
            foreach (var data in dataList.OrderBy(x => x.Date))
            {

                BinanceFuturesUsdtKlineWithSuperTrend binanceFuturesUsdtKlineWithSuperTrend = new BinanceFuturesUsdtKlineWithSuperTrend();

                if (i < indicatorParameter.Period)
                {
                    j++;
                    binanceFuturesUsdtKlineWithSuperTrend.Id = j;
                    binanceFuturesUsdtKlineWithSuperTrend.SymbolPair = symbolPair;
                    binanceFuturesUsdtKlineWithSuperTrend.KlineInterval = interval;
                    binanceFuturesUsdtKlineWithSuperTrend.OpenTime = data.Date;
                    binanceFuturesUsdtKlineWithSuperTrend.OpenPrice = data.Open;
                    binanceFuturesUsdtKlineWithSuperTrend.HighPrice = data.High;
                    binanceFuturesUsdtKlineWithSuperTrend.LowPrice = data.Low;
                    binanceFuturesUsdtKlineWithSuperTrend.ClosePrice = data.Close;
                    binanceFuturesUsdtKlineWithSuperTrend.Volume = data.Volume;
                    binanceFuturesUsdtKlineWithSuperTrend.SuperTrendSide = "NULL";
                    binanceFuturesUsdtKlineWithSuperTrend.SuperTrendValue = 0;
                    binanceFuturesUsdtKlineWithSuperTrend.SuperTrendBoth = 0;

                    i++;
                }

                if (i >= indicatorParameter.Period)
                {
                    j++;
                    binanceFuturesUsdtKlineWithSuperTrend.Id = j;
                    binanceFuturesUsdtKlineWithSuperTrend.SymbolPair = symbolPair;
                    binanceFuturesUsdtKlineWithSuperTrend.KlineInterval = interval;
                    binanceFuturesUsdtKlineWithSuperTrend.OpenTime = data.Date;
                    binanceFuturesUsdtKlineWithSuperTrend.OpenPrice = data.Open;
                    binanceFuturesUsdtKlineWithSuperTrend.HighPrice = data.High;
                    binanceFuturesUsdtKlineWithSuperTrend.LowPrice = data.Low;
                    binanceFuturesUsdtKlineWithSuperTrend.ClosePrice = data.Close;
                    binanceFuturesUsdtKlineWithSuperTrend.Volume = data.Volume;

                    if (superTrendResults.ToArray()[i].UpperBand == null)
                    {
                        binanceFuturesUsdtKlineWithSuperTrend.TrendId = k;
                        m = k + 1;

                        binanceFuturesUsdtKlineWithSuperTrend.SuperTrendSide = "BUY";
                        binanceFuturesUsdtKlineWithSuperTrend.SuperTrendValue = superTrendResults.ToArray()[i].LowerBand.Value;
                    }
                    if (superTrendResults.ToArray()[i].LowerBand == null)
                    {
                        binanceFuturesUsdtKlineWithSuperTrend.TrendId = m;
                        k = m + 1;

                        binanceFuturesUsdtKlineWithSuperTrend.SuperTrendSide = "SELL";
                        binanceFuturesUsdtKlineWithSuperTrend.SuperTrendValue = superTrendResults.ToArray()[i].UpperBand.Value;
                    }

                    binanceFuturesUsdtKlineWithSuperTrend.SuperTrendBoth =
                        superTrendResults.ToArray()[i].SuperTrend.Value;

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



            var dataList = _binanceKlineService.GetCurrencyKlinesToCalculateIndicatorAsync(symbolPair, interval, Convert.ToInt32(indicatorParameter.Parameter2)).Result.Data;

            Console.WriteLine("{0} kline data found for=> Symbol Pair: {1} , Interval: {2}", dataList.Count(), symbolPair, interval);

            IEnumerable<RenkoResult> renkoResults = null;

            if (indicatorParameter.Period == null || indicatorParameter.Period == 0)
            {
                Console.WriteLine("Renko Parameters => BrickSize: {0}, EndType: {1}", indicatorParameter.Parameter1, indicatorParameter.KlineEndType);
                renkoResults = dataList.GetRenko(indicatorParameter.Parameter1.Value, (EndType)Enum.Parse(typeof(EndType), indicatorParameter.KlineEndType));
            }
            if (indicatorParameter.Period > 0)
            {
                Console.WriteLine("Renko Parameters => AtrPeriod: {0}, EndType: {1}", indicatorParameter.Period, indicatorParameter.KlineEndType);
                renkoResults = dataList.GetRenkoAtr(indicatorParameter.Period,
                    (EndType)Enum.Parse(typeof(EndType), indicatorParameter.KlineEndType));
            }



            int i = 1;
            int j = 1;
            int k = 1;
            bool lastRenkoBrickSide = renkoResults.First().IsUp;
            var lastRenkoBrickDateTime = renkoResults.First().Date;

            foreach (var renkoBrick in renkoResults)
            {
                if (renkoBrick.IsUp == true)
                {
                    if (lastRenkoBrickSide != renkoBrick.IsUp)
                    {
                        j++;
                        lastRenkoBrickSide = renkoBrick.IsUp;
                    }

                    if (lastRenkoBrickDateTime != renkoBrick.Date)
                    {
                        k++;
                        lastRenkoBrickDateTime = renkoBrick.Date;
                    }

                    var futuresUsdtRenkoBrick = new FuturesUsdtRenkoBrick
                    {
                        Id = i,
                        TrendId = j,
                        InIntervalTrendId = k,
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

                if (renkoBrick.IsUp == false)
                {
                    if (lastRenkoBrickSide != renkoBrick.IsUp)
                    {
                        j++;
                        lastRenkoBrickSide = renkoBrick.IsUp;
                    }

                    if (lastRenkoBrickDateTime != renkoBrick.Date)
                    {
                        k++;
                        lastRenkoBrickDateTime = renkoBrick.Date;
                    }
                    var futuresUsdtRenkoBrick = new FuturesUsdtRenkoBrick
                    {
                        Id = i,
                        TrendId = j,
                        InIntervalTrendId = k,
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

            }

            return new SuccessDataResult<List<FuturesUsdtRenkoBrick>>(futuresUsdtRenkoBrickList);
        }

        public IDataResult<List<FuturesUsdtRenkoBricksWithSuperTrend>> GetFuturesUsdtRenkoBricksSuperTrend(string symbolPair, string interval, int indicatorParameterId)
        {
            List<CurrencyKlineToCalculateIndicatorDto> currencyKlineToCalculateIndicatorDtoList = new List<CurrencyKlineToCalculateIndicatorDto>();

            var renkoSuperTrendParameters = _indicatorParameterService.GetIndicatorParameterEntityById(indicatorParameterId).Data;

            Console.WriteLine("Renko Parameters => BrickSize: {0}, EndType: {1},ST_Period: {2}, ST_Multiplier: {3} ", renkoSuperTrendParameters.Parameter1, renkoSuperTrendParameters.KlineEndType, renkoSuperTrendParameters.Period, renkoSuperTrendParameters.Multiplier.Value);

            var dataList = _binanceKlineService.GetCurrencyKlinesToCalculateIndicatorAsync(symbolPair, interval, Convert.ToInt32(renkoSuperTrendParameters.Parameter2)).Result.Data;

            Console.WriteLine("{0} kline data found for=> Symbol Pair: {1} , Interval: {2}", dataList.Count(), symbolPair, interval);

            var renkoDataList = dataList.GetRenko(renkoSuperTrendParameters.Parameter1.Value,
                (EndType)Enum.Parse(typeof(EndType), renkoSuperTrendParameters.KlineEndType));

            IEnumerable<SuperTrendResult> renkoSuperTrendResults = dataList.GetRenko(renkoSuperTrendParameters.Parameter1.Value, (EndType)Enum.Parse(typeof(EndType), renkoSuperTrendParameters.KlineEndType)).GetSuperTrend(renkoSuperTrendParameters.Period, Convert.ToDouble(renkoSuperTrendParameters.Multiplier));


            List<FuturesUsdtRenkoBricksWithSuperTrend> futuresUsdtRenkoBricksWithSuperTrends =
                new List<FuturesUsdtRenkoBricksWithSuperTrend>();
            int i = -1;
            foreach (var data in renkoDataList)
            {

                FuturesUsdtRenkoBricksWithSuperTrend futuresUsdtRenkoBricksWithSuperTrend = new FuturesUsdtRenkoBricksWithSuperTrend();

                if (i < renkoSuperTrendParameters.Period)
                {
                    futuresUsdtRenkoBricksWithSuperTrend.SymbolPair = symbolPair;
                    futuresUsdtRenkoBricksWithSuperTrend.KlineInterval = interval;
                    futuresUsdtRenkoBricksWithSuperTrend.OpenTime = data.Date;
                    futuresUsdtRenkoBricksWithSuperTrend.OpenPrice = data.Open;
                    futuresUsdtRenkoBricksWithSuperTrend.HighPrice = data.High;
                    futuresUsdtRenkoBricksWithSuperTrend.LowPrice = data.Low;
                    futuresUsdtRenkoBricksWithSuperTrend.ClosePrice = data.Close;
                    futuresUsdtRenkoBricksWithSuperTrend.Volume = data.Volume;
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

                if (i >= renkoSuperTrendParameters.Period)
                {
                    futuresUsdtRenkoBricksWithSuperTrend.SymbolPair = symbolPair;
                    futuresUsdtRenkoBricksWithSuperTrend.KlineInterval = interval;
                    futuresUsdtRenkoBricksWithSuperTrend.OpenTime = data.Date;
                    futuresUsdtRenkoBricksWithSuperTrend.OpenPrice = data.Open;
                    futuresUsdtRenkoBricksWithSuperTrend.HighPrice = data.High;
                    futuresUsdtRenkoBricksWithSuperTrend.LowPrice = data.Low;
                    futuresUsdtRenkoBricksWithSuperTrend.ClosePrice = data.Close;
                    futuresUsdtRenkoBricksWithSuperTrend.Volume = data.Volume;
                    if (renkoSuperTrendResults.ToArray()[i].UpperBand == null)
                    {
                        futuresUsdtRenkoBricksWithSuperTrend.SuperTrendSide = "BUY";
                        futuresUsdtRenkoBricksWithSuperTrend.SuperTrendValue = renkoSuperTrendResults.ToArray()[i].LowerBand.Value;
                    }
                    if (renkoSuperTrendResults.ToArray()[i].LowerBand == null)
                    {
                        futuresUsdtRenkoBricksWithSuperTrend.SuperTrendSide = "SELL";
                        futuresUsdtRenkoBricksWithSuperTrend.SuperTrendValue = renkoSuperTrendResults.ToArray()[i].UpperBand.Value;
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
            Console.WriteLine("RenkoSuperTrend calculated and data added to list!");

            return new SuccessDataResult<List<FuturesUsdtRenkoBricksWithSuperTrend>>(futuresUsdtRenkoBricksWithSuperTrends);
        }
    }
}
