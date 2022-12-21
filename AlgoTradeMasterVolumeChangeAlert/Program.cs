// See https://aka.ms/new-console-template for more information

using Binance.Net.Clients;
using Binance.Net.Enums;
using Business.Abstract;
using Business.Concrete;
using Business.Helpers;
using Core.Mailing;
using DataAccess.Concrete;
using RemoteData.Binance.GeneralApi.Concrete;
using RemoteData.Binance.WebSocket.Abstract;
using RemoteData.Binance.WebSocket.Concrete;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

IIndicatorService indicatorService = new IndicatorManager(
    new BinanceKlineManager(new EfBinanceFuturesUsdtKlineDal(), new BinanceApiManager(new BinanceClient())), new EfIndicatorDal(),
    new IndicatorParameterManager(new EfIndicatorParameterDal()));

IBinanceWsService binanceKlineWsService = new BinanceWsManager(new BinanceSocketClient());

IEnumerable<string> symbolList = new List<string>() { "BTCUSDT", "ETHUSDT", "LTCUSDT", "XRPUSDT", "AVAXUSDT" };

int i = 0;

List<string> newList = new List<string>();
while (i < 4)
{
    var streamData = await binanceKlineWsService.GetCurrentFuturesUsdtKlineDataListAsync(symbolList, KlineInterval.FifteenMinutes);

    if (streamData.ClosePrice != 0)
    {
        newList.Add(streamData.SymbolPair + " | Close: " + streamData.ClosePrice);
        Console.WriteLine(streamData.SymbolPair + " | Close: " + streamData.ClosePrice);


        Thread.Sleep(1000);
        i++;
    }

}

MailManager mailSettings = new MailManager();
mailSettings.MailFrom = "algotradealert@outlook.com";
mailSettings.MailFromPassword = "Trade1634*";
mailSettings.MailTo = "barisbayin@gmail.com";
mailSettings.MailSubject = "Merhaba, bu bir test mailidir.";
mailSettings.MailBody = "Merhaba, bu bir test mailidir. Umarım çalışır.\n" + string.Join(Environment.NewLine, newList); 
mailSettings.SendMail();

Console.WriteLine("Mail gönderildi.");




Console.ReadLine();