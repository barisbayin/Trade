using System;
using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class TradeFlowEntity : IEntity
    {
        public int Id { get; set; }
        public bool TradeStarted { get; set; }
        public DateTime TradeStartTime { get; set; }
        public bool TradeEnded { get; set; }
        public DateTime TradeEndTime { get; set; }
        public bool LookingForPosition { get; set; }
        public bool ReadyForOpenOrders { get; set; }
        public bool OrdersStartedToFill { get; set; }
        public bool AllOrdersFilled { get; set; }
        public bool PositionOpened { get; set; }
        public bool FollowUpOfOpenPosition { get; set; }
        public bool PositionClosedByTakingProfit { get; set; }
        public bool PositionClosedByStopLoss { get; set; }
        public DateTime PositionClosingTime { get; set; }
        public bool IsSelected { get; set; }
        public bool InUse { get; set; }

    }
}
