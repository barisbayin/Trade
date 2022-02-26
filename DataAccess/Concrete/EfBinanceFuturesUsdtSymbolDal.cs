using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfBinanceFuturesUsdtSymbolDal : EfEntityRepositoryBase<BinanceFuturesUsdtSymbolEntity, TradeContext>, IBinanceFuturesUsdtSymbolDal
    {
    }
}
