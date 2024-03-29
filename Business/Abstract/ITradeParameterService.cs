﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace Business.Abstract
{
    public interface ITradeParameterService
    {
        IDataResult<List<TradeParameterDto>> GetTradeParameterDetails();
        IDataResult<TradeParameterEntity> GetTradeParameterEntityById(int id);

        //Async Methods
        Task<IDataResult<List<TradeParameterEntity>>> GetAllTradeParametersAsync();
        Task<IResult> AddTradeParameterAsync(TradeParameterEntity tradeParameterEntity);
        Task<IResult> UpdateTradeParameterAsync(TradeParameterEntity tradeParameterEntity);
        Task<IDataResult<TradeParameterEntity>> GetTradeParameterEntityByIdAsync(int id);
        Task<IResult> DeleteTradeParameterByIdAsync(int id);
    }
}