using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace DataAccess.Abstract
{
    public interface IBinanceFuturesUsdtKlineDal : IEntityRepository<BinanceFuturesUsdtKlineEntity>
    {
        IEnumerable<CurrencyKlineToCalculateIndicatorDto> GetCurrencyKlinesToCalculateIndicator(string symbolPair,
            string interval, int? dataCount);
        Task<IEnumerable<CurrencyKlineToCalculateIndicatorDto>> GetCurrencyKlinesToCalculateIndicatorAsync(
            string symbolPair, string interval, int? dataCount);
    }
}
