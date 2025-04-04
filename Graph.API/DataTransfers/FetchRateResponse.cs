using System;
using Newtonsoft.Json;

namespace Graph.API.DataTransfers;

public class FetchRateResponse
{
    public string type { get; set; }
    public string message { get; set; }
    public FetchRatesData data { get; set; }
}


    public class FetchRatesData
    {
        [JsonProperty("NGN-USD")]
        public double NGNUSD { get; set; }

        [JsonProperty("NGN-GBP")]
        public double NGNGBP { get; set; }

        [JsonProperty("NGN-EUR")]
        public double NGNEUR { get; set; }

        [JsonProperty("USD-NGN")]
        public double USDNGN { get; set; }

        [JsonProperty("GBP-NGN")]
        public double GBPNGN { get; set; }

        [JsonProperty("EUR-NGN")]
        public double EURNGN { get; set; }
    }


