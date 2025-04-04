using System;

namespace Graph.API.DataTransfers;

public class CreatePayoutResponse
{
    public CreatePayoutData data { get; set; }
    public string message { get; set; }
    public object meta { get; set; }
    public string status { get; set; }
}


    public class CreatePayoutData
    {
        public CreatePayout payout { get; set; }
        public CreatePayoutTransaction transaction { get; set; }
    }

    public class CreatePayout
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

    public class CreatePayoutTransaction
    {
        public string id { get; set; }
        public string account_id { get; set; }
        public string kind { get; set; }
        public object deposit_id { get; set; }
        public string payout_id { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public object linked_transaction_id { get; set; }
        public string currency { get; set; }
        public int amount { get; set; }
        public object balance_before { get; set; }
        public object balance_after { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

