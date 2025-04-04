using System;

namespace Graph.API.DataTransfers;

public class CreateAccountResponse
{
    public CreateAccountData data { get; set; }
    public string message { get; set; }
    public object meta { get; set; }
    public string status { get; set; }
}

    public class CreateAccountData
    {
        public string id { get; set; }
        public string holder_id { get; set; }
        public string holder_type { get; set; }
        public string label { get; set; }
        public object account_name { get; set; }
        public object account_number { get; set; }
        public object routing_number { get; set; }
        public object bank_name { get; set; }
        public object bank_code { get; set; }
        public object bank_address { get; set; }
        public string currency { get; set; }
        public int balance { get; set; }
        public int credit_pending { get; set; }
        public int debit_pending { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

