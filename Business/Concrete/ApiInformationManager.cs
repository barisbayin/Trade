using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Core.Costants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete.Entities;

namespace Business.Concrete
{
    public class ApiInformationManager : IApiInformationService
    {
        private readonly IApiInformationDal _apiInformationDal;
        public ApiInformationManager(IApiInformationDal apiInformationDal)
        {
            _apiInformationDal = apiInformationDal;
        }
        public async Task<IResult> AddApiInformation(ApiInformationEntity apiInformationEntity)
        {
            var encryptedApiKey = AesEncryption.EncryptString(apiInformationEntity.ApiKey);
            var encryptedSecretKey = AesEncryption.EncryptString(apiInformationEntity.SecretKey);

            apiInformationEntity.ApiKey = encryptedApiKey;
            apiInformationEntity.SecretKey = encryptedSecretKey;
            apiInformationEntity.CreationDate = DateTime.Now;
            apiInformationEntity.IsRemoved = false;
            apiInformationEntity.RemovedDate = null;
            try
            {
                await _apiInformationDal.AddAsync(apiInformationEntity);
                return new SuccessResult(CommonMessages.Added);
            }
            catch (Exception e)
            {
                return new ErrorResult(CommonMessages.Error);
            }

        }

        public async Task<IResult> UpdateApiInformationById(ApiInformationEntity apiInformationEntity)
        {
            var encryptedApiKey = AesEncryption.EncryptString(apiInformationEntity.ApiKey);
            var encryptedSecretKey = AesEncryption.EncryptString(apiInformationEntity.SecretKey);

            apiInformationEntity.ApiKey = encryptedApiKey;
            apiInformationEntity.SecretKey = encryptedSecretKey;
            apiInformationEntity.CreationDate = DateTime.Now;
            apiInformationEntity.IsRemoved = false;
            apiInformationEntity.RemovedDate = null;
            try
            {
                await _apiInformationDal.UpdateAsync(apiInformationEntity);
                return new SuccessResult(CommonMessages.Updated);
            }
            catch (Exception e)
            {
                return new ErrorResult(CommonMessages.Error);
            }
        }

        public async Task<IDataResult<ApiInformationEntity>> GetApiInformationById(int id)
        {
            var result = await _apiInformationDal.GetAsync(x => x.Id == id);
            return new SuccessDataResult<ApiInformationEntity>(result);
        }

        public async Task<IDataResult<List<ApiInformationEntity>>> GetAllApiInformation()
        {
            var result = await _apiInformationDal.GetAllAsync();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<ApiInformationEntity>>(result);
            }
            else
            {
                return new ErrorDataResult<List<ApiInformationEntity>>(CommonMessages.NoData);
            }
        }

        public async Task<IDataResult<List<ApiInformationEntity>>> GetAllNotRemovedApiInformation()
        {
            var result = await _apiInformationDal.GetAllAsync(x => x.IsRemoved == false);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<ApiInformationEntity>>(result);
            }
            else
            {
                return new ErrorDataResult<List<ApiInformationEntity>>(CommonMessages.NoData);
            }
        }

        public async Task<IResult> DeleteApiInformationById(int id)
        {
            var willUpdateApi = await _apiInformationDal.GetAsync(x => x.Id == id);
            willUpdateApi.IsRemoved = true;
            try
            {
                await _apiInformationDal.UpdateAsync(willUpdateApi);
                return new SuccessResult(CommonMessages.Deleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(CommonMessages.Error);
            }

        }
    }
}
