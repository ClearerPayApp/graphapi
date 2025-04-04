using System;

namespace Graph.API.DataTransfers;

public class RemoveWhiteListAccountResponse
{
        public RemoveWhiteListAccountData data { get; set; }
        public string message { get; set; }
        public object meta { get; set; }
        public string status { get; set; }
}

    public class RemoveWhiteListAccountData
    {
        public string id { get; set; }
        public string bank_id { get; set; }
        public string account_id { get; set; }
        public string account_number { get; set; }
        public string account_name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

  
