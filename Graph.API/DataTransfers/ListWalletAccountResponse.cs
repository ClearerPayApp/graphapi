using System;

namespace Graph.API.DataTransfers;

public class ListWalletAccountResponse
{
    public List<ListWalletDatum> data { get; set; }
    public string message { get; set; }
    public ListWalletMeta meta { get; set; }
    public string status { get; set; }
}


    public class ListWalletDatum
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

    public class ListWalletMeta
    {
        public int per_page { get; set; }
        public int page { get; set; }
        public int count_total { get; set; }
        public int page_total { get; set; }
        public bool prev_page { get; set; }
        public bool next_page { get; set; }
    }



