using System;

namespace Graph.API.DataTransfers;

public class FetchPayoutResponse
{
    public FetchPayoutResponseData data { get; set; }
    public string message { get; set; }
    public object meta { get; set; }
    public string status { get; set; }
}


    public class FetchPayoutResponseData
    {
        public string id { get; set; }
        public string account_id { get; set; }
        public string destination_id { get; set; }
        public string type { get; set; }
        public int amount { get; set; }
        public int fee { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public object status_code { get; set; }
        public object status_message { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
