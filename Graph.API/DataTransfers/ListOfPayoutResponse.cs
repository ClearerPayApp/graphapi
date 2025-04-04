using System;

namespace Graph.API.DataTransfers;

public class ListOfPayoutResponse
{
    public List<ListOfPayoutDatum> data { get; set; }
    public string message { get; set; }
    public ListOfPayoutMeta meta { get; set; }
    public string status { get; set; }
}



    public class ListOfPayoutDatum
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

    public class ListOfPayoutMeta
    {
        public int per_page { get; set; }
        public int page { get; set; }
        public int count_total { get; set; }
        public int page_total { get; set; }
        public bool prev_page { get; set; }
        public bool next_page { get; set; }
    }

 

