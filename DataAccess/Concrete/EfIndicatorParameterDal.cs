using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfIndicatorParameterDal : EfEntityRepositoryBase<IndicatorParameterEntity, TradeContext>, IIndicatorParameterDal
    {
    }
}
