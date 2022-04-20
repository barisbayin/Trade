using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfTradeParameterDal : EfEntityRepositoryBase<TradeParameterEntity, TradeContext>, ITradeParameterDal
    {
        public List<TradeParameterDto> GetTradeParameterDetails()
        {
            using (TradeContext context = new TradeContext())
            {
                var result = from tp in context.TradeParameters
                             join ip in context.IndicatorParameters on tp.IndicatorParameterId equals ip.Id
                             join a in context.ApiInformations on tp.ApiInformationId equals a.Id
                             where tp.Removed==false

                             select new TradeParameterDto
                             {
                                 Id = tp.Id,
                                 TradeParameterTitle = tp.TradeParameterTitle,
                                 IndicatorParameterTitle = ip.ParameterTitle,
                                 ApiTitle = a.ApiTitle,
                                 SymbolPair = tp.SymbolPair,
                                 Interval = tp.Interval,
                                 MarginType = tp.MarginType,
                                 Leverage = tp.Leverage,
                                 StopLossPercent = tp.StopLossPercent,
                                 MaxAmountLimit = tp.MaximumBalanceLimit,
                                 MaxAmountPercentage = tp.MaxBalancePercentage,
                                 AddPnlToMaxAmountLimit = tp.AddPnlToMaximumBalanceLimit,
                                 PercentageOfPnlToBeAdded = tp.PercentageOfPnlToBeAdded,
                                 OrderRangeBrickQuantity = tp.OrderRangeBrickQuantity,
                                 OrderQuantity = tp.OrderQuantity,
                                 PriceCalculationMethod = tp.PriceCalculationMethod,
                                 CancelOrdersAfterBrick = tp.CancelOrdersAfterBrick,
                                 NumberOfBricksToBeTolerated = tp.NumberOfBricksToBeTolerated,
                                 InUse = tp.InUse,
                                 CreationDate = tp.CreationDate,
                                 ModifiedDate = tp.ModifiedDate
                             };
                return result.ToList();
            }
        }
    }
}
