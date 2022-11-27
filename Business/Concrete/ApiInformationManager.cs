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


        public IDataResult<List<ApiInformationEntity>> GetAllNotRemovedApiInformation()
        {
            var result = _apiInformationDal.GetAll(x => x.IsRemoved == false);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<ApiInformationEntity>>(result);
            }

            return new ErrorDataResult<List<ApiInformationEntity>>(CommonMessages.NoData);
        }

        public IDataResult<ApiInformationEntity> GetDecryptedApiInformationById(int id)
        {
            var apiInformation = _apiInformationDal.Get(x => x.Id == id);
            try
            {
                var decryptedApiKey = AesEncryption.DecryptString(apiInformation.ApiKey);
                var decryptedSecretKey = AesEncryption.DecryptString(apiInformation.SecretKey);
                apiInformation.ApiKey = decryptedApiKey;
                apiInformation.SecretKey = decryptedSecretKey;

                return new SuccessDataResult<ApiInformationEntity>(apiInformation);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ApiInformationEntity>(e.Message);
            }


        }

        //Async Methods
        public async Task<IResult> AddApiInformationAsync(ApiInformationEntity apiInformationEntity)
        {
            var encryptedApiKey = AesEncryption.EncryptString(apiInformationEntity.ApiKey);
            var encryptedSecretKey = AesEncryption.EncryptString(apiInformationEntity.SecretKey);

            apiInformationEntity.ApiKey = encryptedApiKey;
            apiInformationEntity.SecretKey = encryptedSecretKey;
            apiInformationEntity.CreationDate = DateTime.Now;
            apiInformationEntity.InUse = false;
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

        public async Task<IResult> UpdateApiInformationByIdAsync(ApiInformationEntity apiInformationEntity)
        {
            var encryptedApiKey = AesEncryption.EncryptString(apiInformationEntity.ApiKey);
            var encryptedSecretKey = AesEncryption.EncryptString(apiInformationEntity.SecretKey);

            apiInformationEntity.ApiKey = encryptedApiKey;
            apiInformationEntity.SecretKey = encryptedSecretKey;
            apiInformationEntity.ModifiedDate = DateTime.Now;

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

        public async Task<IDataResult<ApiInformationEntity>> GetApiInformationByIdAsync(int id)
        {
            var result = await _apiInformationDal.GetAsync(x => x.Id == id);
            return new SuccessDataResult<ApiInformationEntity>(result);
        }

        public async Task<IDataResult<List<ApiInformationEntity>>> GetAllApiInformationAsync()
        {
            var result = await _apiInformationDal.GetAllAsync();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<ApiInformationEntity>>(result);
            }

            return new ErrorDataResult<List<ApiInformationEntity>>(CommonMessages.NoData);
        }

        public async Task<IDataResult<List<ApiInformationEntity>>> GetAllNotRemovedApiInformationAsync()
        {
            var result = await _apiInformationDal.GetAllAsync(x => x.IsRemoved == false);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<ApiInformationEntity>>(result);
            }

            return new ErrorDataResult<List<ApiInformationEntity>>(CommonMessages.NoData);
        }

        public async Task<IResult> DeleteApiInformationByIdAsync(int id)
        {
            var willDeleteApi = await _apiInformationDal.GetAsync(x => x.Id == id);
            if (willDeleteApi.InUse==true)
            {
                return new ErrorResult(CommonMessages.AlreadyInUse);
            }

            willDeleteApi.IsRemoved = true;
            willDeleteApi.RemovedDate = DateTime.Now;
            try
            {
                await _apiInformationDal.UpdateAsync(willDeleteApi);
                return new SuccessResult(CommonMessages.Deleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(CommonMessages.Error);
            }
        }
    }
}
