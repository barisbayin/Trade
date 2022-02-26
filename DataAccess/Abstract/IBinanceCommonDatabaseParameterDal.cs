using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete.Entities;

namespace DataAccess.Abstract
{
    public interface IBinanceCommonDatabaseParameterDal:IEntityRepository<BinanceIntervalParameterEntity>
    {
    }
}
