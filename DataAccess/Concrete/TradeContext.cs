using Entity.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DataAccess.Concrete
{
    public class TradeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Trade; User Id=tradeuser; Password=Trd2021**");
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            
        }

        public DbSet<BinanceFuturesUsdtKlineEntity> BinanceFuturesUsdtKlines { get; set; }
        public DbSet<BinanceIntervalParameterEntity> BinanceIntervalParameters { get; set; }
        public DbSet<BinanceFuturesUsdtSymbolEntity> BinanceFuturesUsdtSymbols{ get; set; }
        public DbSet<IndicatorEntity> Indicators { get; set; }
        public DbSet<IndicatorParameterEntity> IndicatorParameters { get; set; }
        public DbSet<ApiInformationEntity> ApiInformations { get; set; }
        public DbSet<TradeParameterEntity> TradeParameters { get; set; }
        public DbSet<TradeFlowEntity> TradeFlows { get; set; }
        public DbSet<TradeLogEntity> TradeLogs { get; set; }

    }
}
