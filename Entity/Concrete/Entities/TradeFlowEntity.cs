﻿using System;
using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class TradeFlowEntity : IEntity
    {
        public int? Id { get; set; }
        public int TradeParameterId { get; set; }
        public bool LookingForFirstPosition { get; set; } = false;
        public bool LookingForPosition { get; set; } = false;
        public bool ReadyToOpenOrder { get; set; } = false;
        public bool PlacingOrders { get; set; } = false;
        public bool OrdersStartedToFill { get; set; } = false;
        public bool AllOrdersFilled { get; set; } = false;
        public bool PositionOpened { get; set; } = false;
        public bool TrackingOpenPosition { get; set; } = false;
        public bool PositionClosedByTakingProfit { get; set; } = false;
        public bool PositionClosedByStopLoss { get; set; } = false;
        public DateTime? PositionClosingTime { get; set; } = null;
        public bool IsSelected { get; set; } = false;
        public bool InUse { get; set; } = false;
        public bool IsEnded { get; set; } = false;
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; } = null;
        public bool? Removed { get; set; } = false;
        public DateTime? RemovedDate { get; set; } = null;
    }
}
