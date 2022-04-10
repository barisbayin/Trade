using Binance.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteData.Constants
{
    public static class RemoteDataMessages
    {
        public static string ConnectionFailed = "Connection Failed!";
        public static string NoDatetimeRange = "There is no datetime range!";
        public static string StreamDataError = "An error occurred while retrieving stream data!";
        public static string NullOrZeroData = "There is no data!";
        public static string DataAddedToDatabase = "FuturesUsdt klines added to database!";
        public static string NoKlineData = "There is no kline data!";
        public static string AnErrorOccurredWhilePlacingOrder = "An error occurred while placing order!";
        public static string LeverageSet = "Leverage set";
        public static string AnErrorOccurredWhileSettingLeverage = "An error occurred while changing leverage";
        public static string Error= "Error occurred";
    }
}
