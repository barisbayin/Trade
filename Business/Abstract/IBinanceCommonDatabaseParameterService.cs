using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete.Entities;

namespace Business.Abstract
{
    public interface IBinanceCommonDatabaseParameterService
    {
        Task<IDataResult<int>> GetFuturesUsdtDayParameterForTheIntervalAsync(string interval);
        Task<IDataResult<List<BinanceIntervalParameterEntity>>> GetAllBinanceIntervalParametersAsync();
        Task<IResult> UpdateDayParameterByIntervalAndMarketplaceAsync(string interval, string marketplace, int dayParameter);
        Task<IResult> DeleteDayParameterByIdAsync(int id);
        Task<IResult> AddDayParameterAsync(BinanceIntervalParameterEntity binanceIntervalParameterEntity);
        Task<IResult> UpdateDayParameterAsync(BinanceIntervalParameterEntity binanceIntervalParameterEntity);
    }
}
