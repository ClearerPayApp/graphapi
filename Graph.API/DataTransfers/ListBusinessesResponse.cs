using System;

namespace Graph.API.DataTransfers;

public class ListBusinessesResponse
{
    public List<ListBusinessesDatum> data { get; set; }
    public string message { get; set; }
    public ListBusinessesMeta meta { get; set; }
    public string status { get; set; }
}

    public class ListBusinessesDatum
    {
        public string id { get; set; }
        public string owner_id { get; set; }
        public string name { get; set; }
        public string business_type { get; set; }
        public string industry { get; set; }
        public DateTime dof { get; set; }
        public bool is_master { get; set; }
        public string id_type { get; set; }
        public string id_number { get; set; }
        public string address_line1 { get; set; }
        public string address_city { get; set; }
        public string address_state { get; set; }
        public string address_country { get; set; }
        public string address_zip { get; set; }
        public string status { get; set; }
        public string kyb_status { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class ListBusinessesMeta
    {
        public int per_page { get; set; }
        public int page { get; set; }
        public int count_total { get; set; }
        public int page_total { get; set; }
        public bool prev_page { get; set; }
        public bool next_page { get; set; }
    }


