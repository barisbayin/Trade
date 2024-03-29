﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Costants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Business.Concrete
{
    public class TradeFlowManager : ITradeFlowService
    {
        private readonly ITradeFlowDal _tradeFlowDal;
        public TradeFlowManager(ITradeFlowDal tradeFlowDal)
        {
            _tradeFlowDal = tradeFlowDal;
        }

        public IDataResult<TradeFlowAllDto> GetSelectedTradeFlowAllDetail()
        {
            try
            {
                var tradeFlowAllDetail = _tradeFlowDal.GetSelectedTradeFlowAllDetail();

                return new SuccessDataResult<TradeFlowAllDto>(tradeFlowAllDetail);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<TradeFlowAllDto>(e.Message);
            }

        }

        public IDataResult<TradeFlowEntity> GetSelectedTradeFlow()
        {
            var tradeFlow = _tradeFlowDal.GetAll(x => x.IsSelected == true).LastOrDefault();
            return new SuccessDataResult<TradeFlowEntity>(tradeFlow);
        }

        public IResult UpdateTradeFlow(TradeFlowEntity tradeFlowEntity)
        {
            try
            {
                tradeFlowEntity.ModifiedDate = DateTime.Now;
                _tradeFlowDal.Update(tradeFlowEntity);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }

        }

        public IDataResult<TradeFlowEntity> CheckTheTradeFlowIsSelected(int id)
        {
            var tradeFlow = _tradeFlowDal.Get(x => x.Id == id);
            if (tradeFlow.IsSelected==true)
            {
                return new SuccessDataResult<TradeFlowEntity>(CommonMessages.Selected);
            }

            return new ErrorDataResult<TradeFlowEntity>(CommonMessages.ItemIsNotAlreadySelected);
        }

        public IDataResult<TradeFlowEntity> CheckIfTheTradeFlowIsEnded(int id)
        {
            var tradeFlow = _tradeFlowDal.Get(x => x.Id == id);
            if (tradeFlow.IsEnded == true)
            {
                return new SuccessDataResult<TradeFlowEntity>(CommonMessages.Finished);
            }

            return new ErrorDataResult<TradeFlowEntity>(CommonMessages.ItemDidNotFinished);
        }

        public IDataResult<TradeFlowEntity> CheckIfTheTradeFlowIsInUse(int id)
        {
            var tradeFlow = _tradeFlowDal.Get(x => x.Id == id);
            if (tradeFlow.InUse == true)
            {
                return new SuccessDataResult<TradeFlowEntity>(CommonMessages.AlreadyInUse);
            }

            return new ErrorDataResult<TradeFlowEntity>(CommonMessages.NotInUse);
        }

        public IDataResult<List<TradeFlowPartialDto>> GetEndedTradeFlowPartialDetails()
        {
            var result = _tradeFlowDal.GetTradeFlowPartialDetails().Where(x => x.IsEnded == true).ToList();
            return new SuccessDataResult<List<TradeFlowPartialDto>>(result);
        }

        public IDataResult<List<TradeFlowPartialDto>> GetNotEndedTradeFlowPartialDetails()
        {
            var result = _tradeFlowDal.GetTradeFlowPartialDetails().Where(x => x.IsEnded == false).ToList();
            return new SuccessDataResult<List<TradeFlowPartialDto>>(result);
        }

        public IDataResult<List<TradeFlowPartialDto>> GetInUseTradeFlowPartialDetails()
        {
            var result = _tradeFlowDal.GetTradeFlowPartialDetails().Where(x => x.InUse == true && x.IsEnded==false).ToList();
            return new SuccessDataResult<List<TradeFlowPartialDto>>(result);
        }

        public IDataResult<List<TradeFlowPartialDto>> GetNotInUseTradeFlowPartialDetails()
        {
            var result = _tradeFlowDal.GetTradeFlowPartialDetails().Where(x => x.InUse == false && x.IsEnded == false).ToList();
            return new SuccessDataResult<List<TradeFlowPartialDto>>(result);
        }

        public IResult MarkAsFinishedById(int id)
        {
            var result = CheckIfTheTradeFlowIsEnded(id);
            if (result.Success== true)
            {
                return new ErrorResult(result.Message);
            }

            var tradeFlow = _tradeFlowDal.Get(x => x.Id == id);
            tradeFlow.InUse = false;
            tradeFlow.IsEnded = true;
            UpdateTradeFlow(tradeFlow);
            return new SuccessResult(CommonMessages.MarkedAsFinished);
        }

        public IResult MarkAsNotInUseById(int id)
        {
            var result = CheckIfTheTradeFlowIsInUse(id);
            if (result.Success == true)
            {
                var tradeFlow = _tradeFlowDal.Get(x => x.Id == id);
                tradeFlow.InUse = false;
                UpdateTradeFlow(tradeFlow);
                return new SuccessResult(CommonMessages.MarkedAsNotInUse);
                
            }

            return new ErrorResult(result.Message);
        }

        public IResult ResetTradeFlowById(int id)
        {
            var tradeFlow = _tradeFlowDal.Get(x => x.Id == id);
            
            tradeFlow.LookingForPosition = false;
            tradeFlow.ReadyToOpenOrder = false;
            tradeFlow.PlacingOrders = false;
            tradeFlow.OrdersStartedToFill = false;
            tradeFlow.AllOrdersFilled = false;
            tradeFlow.PositionOpened = false;
            tradeFlow.TrackingOpenPosition = false;
            tradeFlow.PositionClosedByTakingProfit = false;
            tradeFlow.PositionClosedByStopLoss = false;
            tradeFlow.IsSelected = false;
            tradeFlow.InUse = false;
            tradeFlow.IsEnded = false;
            tradeFlow.ModifiedDate=DateTime.Now;
            UpdateTradeFlow(tradeFlow);
            return new SuccessResult(CommonMessages.TradeFlowReset);


        }

        public async Task<IDataResult<TradeFlowEntity>> GetSelectedTradeFlowAsync()
        {
            var tradeFlow = (await _tradeFlowDal.GetAllAsync(x => x.IsSelected == true)).LastOrDefault();
            return new SuccessDataResult<TradeFlowEntity>(tradeFlow);
        }

        public async Task<IDataResult<TradeFlowEntity>> GetTradeFlowByIdAsync(int id)
        {
            var tradeFlow = await _tradeFlowDal.GetAsync(x => x.Id == id);
            return new SuccessDataResult<TradeFlowEntity>(tradeFlow);
        }

        public async Task<IResult> AddTradeFlowAsync(TradeFlowEntity tradeFlowEntity)
        {
            tradeFlowEntity.CreationDate = DateTime.Now;
            await _tradeFlowDal.AddAsync(tradeFlowEntity);
            return new SuccessResult(CommonMessages.Added);
        }

        public async Task<IResult> UpdateTradeFlowAsync(TradeFlowEntity tradeFlowEntity)
        {
            tradeFlowEntity.ModifiedDate = DateTime.Now;
            await _tradeFlowDal.UpdateAsync(tradeFlowEntity);
            return new SuccessResult();
        }

        public async Task<IResult> SelectTradeFlowAsync(int id)
        {
            var hasIsSelected = (await _tradeFlowDal.GetAllAsync(x => x.IsSelected == true)).Any();
            var tradeFlow = await _tradeFlowDal.GetAsync(x => x.Id == id);
            if (hasIsSelected == true)
            {
                if (tradeFlow.IsSelected == true)
                {
                    return new ErrorResult(CommonMessages.AlreadySelected);
                }

                return new ErrorResult(CommonMessages.AlreadySelectedItemFound);
            }

            if (tradeFlow.IsEnded==true || tradeFlow.InUse==true)
            {
                return new ErrorResult(CommonMessages.CanNotSelectEndedOrInUseItem);
            }

            tradeFlow.IsSelected = true;
            await UpdateTradeFlowAsync(tradeFlow);
            return new SuccessResult(CommonMessages.Selected);
        }

        public async Task<IResult> UnSelectTradeFlowAsync(int id)
        {
            var tradeFlow = await _tradeFlowDal.GetAsync(x => x.Id == id);
            if (tradeFlow.IsSelected == false)
            {
                return new ErrorResult(CommonMessages.ItemIsNotAlreadySelected);
            }

            tradeFlow.IsSelected = false;
            await UpdateTradeFlowAsync(tradeFlow);
            return new SuccessResult(CommonMessages.UnSelected);
        }

        public IDataResult<List<TradeFlowEntity>> GetAllTradeFlows()
        {
            var result = _tradeFlowDal.GetAll();
            return new SuccessDataResult<List<TradeFlowEntity>>(result);
        }

        public IDataResult<List<TradeFlowPartialDto>> GetAllTradeFlowPartialDetails()
        {
            var result = _tradeFlowDal.GetTradeFlowPartialDetails();
            return new SuccessDataResult<List<TradeFlowPartialDto>>(result);
        }
    }
}
