using System;
using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class IndicatorParameterEntity : IEntity
    {
        public int? Id { get; set; }
        public int IndicatorId { get; set; }
        public string ParameterTitle { get; set; }
        public string Interval { get; set; }
        public int Period { get; set; }
        public decimal? Multiplier { get; set; } = 0;
        public string KlineEndType { get; set; }
        public decimal? Parameter1 { get; set; } = 0;
        public decimal? Parameter2 { get; set; } = 0;
        public decimal? Parameter3 { get; set; } = 0;
        public decimal? Parameter4 { get; set; } = 0;
        public decimal? Parameter5 { get; set; } = 0;
        public DateTime? CreationDate { get; set; } = null;
        public bool InUse { get; set; }
        public bool? Removed { get; set; } = null;
        public DateTime? ModifiedDate { get; set; } = null;

    }
}
