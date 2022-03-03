using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.Entities;
using Skender.Stock.Indicators;

namespace Business.Abstract
{
    public interface IIndicatorService
    {
        IDataResult<IndicatorEntity> GetIndicatorById(int indicatorId);
        Task<IDataResult<List<IndicatorEntity>>> GetAllIndicators();
        IDataResult<List<BinanceFuturesUsdtKlineWithSuperTrend>> GetSuperTrendResultAsync(string symbolPair, string interval, int indicatorParameterId);
        IDataResult<List<FuturesUsdtRenkoBrick>> GetFuturesUsdtRenkoBricks(string symbolPair, string interval, int indicatorParameterId);
        IDataResult<List<FuturesUsdtRenkoBricksWithSuperTrend>> GetFuturesUsdtRenkoBricksSuperTrend(string symbolPair, string interval, int renkoBrickParameterId, int superTrendParameterId);

    }
}
