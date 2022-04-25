using Autofac;
using Autofac.Extras.DynamicProxy;
using Binance.Net;
using Binance.Net.Interfaces;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using RemoteData.Binance.GeneralApi.Abstract;
using RemoteData.Binance.GeneralApi.Concrete;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BinanceClient>().As<IBinanceClient>().SingleInstance();
            builder.RegisterType<BinanceSocketClient>().As<IBinanceSocketClient>().SingleInstance();
            
            builder.RegisterType<BinanceCommonDatabaseParameterManager>().As<IBinanceCommonDatabaseParameterService>().SingleInstance();
            builder.RegisterType<ApiInformationManager>().As<IApiInformationService>().SingleInstance();
            builder.RegisterType<IndicatorParameterManager>().As<IIndicatorParameterService>().SingleInstance();
            builder.RegisterType<IndicatorManager>().As<IIndicatorService>().SingleInstance();
            builder.RegisterType<BinanceKlineManager>().As<IBinanceKlineService>().SingleInstance();
            builder.RegisterType<BinanceExchangeInformationManager>().As<IBinanceExchangeInformationService>().SingleInstance();
            builder.RegisterType<BinanceApiManager>().As<IBinanceApiService>().SingleInstance();
            builder.RegisterType<TradeParameterManager>().As<ITradeParameterService>().SingleInstance();
            builder.RegisterType<TradeFlowManager>().As<ITradeFlowService>().SingleInstance();
            builder.RegisterType<TradeLogManager>().As<ITradeLogService>().SingleInstance();



            builder.RegisterType<EfTradeParameterDal>().As<ITradeParameterDal>().SingleInstance();
            builder.RegisterType<EfTradeFlowDal>().As<ITradeFlowDal>().SingleInstance();
            builder.RegisterType<EfIndicatorDal>().As<IIndicatorDal>().SingleInstance();
            builder.RegisterType<EfApiInformationDal>().As<IApiInformationDal>().SingleInstance();
            builder.RegisterType<EfIndicatorParameterDal>().As<IIndicatorParameterDal>().SingleInstance();
            builder.RegisterType<EfBinanceCommonDatabaseParameterDal>().As<IBinanceCommonDatabaseParameterDal>().SingleInstance();
            builder.RegisterType<EfBinanceFuturesUsdtKlineDal>().As<IBinanceFuturesUsdtKlineDal>().SingleInstance();
            builder.RegisterType<EfBinanceFuturesUsdtSymbolDal>().As<IBinanceFuturesUsdtSymbolDal>().SingleInstance();
            builder.RegisterType<EfTradeLogDal>().As<ITradeLogDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    //Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
