using System;

namespace Graph.API.DataTransfers;

public class ListDespositResponse
{
    public List<ListDepositsDatum> data { get; set; }
    public string message { get; set; }
    public ListDepositsMeta meta { get; set; }
    public string status { get; set; }
}


    public class ListDepositsDatum
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

    public class ListDepositsMeta
    {
        public int per_page { get; set; }
        public int page { get; set; }
        public int count_total { get; set; }
        public int page_total { get; set; }
        public bool prev_page { get; set; }
        public bool next_page { get; set; }
    }


