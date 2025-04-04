using System;

namespace Graph.API.DataTransfers;

public class ListOfTransactionResponse
{
    public List<ListOfTransactionDatum> data { get; set; }
    public string message { get; set; }
    public ListOfTransactionMeta meta { get; set; }
    public string status { get; set; }
}

    public class ListOfTransactionDatum
    {
        public string id { get; set; }
        public string account_id { get; set; }
        public string kind { get; set; }
        public string deposit_id { get; set; }
        public object payout_id { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public object linked_transaction_id { get; set; }
        public string currency { get; set; }
        public int amount { get; set; }
        public int balance_before { get; set; }
        public int balance_after { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class ListOfTransactionMeta
    {
        public int per_page { get; set; }
        public int page { get; set; }
        public int count_total { get; set; }
        public int page_total { get; set; }
        public bool prev_page { get; set; }
        public bool next_page { get; set; }
    }

