﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfIndicatorParameterDal : EfEntityRepositoryBase<IndicatorParameterEntity, TradeContext>, IIndicatorParameterDal
    {
        public List<IndicatorParameterDto> GetIndicatorParameterDetails()
        {
            using (TradeContext context = new TradeContext())
            {
                var result = from ip in context.IndicatorParameters
                             join i in context.Indicators on ip.IndicatorId equals i.Id

                             select new IndicatorParameterDto
                             {
                                 Id = ip.Id,
                                 IndicatorName = i.IndicatorName,
                                 ParameterTitle = ip.ParameterTitle,
                                 Interval = ip.Interval,
                                 Period = ip.Period,
                                 Multiplier = ip.Multiplier,
                                 KlineEndType = ip.KlineEndType,
                                 Parameter1 = ip.Parameter1,
                                 Parameter2 = ip.Parameter2,
                                 Parameter3 = ip.Parameter3,
                                 Parameter4 = ip.Parameter4,
                                 Parameter5 = ip.Parameter5,
                                 InUse = ip.InUse,
                                 CreationDate = ip.CreationDate,
                                 ModifiedDate = ip.ModifiedDate
                             };
                return result.ToList();
            }
        }
    }
}
