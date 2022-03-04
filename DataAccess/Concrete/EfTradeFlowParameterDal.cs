﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfTradeFlowParameterDal : EfEntityRepositoryBase<TradeFlowEntity, TradeContext>, ITradeFlowParameterDal
    {
        public List<TradeParameterDto> GetTradeParameterDetails()
        {
            using (TradeContext context = new TradeContext())
            {
                var result = from tp in context.TradeFlowParametersEntity
                    join ip in context.IndicatorParameters on tp.IndicatorParameterId equals ip.Id
                    join a in context.ApiInformations on tp.ApiInformationId equals a.Id 

                    select new TradeParameterDto
                    {
                        
                    };
                return result.ToList();
            }
        }
    }
}
