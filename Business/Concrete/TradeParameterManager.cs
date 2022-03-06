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

namespace Business.Concrete
{
    public class TradeParameterManager : ITradeParameterService
    {
        private readonly ITradeParameterDal _tradeParameterDal;
        public TradeParameterManager(ITradeParameterDal tradeParameterDal)
        {
            _tradeParameterDal = tradeParameterDal;
        }
        public IDataResult<List<TradeParameterDto>> GetTradeParameterDetails()
        {
            var result = _tradeParameterDal.GetTradeParameterDetails();
            return new SuccessDataResult<List<TradeParameterDto>>(result);
        }

        //Async Methods
        public async Task<IDataResult<TradeParameterEntity>> GetTradeParameterEntityByIdAsync(int id)
        {
            return new SuccessDataResult<TradeParameterEntity>(await _tradeParameterDal.GetAsync(x => x.Id == id));
        }

        public async Task<IResult> AddTradeParameterAsync(TradeParameterEntity tradeParameterEntity)
        {
            tradeParameterEntity.InUse = false;
            tradeParameterEntity.CreationDate = DateTime.Now;
            tradeParameterEntity.Removed = false;

            try
            {
                await _tradeParameterDal.AddAsync(tradeParameterEntity);
                return new SuccessResult(CommonMessages.Added);
            }
            catch (Exception e)
            {
                return new ErrorResult(CommonMessages.Error);
            }
        }

        public async Task<IResult> UpdateTradeParameterAsync(TradeParameterEntity tradeParameterEntity)
        {
            tradeParameterEntity.ModifiedDate = DateTime.Now;

            try
            {
                await _tradeParameterDal.UpdateAsync(tradeParameterEntity);
                return new SuccessResult(CommonMessages.Updated);
            }
            catch (Exception e)
            {
                return new ErrorResult(CommonMessages.Error);
            }
        }



        public async Task<IResult> DeleteTradeParameterByIdAsync(int id)
        {
            var willDeletedTradeParameter = await _tradeParameterDal.GetAsync(x => x.Id == id);

            if (willDeletedTradeParameter.InUse == true)
            {
                return new ErrorResult(CommonMessages.AlreadyInUse);
            }
            else
            {
                try
                {
                    willDeletedTradeParameter.Removed = true;
                    willDeletedTradeParameter.RemovedDate=DateTime.Now;

                    await _tradeParameterDal.UpdateAsync(willDeletedTradeParameter);
                    return new SuccessResult(CommonMessages.Deleted);
                }
                catch (Exception e)
                {
                    return new ErrorResult(CommonMessages.Error);
                }

            }
        }
    }
}
