﻿using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete.Entities;

namespace Business.Abstract
{
    public interface IBinanceExchangeInformationService
    {
        IDataResult<List<BinanceFuturesUsdtSymbolEntity>> GetAllFuturesUsdtSymbolInformation();
        //Async Methods
        Task<IResult> AddFuturesUsdtSymbolsAsync();
        Task<IDataResult<List<BinanceFuturesUsdtSymbolEntity>>> GetAllFuturesUsdtSymbolInformationAsync();
    }
}
