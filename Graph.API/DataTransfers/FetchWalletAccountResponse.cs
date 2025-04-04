using System;

namespace Graph.API.DataTransfers;

    public class FetchWalletAccountResponse
    {
        public FetchWalletAccountData data { get; set; }
        public string message { get; set; }
        public object meta { get; set; }
        public string status { get; set; }
    }



    public class FetchWalletAccountData
    {
        public string id { get; set; }
        public string holder_id { get; set; }
        public string holder_type { get; set; }
        public string label { get; set; }
        public string currency { get; set; }
        public long balance { get; set; }
        public object block_expiry { get; set; }
        public string kind { get; set; }
        public string status { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

