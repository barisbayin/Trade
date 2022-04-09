using Business.Abstract;
using RemoteData.Binance.GeneralApi.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete;
using Core.Costants.Messages;
using Entity.Concrete.Entities;

namespace Business.Concrete
{
    public class BinanceExchangeInformationManager : IBinanceExchangeInformationService
    {
        private readonly IBinanceFuturesUsdtSymbolDal _binanceFuturesUsdtSymbolDal;
        private readonly IBinanceApiService _binanceApiService;

        public BinanceExchangeInformationManager()
        {

        }
        public BinanceExchangeInformationManager(IBinanceFuturesUsdtSymbolDal binanceFuturesUsdtSymbolDal, IBinanceApiService binanceApiService)
        {
            _binanceFuturesUsdtSymbolDal = binanceFuturesUsdtSymbolDal;
            _binanceApiService = binanceApiService;
        }

        public IDataResult<List<BinanceFuturesUsdtSymbolEntity>> GetAllFuturesUsdtSymbolInformation()
        {
            var result = _binanceFuturesUsdtSymbolDal.GetAll();
            return new SuccessDataResult<List<BinanceFuturesUsdtSymbolEntity>>(result);
        }

        public async Task<IResult> AddFuturesUsdtSymbolInformationAsync()
        {
            var lastBinanceFuturesUsdtSymbolEntity = _binanceFuturesUsdtSymbolDal.GetAllAsync().Result.LastOrDefault();

            if (lastBinanceFuturesUsdtSymbolEntity.CreationDate.Date == DateTime.Now.Date)
            {
                Console.WriteLine(CommonMessages.InformationAreAlreadyUpToDate);
                return new SuccessResult(CommonMessages.InformationAreAlreadyUpToDate);
            }

            _binanceFuturesUsdtSymbolDal.DeleteAllOrByFilter();

            Console.WriteLine("FuturesUsdt symbol information deleted!");

            var futuresUsdtSymbolDataList = (await _binanceApiService.GetBinanceFuturesUsdtSymbolInformationListAsync()).Data;
            foreach (var futuresUsdtSymbol in futuresUsdtSymbolDataList)
            {
                BinanceFuturesUsdtSymbolEntity binanceFuturesUsdtSymbolEntity = new BinanceFuturesUsdtSymbolEntity();

                binanceFuturesUsdtSymbolEntity.Name = futuresUsdtSymbol.Name;
                binanceFuturesUsdtSymbolEntity.Pair = futuresUsdtSymbol.Pair;
                binanceFuturesUsdtSymbolEntity.BaseAsset = futuresUsdtSymbol.BaseAsset;
                binanceFuturesUsdtSymbolEntity.BaseAssetPrecision = futuresUsdtSymbol.BaseAssetPrecision;
                binanceFuturesUsdtSymbolEntity.MarginAsset = futuresUsdtSymbol.MarginAsset;
                binanceFuturesUsdtSymbolEntity.QuoteAsset = futuresUsdtSymbol.QuoteAsset;
                binanceFuturesUsdtSymbolEntity.QuoteAssetPrecision = futuresUsdtSymbol.QuoteAssetPrecision;
                binanceFuturesUsdtSymbolEntity.ListingDate = futuresUsdtSymbol.ListingDate;
                binanceFuturesUsdtSymbolEntity.DeliveryDate = futuresUsdtSymbol.DeliveryDate;
                binanceFuturesUsdtSymbolEntity.LiquidationFee = futuresUsdtSymbol.LiquidationFee;
                binanceFuturesUsdtSymbolEntity.MarketTakeBound = futuresUsdtSymbol.MarketTakeBound;
                binanceFuturesUsdtSymbolEntity.PricePrecision = futuresUsdtSymbol.PricePrecision;
                binanceFuturesUsdtSymbolEntity.QuantityPrecision = futuresUsdtSymbol.QuantityPrecision;
                binanceFuturesUsdtSymbolEntity.RequiredMarginPercent = futuresUsdtSymbol.RequiredMarginPercent;
                binanceFuturesUsdtSymbolEntity.MaintMarginPercent = futuresUsdtSymbol.MaintMarginPercent;
                binanceFuturesUsdtSymbolEntity.TriggerProtect = futuresUsdtSymbol.TriggerProtect;
                binanceFuturesUsdtSymbolEntity.SettlePlan = futuresUsdtSymbol.SettlePlan;
                binanceFuturesUsdtSymbolEntity.PriceFilterMinPrice = futuresUsdtSymbol.PriceFilter.MinPrice;
                binanceFuturesUsdtSymbolEntity.PriceFilterMaxPrice = futuresUsdtSymbol.PriceFilter.MaxPrice;
                binanceFuturesUsdtSymbolEntity.PriceFilterTickSize = futuresUsdtSymbol.PriceFilter.TickSize;
                binanceFuturesUsdtSymbolEntity.LotSizeFilterMinQuantity = futuresUsdtSymbol.LotSizeFilter.MinQuantity;
                binanceFuturesUsdtSymbolEntity.LotSizeFilterMaxQuantity = futuresUsdtSymbol.LotSizeFilter.MaxQuantity;
                binanceFuturesUsdtSymbolEntity.LotSizeFilterStepSize = futuresUsdtSymbol.LotSizeFilter.StepSize;
                binanceFuturesUsdtSymbolEntity.MarketLotSizeFilterMinQuantity = futuresUsdtSymbol.MarketLotSizeFilter.MinQuantity;
                binanceFuturesUsdtSymbolEntity.MarketLotSizeFilterMaxQuantity = futuresUsdtSymbol.MarketLotSizeFilter.MaxQuantity;
                binanceFuturesUsdtSymbolEntity.MarketLotSizeFilterStepSize = futuresUsdtSymbol.MarketLotSizeFilter.StepSize;
                binanceFuturesUsdtSymbolEntity.MaxNumberOrders = futuresUsdtSymbol.MaxOrdersFilter.MaxNumberOrders;
                binanceFuturesUsdtSymbolEntity.MaxNumberAlgorithmicOrders = futuresUsdtSymbol.MaxAlgoOrdersFilter.MaxNumberAlgorithmicOrders;
                binanceFuturesUsdtSymbolEntity.PercentPriceFilterMultiplierUp = futuresUsdtSymbol.PricePercentFilter.MultiplierUp;
                binanceFuturesUsdtSymbolEntity.PercentPriceFilterMultiplierDown = futuresUsdtSymbol.PricePercentFilter.MultiplierDown;
                binanceFuturesUsdtSymbolEntity.PercentPriceFilterMultiplierDecimal = futuresUsdtSymbol.PricePercentFilter.MultiplierDecimal;
                binanceFuturesUsdtSymbolEntity.MinNotional = futuresUsdtSymbol.MinNotionalFilter.MinNotional;
                binanceFuturesUsdtSymbolEntity.CreationDate = DateTime.Now;

                await _binanceFuturesUsdtSymbolDal.AddAsync(binanceFuturesUsdtSymbolEntity);




            }
            Console.WriteLine((await GetAllFuturesUsdtSymbolInformationAsync()).Data.Count+ "Futures Usdt Information " + " " + CommonMessages.Added);

            return new SuccessResult(CommonMessages.FuturesUsdtSymbolInformationsAddedToDatabase);

        }

        public async Task<IDataResult<List<BinanceFuturesUsdtSymbolEntity>>> GetAllFuturesUsdtSymbolInformationAsync()
        {
            var result = await _binanceFuturesUsdtSymbolDal.GetAllAsync();
            return new SuccessDataResult<List<BinanceFuturesUsdtSymbolEntity>>(result);
        }

        public async Task<IDataResult<BinanceFuturesUsdtSymbolEntity>> GetFuturesUsdtSymbolInformationBySymbolPairAsync(string symbolPair)
        {
            try
            {
                var result = await _binanceFuturesUsdtSymbolDal.GetAsync(x => x.Name == symbolPair);
                return new SuccessDataResult<BinanceFuturesUsdtSymbolEntity>(result);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<BinanceFuturesUsdtSymbolEntity>(e.Message);
            }

        }
    }
}
