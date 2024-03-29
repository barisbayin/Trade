﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete.DTOs;

namespace Business.Abstract
{
    public interface ITradeService
    {
        IDataResult<List<TradeDto>> GetAllTradeDetails();
    }
}
