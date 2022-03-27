using System;
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
            else
            {
                return new ErrorDataResult<TradeFlowEntity>(CommonMessages.ItemIsNotAlreadySelected);
            }
        }

        public IDataResult<TradeFlowEntity> CheckTheTradeFlowIsEnded(int id)
        {
            var tradeFlow = _tradeFlowDal.Get(x => x.Id == id);
            if (tradeFlow.IsEnded == true)
            {
                return new SuccessDataResult<TradeFlowEntity>(CommonMessages.Finished);
            }
            else
            {
                return new ErrorDataResult<TradeFlowEntity>(CommonMessages.ItemDidNotFinished);
            }
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
            var result = CheckTheTradeFlowIsEnded(id);
            if (result.Success== true)
            {
                return new ErrorResult(result.Message);
            }
            else
            {
                var tradeFlow = _tradeFlowDal.Get(x => x.Id == id);
                tradeFlow.InUse = false;
                tradeFlow.IsEnded = true;
                UpdateTradeFlow(tradeFlow);
                return new SuccessResult(CommonMessages.MarkedAsFinished);
            }
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
                else
                {
                    return new ErrorResult(CommonMessages.AlreadySelectedItemFound);
                }
            }
            else
            {
                if (tradeFlow.IsEnded==true || tradeFlow.InUse==true)
                {
                    return new ErrorResult(CommonMessages.CanNotSelectEndedOrInUseItem);
                }
                else
                {
                    tradeFlow.IsSelected = true;
                    await UpdateTradeFlowAsync(tradeFlow);
                    return new SuccessResult(CommonMessages.Selected);
                }
            }
        }

        public async Task<IResult> UnSelectTradeFlowAsync(int id)
        {
            var tradeFlow = await _tradeFlowDal.GetAsync(x => x.Id == id);
            if (tradeFlow.IsSelected == false)
            {
                return new ErrorResult(CommonMessages.ItemIsNotAlreadySelected);
            }
            else
            {
                tradeFlow.IsSelected = false;
                await UpdateTradeFlowAsync(tradeFlow);
                return new SuccessResult(CommonMessages.UnSelected);
            }
        }

        public IDataResult<List<TradeFlowPartialDto>> GetTradeFlowPartialDetails()
        {
            var result = _tradeFlowDal.GetTradeFlowPartialDetails();
            return new SuccessDataResult<List<TradeFlowPartialDto>>(result);
        }
    }
}
