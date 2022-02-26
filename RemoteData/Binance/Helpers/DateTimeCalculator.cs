using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteData.Binance.Helpers
{
    public class DateRange
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    public static class DateTimeCalculator
    {
        public static IDataResult<List<DateRange>> GetDateTimeRangeList(string klineInterval, DateTime startTime, DateTime endTime)
        {
            List<DateRange> dateRangeList = new List<DateRange>();

            if (klineInterval == "OneMonth")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddMonths(120))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddMonths(-120))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddMonths(-120);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddMonths(-120);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);

            }

            if (klineInterval == "OneWeek")
            {

                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddDays(7000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddDays(-7000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddDays(-7000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddDays(-7000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "ThreeDay")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddDays(3000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddDays(-3000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddDays(-3000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddDays(-3000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "OneDay")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddDays(1000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddDays(-1000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddDays(-1000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddDays(-1000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "TwelveHour")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddHours(12000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddHours(-12000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddHours(-12000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddHours(-12000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "EightHour")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddHours(8000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddHours(-8000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddHours(-8000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddHours(-8000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "SixHour")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddHours(6000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddHours(-6000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddHours(-6000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddHours(-6000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "FourHour")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddHours(4000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddHours(-4000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddHours(-4000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddHours(-4000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "TwoHour")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddHours(2000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddHours(-2000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddHours(-2000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddHours(-2000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "OneHour")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddHours(1000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddHours(-1000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddHours(-1000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddHours(-1000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "ThirtyMinutes")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddMinutes(30000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddMinutes(-30000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddMinutes(-30000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddMinutes(-30000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "FifteenMinutes")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddMinutes(15000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddMinutes(-15000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddMinutes(-15000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddMinutes(-15000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "FiveMinutes")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddMinutes(5000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddMinutes(-5000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddMinutes(-5000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddMinutes(-5000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);

            }

            if (klineInterval == "ThreeMinutes")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddMinutes(3000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddMinutes(-3000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddMinutes(-3000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddMinutes(-3000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            if (klineInterval == "OneMinute")
            {
                for (DateTime checkedStartTime = startTime; checkedStartTime <= DateTime.UtcNow; checkedStartTime = checkedStartTime.AddMinutes(1000))
                {
                    DateRange dateRange = new DateRange();

                    if (startTime > endTime.AddMinutes(-1000))
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = startTime;
                        dateRangeList.Add(dateRange);
                    }
                    else
                    {
                        dateRange.EndTime = endTime;
                        dateRange.StartTime = endTime.AddMinutes(-1000);
                        dateRangeList.Add(dateRange);

                        endTime = endTime.AddMinutes(-1000);
                    }
                }
                return new SuccessDataResult<List<DateRange>>(dateRangeList);
            }

            return new SuccessDataResult<List<DateRange>>(dateRangeList);
        }
    }
}
