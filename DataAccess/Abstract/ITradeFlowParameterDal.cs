using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace DataAccess.Abstract
{
    public interface ITradeFlowParameterDal : IEntityRepository<TradeFlowEntity>
    {
        List<TradeParameterDto> GetTradeParameterDetails();
    }
}
