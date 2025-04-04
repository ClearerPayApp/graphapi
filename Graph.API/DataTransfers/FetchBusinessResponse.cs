using System;

namespace Graph.API.DataTransfers;

public class FetchBusinessResponse
{
    public FetchBusinessData data { get; set; }
    public string message { get; set; }
    public object meta { get; set; }
    public string status { get; set; }
}

    public class FetchBusinessData
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

