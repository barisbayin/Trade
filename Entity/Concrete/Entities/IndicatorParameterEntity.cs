using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class IndicatorParameterEntity : IEntity
    {
        public int? Id { get; set; }
        public int IndicatorId { get; set; }
        public string ParameterName { get; set; }
        public string Interval { get; set; }
        public int Period { get; set; }
        public decimal? Multiplier { get; set; }
        public string KlineEndType { get; set; }
        public decimal? Parameter1 { get; set; }
        public decimal? Parameter2 { get; set; }
        public decimal? Parameter3 { get; set; }
        public decimal? Parameter4 { get; set; }
        public decimal? Parameter5 { get; set; }

    }
}
