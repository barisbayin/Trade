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
        public static string NoKlineData = "There is no kilne data!";
        
    }
}
