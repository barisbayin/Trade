using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.DTOs
{
    public class TradeLogsDto
    {
        public int TradeFlowId { get; set; }
        public string TradeParameterTitle { get; set; }
        public string SymbolPair { get; set; }
        public int TradeId { get; set; }
        public string LogRecord { get; set; }
        public DateTime LogDate { get; set; }
    }
}
