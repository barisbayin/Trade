using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace Business.Abstract
{
    public interface IIndicatorParameterService
    {
        IDataResult<List<IndicatorParameterEntity>> GetAllIndicatorParameters();
        IDataResult<IndicatorParameterEntity> GetIndicatorParameterEntityById(int id);
        IDataResult<List<IndicatorParameterDto>> GetIndicatorParameterDetails();

        //Async Methods
        Task<IResult> AddIndicatorParameterAsync(IndicatorParameterEntity indicatorParameterEntity);
        Task<IResult> UpdateIndicatorParameterAsync(IndicatorParameterEntity indicatorParameterEntity);
        Task<IDataResult<IndicatorParameterEntity>> GetIndicatorParameterEntityByIdAsync(int id);
        Task<IResult> DeleteIndicatorParameterByIdAsync(int id);
    }
}
