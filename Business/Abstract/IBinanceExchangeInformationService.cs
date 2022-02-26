using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBinanceExchangeInformationService
    {
        Task<IResult> AddFuturesUsdtSymbolsAsync();
    }
}
