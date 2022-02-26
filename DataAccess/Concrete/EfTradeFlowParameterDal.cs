using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfTradeFlowParameterDal : EfEntityRepositoryBase<TradeFlowParameterEntity, TradeContext>, ITradeFlowParameterDal
    {
    }
}
