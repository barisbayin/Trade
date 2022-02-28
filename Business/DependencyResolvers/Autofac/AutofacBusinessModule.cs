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

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BinanceClient>().As<IBinanceClient>().SingleInstance();
            builder.RegisterType<BinanceSocketClient>().As<IBinanceSocketClient>().SingleInstance();
            builder.RegisterType<EfBinanceFuturesUsdtKlineDal>().As<IBinanceFuturesUsdtKlineDal>().SingleInstance();
            builder.RegisterType<BinanceCommonDatabaseParameterManager>().As<IBinanceCommonDatabaseParameterService>().SingleInstance();
            builder.RegisterType<EfBinanceCommonDatabaseParameterDal>().As<IBinanceCommonDatabaseParameterDal>().SingleInstance();
            builder.RegisterType<ApiInformationManager>().As<IApiInformationService>().SingleInstance();
            builder.RegisterType<EfApiInformationDal>().As<IApiInformationDal>().SingleInstance();
            builder.RegisterType<EfIndicatorParameterDal>().As<IIndicatorParameterDal>().SingleInstance();
            builder.RegisterType<IndicatorParameterManager>().As<IIndicatorParameterService>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    //Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
