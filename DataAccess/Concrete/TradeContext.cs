using Entity.Concrete.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class TradeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB; Database=Trade; User Id=tradeuser; Password=Trd2021**");
        }

        public DbSet<BinanceFuturesUsdtKlineEntity> BinanceFuturesUsdtKlinesEntity { get; set; }
        public DbSet<BinanceIntervalParameterEntity> BinanceIntervalParameters { get; set; }
        public DbSet<BinanceFuturesUsdtSymbolEntity> BinanceFuturesUsdtSymbolsEntity { get; set; }
        public DbSet<IndicatorEntity> Indicators { get; set; }
        public DbSet<IndicatorParameterEntity> IndicatorParameters { get; set; }
        public DbSet<TradeFlowEntity> TradeFlowParametersEntity { get; set; }
        public DbSet<ApiInformationEntity> ApiInformations { get; set; }
    }
}
