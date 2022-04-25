using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class TradeLogEntity : IEntity
    {
        public int Id { get; set; }
        public int TradeFlowId { get; set; }
        public int TradeId { get; set; }
        public string LogRecord { get; set; }
        public DateTime LogDate { get; set; }
    }
}
