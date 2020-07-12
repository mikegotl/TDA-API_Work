using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ContosoPets.Ui.Models
{

    //classes used for JSON deserialization
    public class StrikeData
    {
        public string putCall { get; set; }
        public string symbol { get; set; }
        public decimal bid { get; set; }
        public decimal ask { get; set; }
        public decimal last { get; set; }
        public override string ToString()
        {
            return $"{symbol}: {last} ";
        }

    }

    public class ExpirationDate : Dictionary<string, StrikeData[]>
    {
    }

    public class UnderLying
    {
        public decimal bid { get; set; }
        public decimal ask { get; set; }
        public decimal last { get; set; }
    }

    public class ExpirationDates : Dictionary<string, ExpirationDate>
    {

    }

    public class OptionChain
    {
        public string symbol { get; set; }
        public string status { get; set; }
        public UnderLying underlying;
        public string isDelayed { get; set; }
        public string underlyingPrice { get; set; }
        // public ExpirationDates callExpDateMap;
        //  public ExpirationDates putExpDateMap;
        public Dictionary<string, ExpirationDate> callExpDateMap;
        public Dictionary<string, ExpirationDate> putExpDateMap;

        public override string ToString()
        {
            return $"{symbol}: {underlyingPrice} ";
        }
    }

    //public class OptionChain
    //{
    //    public int ID { get; set; }
    //    [JsonProperty("symbol")]
    //    public string Symbol { get; set; }

    //    [JsonProperty("status")]
    //    public string Status { get; set; }

    //    [JsonProperty("underlying")]
    //    public Underlying Underlying { get; set; }

    //    [JsonProperty("strategy")]
    //    public string Strategy { get; set; }

    //    [JsonProperty("interval")]
    //    public int Interval { get; set; }

    //    [JsonProperty("isDelayed")]
    //    public bool IsDelayed { get; set; }

    //    [JsonProperty("isIndex")]
    //    public bool IsIndex { get; set; }

    //    [JsonProperty("daysToExpiration")]
    //    public int DaysToExpiration { get; set; }

    //    [JsonProperty("interestRate")]
    //    public int InterestRate { get; set; }

    //    [JsonProperty("underlyingPrice")]
    //    public int UnderlyingPrice { get; set; }

    //    [JsonProperty("volatility")]
    //    public int Volatility { get; set; }

    //    [JsonProperty("callExpDateMap")]
    //    public string CallExpDateMap { get; set; }

    //    [JsonProperty("putExpDateMap")]
    //    public string PutExpDateMap { get; set; }

    //}

    //public class Underlying
    //{
    //    public int ID { get; set; }

    //    [JsonProperty("ask")]
    //    public int Ask { get; set; }

    //    [JsonProperty("askSize")]
    //    public int AskSize { get; set; }

    //    [JsonProperty("bid")]
    //    public int Bid { get; set; }

    //    [JsonProperty("bidSize")]
    //    public int BidSize { get; set; }

    //    [JsonProperty("change")]
    //    public int Change { get; set; }

    //    [JsonProperty("close")]
    //    public int Close { get; set; }

    //    [JsonProperty("delayed")]
    //    public bool Delayed { get; set; }

    //    [JsonProperty("description")]
    //    public string Description { get; set; }

    //    [JsonProperty("exchangeName")]
    //    public string ExchangeName { get; set; }

    //    [JsonProperty("fiftyTwoWeekHigh")]
    //    public int FiftyTwoWeekHigh { get; set; }

    //    [JsonProperty("fiftyTwoWeekLow")]
    //    public int FiftyTwoWeekLow { get; set; }

    //    [JsonProperty("highPrice")]
    //    public int HighPrice { get; set; }

    //    [JsonProperty("last")]
    //    public int Last { get; set; }

    //    [JsonProperty("lowPrice")]
    //    public int LowPrice { get; set; }

    //    [JsonProperty("mark")]
    //    public int Mark { get; set; }

    //    [JsonProperty("markChange")]
    //    public int MarkChange { get; set; }

    //    [JsonProperty("markPercentChange")]
    //    public int MarkPercentChange { get; set; }

    //    [JsonProperty("openPrice")]
    //    public int OpenPrice { get; set; }

    //    [JsonProperty("percentChange")]
    //    public int PercentChange { get; set; }

    //    [JsonProperty("quoteTime")]
    //    public int QuoteTime { get; set; }

    //    [JsonProperty("symbol")]
    //    public string Symbol { get; set; }

    //    [JsonProperty("totalVolume")]
    //    public int TotalVolume { get; set; }

    //    [JsonProperty("tradeTime")]
    //    public int TradeTime { get; set; }

    //}


}
