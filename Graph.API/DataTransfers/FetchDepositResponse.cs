using System;

namespace Graph.API.DataTransfers;

public class FetchDepositResponse
{
    public FetchDepositData data { get; set; }
    public string message { get; set; }
    public object meta { get; set; }
    public string status { get; set; }
}


    public class FetchDepositData
    {
        public string id { get; set; }
        public string account_id { get; set; }
        public string type { get; set; }
        public string currency { get; set; }
        public int amount { get; set; }
        public int amount_settled { get; set; }
        public int fee { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }


