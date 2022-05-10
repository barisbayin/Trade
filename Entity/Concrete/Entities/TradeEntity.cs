using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class TradeEntity : IEntity
    {
        public int? Id { get; set; } 
        public int TradeFlowId { get; set; }
        public bool TradeStarted { get; set; } = false;
        public DateTime? TradeStartTime { get; set; } = null;
        public bool TradeEnded { get; set; } = false;
        public DateTime? TradeEndTime { get; set; } = null;
    }
}
