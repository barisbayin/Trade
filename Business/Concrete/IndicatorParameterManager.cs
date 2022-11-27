using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Costants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace Business.Concrete
{
    public class IndicatorParameterManager : IIndicatorParameterService
    {
        private readonly IIndicatorParameterDal _indicatorParameterDal;

        public IndicatorParameterManager(IIndicatorParameterDal indicatorParameterDal)
        {
            _indicatorParameterDal = indicatorParameterDal;
        }

 

        public IDataResult<List<IndicatorParameterEntity>> GetAllIndicatorParameters()
        {
            return new SuccessDataResult<List<IndicatorParameterEntity>>(_indicatorParameterDal.GetAll());
        }

        public IDataResult<IndicatorParameterEntity> GetIndicatorParameterEntityById(int id)
        {
            return new SuccessDataResult<IndicatorParameterEntity> (_indicatorParameterDal.Get(x => x.Id == id));
        }
        public IDataResult<List<IndicatorParameterDto>> GetIndicatorParameterDetails()
        {
            var result = _indicatorParameterDal.GetIndicatorParameterDetails();
            return new SuccessDataResult<List<IndicatorParameterDto>>(result);
        }

        //Async Methods

        public async Task<IDataResult<IndicatorParameterEntity>> GetIndicatorParameterEntityByIdAsync(int id)
        {
            return new SuccessDataResult<IndicatorParameterEntity>(await _indicatorParameterDal.GetAsync(x => x.Id == id));
        }


        public async Task<IResult> DeleteIndicatorParameterByIdAsync(int id)
        {
            var willDeletedIndicatorParameter = await _indicatorParameterDal.GetAsync(x => x.Id == id);

            if (willDeletedIndicatorParameter.InUse == true)
            {
                return new ErrorResult(CommonMessages.AlreadyInUse);
            }

            try
            {
                willDeletedIndicatorParameter.Removed = true;
                willDeletedIndicatorParameter.RemovedDate=DateTime.Now;

                await _indicatorParameterDal.DeleteAsync(willDeletedIndicatorParameter);
                return new SuccessResult(CommonMessages.Deleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(CommonMessages.Error);
            }
        }
        public async Task<IResult> AddIndicatorParameterAsync(IndicatorParameterEntity indicatorParameterEntity)
        {
            indicatorParameterEntity.InUse = false;
            indicatorParameterEntity.CreationDate = DateTime.Now;
            indicatorParameterEntity.Removed = false;

            try
            {
                await _indicatorParameterDal.AddAsync(indicatorParameterEntity);
                return new SuccessResult(CommonMessages.Added);
            }
            catch (Exception e)
            {
                return new ErrorResult(CommonMessages.Error);
            }
        }

        public async Task<IResult> UpdateIndicatorParameterAsync(IndicatorParameterEntity indicatorParameterEntity)
        {

            indicatorParameterEntity.ModifiedDate = DateTime.Now;

            try
            {

                await _indicatorParameterDal.UpdateAsync(indicatorParameterEntity);
                return new SuccessResult(CommonMessages.Updated);
            }
            catch (Exception e)
            {
                return new ErrorResult(CommonMessages.Error);
            }
        }
    }
}
