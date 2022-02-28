using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entity.Concrete.DTOs
{
    public class IndicatorParameterDto : IDto
    {
        public int Id { get; set; }
        public string IndicatorName { get; set; }
        public string ParameterTitle { get; set; }
        public string Interval { get; set; }
        public int Period { get; set; }
        public decimal? Multiplier { get; set; } = null;
        public string KlineEndType { get; set; }
        public decimal? Parameter1 { get; set; } = null;
        public decimal? Parameter2 { get; set; } = null;
        public decimal? Parameter3 { get; set; } = null;
        public decimal? Parameter4 { get; set; } = null;
        public decimal? Parameter5 { get; set; } = null;
        public bool InUse { get; set; }
        public DateTime? CreationDate { get; set; } = null;


    }
}
