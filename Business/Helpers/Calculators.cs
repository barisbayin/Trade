using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete.Entities;

namespace Business.Helpers
{
    public  class Calculators : IDisposable
    {
        public void Dispose()
        {

        }


        public async Task<DateTime> CalculateStartTimeBasedOnInterval(string interval)
        {

            DateTime newStartTime = DateTime.UtcNow;


            IBinanceCommonDatabaseParameterService binanceCommonDatabaseParameterService = new BinanceCommonDatabaseParameterManager(new EfBinanceCommonDatabaseParameterDal());

            newStartTime = newStartTime.AddDays((await binanceCommonDatabaseParameterService.GetFuturesUsdtDayParameterForTheIntervalAsync(interval)).Data * -1);

            return newStartTime;
        }

        public async Task<IDataResult<int>> CalculateKlineAmountByInterval(string klineInterval, int dayParameter)
        {
            int klineAmount = klineInterval switch
            {
                "OneMonth" => Convert.ToInt32(dayParameter / 120),
                "OneWeek" => Convert.ToInt32(dayParameter / 7),
                "ThreeDay" => Convert.ToInt32(dayParameter / 3),
                "OneDay" => dayParameter,
                "TwelveHour" => dayParameter * 2,
                "EightHour" => dayParameter * 3,
                "SixHour" => dayParameter * 4,
                "FourHour" => dayParameter * 6,
                "TwoHour" => dayParameter * 12,
                "OneHour" => dayParameter * 24,
                "ThirtyMinutes" => dayParameter * 48,
                "FifteenMinutes" => dayParameter * 96,
                "FiveMinutes" => dayParameter * 288,
                "ThreeMinutes" => dayParameter * 480,
                "OneMinute" => dayParameter * 1440,
                _ => 0
            };

            return new SuccessDataResult<int>(klineAmount);
        }


        public class RenkoCount
        {
            public string RenkoSide { get; set; }
            public int Count { get; set; }
        }
        public class SuperTrendCount
        {
            public string SuperTrendSide { get; set; }
            public int Count { get; set; }
        }

        public IDataResult<List<RenkoCount>> CalculateFuturesUsdtRenkoCountFromRenkoBrickList(List<FuturesUsdtRenkoBrick> futuresUsdtRenkoBrickList, int renkoCountRange)
        {
            var renkoCountList = new List<RenkoCount>();

            var usingFuturesUsdtRenkoBrick = futuresUsdtRenkoBrickList.OrderByDescending(x=>x.Date).ToList();
            int i = 0;
            int j = 0;
            foreach (var futuresUsdtRenkoBrick in usingFuturesUsdtRenkoBrick)
            {
                if (futuresUsdtRenkoBrick.IsUp == true)
                {
                    if (j > 0)
                    {
                        var renkoCount = new RenkoCount {RenkoSide = "False", Count = j};
                        renkoCountList.Add(renkoCount);
                        j = 0;
                    }

                    i++;
                }
                if (futuresUsdtRenkoBrick.IsUp == false)
                {
                    if (i > 0)
                    {
                        var renkoCount = new RenkoCount {RenkoSide = "True", Count = i};
                        renkoCountList.Add(renkoCount);
                        i = 0;
                    }

                    j++;
                }

            }

            renkoCountList.Reverse();
            var selectedRenkoCountList = renkoCountList.Skip(Math.Max(0, renkoCountList.Count() - renkoCountRange)).Take(renkoCountRange).ToList();
            return new SuccessDataResult<List<RenkoCount>>(selectedRenkoCountList);
        }

        public IDataResult<List<int>> CalculateInIntervalTrendCountFromRenkoBrickList(IEnumerable<FuturesUsdtRenkoBrick> futuresUsdtRenkoBrickList)
        {
            var inIntervalTrendCountList = new List<int>();

            var usingFuturesUsdtRenkoBrick = futuresUsdtRenkoBrickList.OrderByDescending(x => x.Date).GroupBy(x=>x.InIntervalTrendId);

            foreach (var item in usingFuturesUsdtRenkoBrick)
            {
                var inIntervalTrendCount = futuresUsdtRenkoBrickList.Count(x => x.InIntervalTrendId == item.Key);
                inIntervalTrendCountList.Add(inIntervalTrendCount);

            }

            inIntervalTrendCountList.Reverse();
            return new SuccessDataResult<List<int>>(inIntervalTrendCountList);
        }


        public IDataResult<List<SuperTrendCount>> CalculateFuturesUsdtSuperTrendCount(List<BinanceFuturesUsdtKlineWithSuperTrend> binanceFuturesUsdtKlineWithSuperTrendList, int superTrendCountRange)
        {
            var superTrendCountList = new List<SuperTrendCount>();

            var usingSuperTrendKlineList = binanceFuturesUsdtKlineWithSuperTrendList.OrderByDescending(x => x.OpenTime).ToList();
            int i = 0;
            int j = 0;
            foreach (var superTrendKline in usingSuperTrendKlineList)
            {
                if (superTrendKline.SuperTrendSide == "BUY")
                {
                    if (j > 0)
                    {
                        var superTrendCount = new SuperTrendCount() { SuperTrendSide = "SELL", Count = j };
                        superTrendCountList.Add(superTrendCount);
                        j = 0;
                    }

                    i++;
                }
                if (superTrendKline.SuperTrendSide == "SELL")
                {
                    if (i > 0)
                    {
                        var superTrendCount = new SuperTrendCount { SuperTrendSide = "BUY", Count = i };
                        superTrendCountList.Add(superTrendCount);
                        i = 0;
                    }

                    j++;
                }

            }

            superTrendCountList.Reverse();

            if (superTrendCountList.Count>superTrendCountRange)
            {
                var selectedSuperTrendCountList = superTrendCountList.Skip(Math.Max(0, superTrendCountList.Count() - superTrendCountRange)).Take(superTrendCountRange).ToList();
                return new SuccessDataResult<List<SuperTrendCount>>(selectedSuperTrendCountList);
            }

            return new SuccessDataResult<List<SuperTrendCount>>(superTrendCountList);

        }

        public IDataResult<BinanceFuturesUsdtKlineWithSuperTrend> RoundDecimals(
            BinanceFuturesUsdtKlineWithSuperTrend binanceFuturesUsdtKlineWithSuperTrend, int normalizePricePrecision)
        {
            foreach (var item in binanceFuturesUsdtKlineWithSuperTrend.GetType().GetProperties())
            {
                if (item.PropertyType.Name=="Decimal")
                {
                    var value = Math.Round(Convert.ToDecimal(item.GetValue(binanceFuturesUsdtKlineWithSuperTrend)),normalizePricePrecision);
                    item.SetValue(binanceFuturesUsdtKlineWithSuperTrend,value);
                }
            }

            return new SuccessDataResult<BinanceFuturesUsdtKlineWithSuperTrend>(binanceFuturesUsdtKlineWithSuperTrend);
        }
    }
}
