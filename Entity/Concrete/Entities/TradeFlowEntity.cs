using System;
using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class TradeFlowEntity : IEntity
    {
        public int? Id { get; set; }
        public int TradeParameterId { get; set; }
        public bool TradeStarted { get; set; } = false;
        public DateTime? TradeStartTime { get; set; } = null;
        public bool TradeEnded { get; set; } = false;
        public DateTime? TradeEndTime { get; set; } = null;
        public bool LookingForPosition { get; set; } = false;
        public bool ReadyToOpenOrder { get; set; } = false;
        public bool OrdersStartedToFill { get; set; } = false;
        public bool AllOrdersFilled { get; set; } = false;
        public bool PositionOpened { get; set; } = false;
        public bool FollowUpOfOpenPosition { get; set; } = false;
        public bool PositionClosedByTakingProfit { get; set; } = false;
        public bool PositionClosedByStopLoss { get; set; } = false;
        public DateTime? PositionClosingTime { get; set; } = null;
        public bool IsSelected { get; set; } = false;
        public bool InUse { get; set; } = false;
        public bool IsFinished { get; set; } = false;
        public DateTime CreationDate { get; set; } 
        public DateTime? ModifiedDate { get; set; } = null;
        public bool? Removed { get; set; } = false;
        public DateTime? RemovedDate { get; set; } = null;
    }
}
