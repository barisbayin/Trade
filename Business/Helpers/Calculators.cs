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
            int klineAmount = 0;

            if (klineInterval == "OneMonth")
            {

                klineAmount = Convert.ToInt32(dayParameter / 120);

            }

            if (klineInterval == "OneWeek")
            {

                klineAmount = Convert.ToInt32(dayParameter / 7);

            }

            if (klineInterval == "ThreeDay")
            {

                klineAmount = Convert.ToInt32(dayParameter / 3);

            }

            if (klineInterval == "OneDay")
            {

                klineAmount = dayParameter;

            }

            if (klineInterval == "TwelveHour")
            {

                klineAmount = dayParameter * 2;

            }

            if (klineInterval == "EightHour")
            {

                klineAmount = dayParameter * 3;

            }

            if (klineInterval == "SixHour")
            {

                klineAmount = dayParameter * 4;

            }

            if (klineInterval == "FourHour")
            {

                klineAmount = dayParameter * 6;

            }

            if (klineInterval == "TwoHour")
            {

                klineAmount = dayParameter * 12;

            }

            if (klineInterval == "OneHour")
            {

                klineAmount = dayParameter * 24;

            }

            if (klineInterval == "ThirtyMinutes")
            {

                klineAmount = dayParameter * 48;

            }

            if (klineInterval == "FifteenMinutes")
            {

                klineAmount = dayParameter * 96;

            }

            if (klineInterval == "FiveMinutes")
            {

                klineAmount = dayParameter * 288;

            }

            if (klineInterval == "ThreeMinutes")
            {

                klineAmount = dayParameter * 480;

            }

            if (klineInterval == "OneMinute")
            {

                klineAmount = dayParameter * 1440;

            }

            return new SuccessDataResult<int>(klineAmount);
        }


        public class RenkoCount
        {
            public string RenkoSide { get; set; }
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
    }
}
