using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfBinanceFuturesUsdtKlineDal : EfEntityRepositoryBase<BinanceFuturesUsdtKlineEntity, TradeContext>, IBinanceFuturesUsdtKlineDal
    {
        public IEnumerable<CurrencyKlineToCalculateIndicatorDto> GetCurrencyKlinesToCalculateIndicator(string symbolPair, string interval, int? dataCount)
        {
            using (TradeContext context = new TradeContext())
            {

                var result = from c in context.BinanceFuturesUsdtKlines
                    where c.SymbolPair == symbolPair && c.KlineInterval == interval
                    select new CurrencyKlineToCalculateIndicatorDto
                    {
                        Date = c.OpenTime,
                        Open = c.Open,
                        High = c.High,
                        Low = c.Low,
                        Close = c.Close,
                        Volume = c.BaseVolume
                    };

                return dataCount == null || dataCount == 0 ? result.OrderBy(c => c.Date).ToList() : result.OrderBy(c => c.Date).Take(Convert.ToInt32(dataCount)).ToList();
            }
        }

        public async Task<IEnumerable<CurrencyKlineToCalculateIndicatorDto>> GetCurrencyKlinesToCalculateIndicatorAsync(
            string symbolPair, string interval, int? dataCount)
        {

            TradeContext context = new TradeContext();
            var result = from c in context.BinanceFuturesUsdtKlines
                where c.SymbolPair == symbolPair && c.KlineInterval == interval
                select new CurrencyKlineToCalculateIndicatorDto
                {
                    Date = c.OpenTime,
                    Open = c.Open,
                    High = c.High,
                    Low = c.Low,
                    Close = c.Close,
                    Volume = c.BaseVolume
                };

            return dataCount == null || dataCount == 0 ? result.OrderBy(c => c.Date).ToList() : result.OrderByDescending(c => c.Date).Take(Convert.ToInt32(dataCount)).ToList();
        }
    }
}
