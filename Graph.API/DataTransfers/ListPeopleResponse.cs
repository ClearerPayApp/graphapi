using System;

namespace Graph.API.DataTransfers;

public class ListPeopleResponse
{
      public List<ListPeopleResponseDatum> data { get; set; }
    public string message { get; set; }
    public ListPeopleMeta meta { get; set; }
    public string status { get; set; }
}

    public class ListPeopleResponseDatum
    {
        public string id { get; set; }
        public string name_first { get; set; }
        public string name_last { get; set; }
        public string name_other { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime dob { get; set; }
        public string id_level { get; set; }
        public string id_type { get; set; }
        public string id_number { get; set; }
        public string address_line1 { get; set; }
        public string address_city { get; set; }
        public string address_state { get; set; }
        public string address_country { get; set; }
        public string status { get; set; }
        public string kyc_status { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class ListPeopleMeta
    {
        public int per_page { get; set; }
        public int page { get; set; }
        public int count_total { get; set; }
        public int page_total { get; set; }
        public bool prev_page { get; set; }
        public bool next_page { get; set; }
    }



