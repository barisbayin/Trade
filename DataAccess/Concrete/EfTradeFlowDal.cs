using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccess.Concrete
{
    public class EfTradeFlowDal : EfEntityRepositoryBase<TradeFlowEntity, TradeContext>, ITradeFlowDal
    {
        public List<TradeFlowAllDto> GetTradeFlowAllDetails()
        {
            using (TradeContext context = new TradeContext())
            {
                var result = from tf in context.TradeFlows
                             join tp in context.TradeParameters on tf.TradeParameterId equals tp.Id
                             join ip in context.IndicatorParameters on tp.IndicatorParameterId equals ip.Id
                             join ai in context.ApiInformations on tp.ApiInformationId equals ai.Id
                             join i in context.Indicators on ip.IndicatorId equals i.Id
                             select new TradeFlowAllDto
                             {
                                 Id = tf.Id,
                                 TradeParameterTitle = tp.TradeParameterTitle,
                                 IndicatorParameterTitle = ip.ParameterTitle,
                                 ApiTitle = ai.ApiTitle,
                                 SymbolPair = tp.SymbolPair,
                                 Interval = tp.Interval,
                                 MarginType = tp.MarginType,
                                 Leverage = tp.Leverage,
                                 MaxAmountLimit = tp.MaximumBalanceLimit,
                                 MaxAmountPercentage = tp.MaxBalancePercentage,
                                 AddPnlToMaxAmountLimit = tp.AddPnlToMaximumBalanceLimit,
                                 PercentageOfPnlToBeAdded = tp.PercentageOfPnlToBeAdded,
                                 NumberOfBricksForEntry = tp.NumberOfBricksForEntry,
                                 OrderRangeBrickQuantity = tp.OrderRangeBrickQuantity,
                                 OrderQuantity = tp.OrderQuantity,
                                 PriceCalculationMethod = tp.PriceCalculationMethod,
                                 CancelOrdersAfterBrick = tp.CancelOrdersAfterBrick,
                                 IndicatorName = i.IndicatorName,
                                 Period = ip.Period,
                                 Multiplier = ip.Multiplier,
                                 KlineEndType = ip.KlineEndType,
                                 Parameter1 = ip.Parameter1,
                                 Parameter2 = ip.Parameter2,
                                 Parameter3 = ip.Parameter3,
                                 Parameter4 = ip.Parameter4,
                                 Parameter5 = ip.Parameter5,
                                 InUse = tf.InUse,
                                 IsEnded = tf.IsEnded,
                                 TradeStarted = tf.TradeStarted,
                                 TradeStartTime = tf.TradeStartTime,
                                 TradeEnded = tf.TradeEnded,
                                 TradeEndTime = tf.TradeEndTime,
                                 LookingForFirstPosition = tf.LookingForFirstPosition,
                                 LookingForPosition = tf.LookingForPosition,
                                 ReadyToOpenOrder = tf.ReadyToOpenOrder,
                                 OrdersStartedToFill = tf.OrdersStartedToFill,
                                 AllOrdersFilled = tf.AllOrdersFilled,
                                 PositionOpened = tf.PositionOpened,
                                 TrackingOpenPosition = tf.TrackingOpenPosition,
                                 PositionClosedByTakingProfit = tf.PositionClosedByTakingProfit,
                                 PositionClosedByStopLoss = tf.PositionClosedByStopLoss,
                                 PositionClosingTime = tf.PositionClosingTime,
                                 IsSelected = tf.IsSelected,
                                 CreationDate = tf.CreationDate,
                                 ModifiedDate = tf.ModifiedDate

                             };
                return result.ToList();
            }
        }

        public TradeFlowAllDto GetSelectedTradeFlowAllDetail()
        {
            using (TradeContext context = new TradeContext())
            {
                var result = from tf in context.TradeFlows
                             join tp in context.TradeParameters on tf.TradeParameterId equals tp.Id
                             join ip in context.IndicatorParameters on tp.IndicatorParameterId equals ip.Id
                             join ai in context.ApiInformations on tp.ApiInformationId equals ai.Id
                             join i in context.Indicators on ip.IndicatorId equals i.Id
                             where tf.IsSelected == true
                             select new TradeFlowAllDto
                             {
                                 Id = tf.Id,
                                 TradeParameterTitle = tp.TradeParameterTitle,
                                 IndicatorParameterTitle = ip.ParameterTitle,
                                 ApiTitle = ai.ApiTitle,
                                 SymbolPair = tp.SymbolPair,
                                 Interval = tp.Interval,
                                 MarginType = tp.MarginType,
                                 Leverage = tp.Leverage,
                                 MaxAmountLimit = tp.MaximumBalanceLimit,
                                 MaxAmountPercentage = tp.MaxBalancePercentage,
                                 AddPnlToMaxAmountLimit = tp.AddPnlToMaximumBalanceLimit,
                                 PercentageOfPnlToBeAdded = tp.PercentageOfPnlToBeAdded,
                                 NumberOfBricksForEntry = tp.NumberOfBricksForEntry,
                                 OrderRangeBrickQuantity = tp.OrderRangeBrickQuantity,
                                 OrderQuantity = tp.OrderQuantity,
                                 PriceCalculationMethod = tp.PriceCalculationMethod,
                                 CancelOrdersAfterBrick = tp.CancelOrdersAfterBrick,
                                 NumberOfBricksToBeTolerated = tp.NumberOfBricksToBeTolerated,
                                 IndicatorName = i.IndicatorName,
                                 Period = ip.Period,
                                 Multiplier = ip.Multiplier,
                                 KlineEndType = ip.KlineEndType,
                                 Parameter1 = ip.Parameter1,
                                 Parameter2 = ip.Parameter2,
                                 Parameter3 = ip.Parameter3,
                                 Parameter4 = ip.Parameter4,
                                 Parameter5 = ip.Parameter5,
                                 InUse = tf.InUse,
                                 TradeStarted = tf.TradeStarted,
                                 TradeStartTime = tf.TradeStartTime,
                                 TradeEnded = tf.TradeEnded,
                                 TradeEndTime = tf.TradeEndTime,
                                 LookingForFirstPosition = tf.LookingForFirstPosition,
                                 LookingForPosition = tf.LookingForPosition,
                                 ReadyToOpenOrder = tf.ReadyToOpenOrder,
                                 OrdersStartedToFill = tf.OrdersStartedToFill,
                                 AllOrdersFilled = tf.AllOrdersFilled,
                                 PositionOpened = tf.PositionOpened,
                                 TrackingOpenPosition = tf.TrackingOpenPosition,
                                 PositionClosedByTakingProfit = tf.PositionClosedByTakingProfit,
                                 PositionClosedByStopLoss = tf.PositionClosedByStopLoss,
                                 PositionClosingTime = tf.PositionClosingTime,
                                 IsSelected = tf.IsSelected,
                                 CreationDate = tf.CreationDate,
                                 ModifiedDate = tf.ModifiedDate

                             };
                return result.LastOrDefault();
            }
        }

        public List<TradeFlowPartialDto> GetTradeFlowPartialDetails()
        {
            using (TradeContext context = new TradeContext())
            {
                var result = from tf in context.TradeFlows
                             join tp in context.TradeParameters on tf.TradeParameterId equals tp.Id
                             join ip in context.IndicatorParameters on tp.IndicatorParameterId equals ip.Id
                             join ai in context.ApiInformations on tp.ApiInformationId equals ai.Id
                             select new TradeFlowPartialDto
                             {
                                 Id = tf.Id,
                                 TradeParameterTitle = tp.TradeParameterTitle,
                                 IndicatorParameterTitle = ip.ParameterTitle,
                                 ApiTitle = ai.ApiTitle,
                                 SymbolPair = tp.SymbolPair,
                                 Interval = tp.Interval,
                                 MarginType = tp.MarginType,
                                 Leverage = tp.Leverage,
                                 MaxAmountLimit = tp.MaximumBalanceLimit,
                                 MaxAmountPercentage = tp.MaxBalancePercentage,
                                 AddPnlToMaxAmountLimit = tp.AddPnlToMaximumBalanceLimit,
                                 PercentageOfPnlToBeAdded = tp.PercentageOfPnlToBeAdded,
                                 NumberOfBricksForEntry = tp.NumberOfBricksForEntry,
                                 OrderRangeBrickQuantity = tp.OrderRangeBrickQuantity,
                                 PriceCalculationMethod = tp.PriceCalculationMethod,
                                 CancelOrdersAfterBrick = tp.CancelOrdersAfterBrick,
                                 NumberOfBricksToBeTolerated = tp.NumberOfBricksToBeTolerated,
                                 InUse = tf.InUse,
                                 IsEnded = tf.IsEnded,
                                 IsSelected = tf.IsSelected,
                                 CreationDate = tf.CreationDate,
                                 ModifiedDate = tf.ModifiedDate

                             };
                return result.ToList();
            }
        }
    }
}
