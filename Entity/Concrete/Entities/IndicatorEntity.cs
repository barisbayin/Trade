using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class IndicatorEntity : IEntity
    {
        public int Id { get; set; }
        public string IndicatorName { get; set; }
        public bool Removed { get; set; }
    }
}
