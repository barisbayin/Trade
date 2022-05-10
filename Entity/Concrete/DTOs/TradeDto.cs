using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.DTOs
{
    public class TradeDto
    {
        public int? TradeId { get; set; }
        public int? TradeFlowId { get; set; }
        public string TradeFlowTitle { get; set; }
        public bool TradeStarted { get; set; } = false;
        public DateTime? TradeStartTime { get; set; } = null;
        public bool TradeEnded { get; set; } = false;
        public DateTime? TradeEndTime { get; set; } = null;
    }
}
