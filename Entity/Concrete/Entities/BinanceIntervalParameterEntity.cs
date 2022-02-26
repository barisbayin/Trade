using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class BinanceIntervalParameterEntity : IEntity
    {
        public int Id { get; set; }
        public string Interval { get; set; }
        public string Market { get; set; }
        public int DayParameter { get; set; }
        public int KlineCount { get; set; }
    }
}
