using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfBinanceCommonDatabaseParameterDal : EfEntityRepositoryBase<BinanceIntervalParameterEntity, TradeContext>, IBinanceCommonDatabaseParameterDal

    {

    }
}
