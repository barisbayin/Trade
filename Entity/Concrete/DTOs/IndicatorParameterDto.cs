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
        public string Interval { get; set; }
        public int Period { get; set; }
        public decimal Multiplier { get; set; }
        public decimal KlineEndType { get; set; }
        public decimal Parameter1 { get; set; }
        public decimal Parameter2 { get; set; }
        public decimal Parameter3 { get; set; }
        public decimal Parameter4 { get; set; }
        public decimal Parameter5 { get; set; }
        public DateTime CreationDate { get; set; }


    }
}
