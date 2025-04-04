using System;

namespace Graph.API.DataTransfers;

public class CreatePersonResponse
{
        public CreatePersonData data { get; set; }
        public string message { get; set; }
        public object meta { get; set; }
        public string status { get; set; }
}


    public class CreatePersonData
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
        public string id_country { get; set; }
        public string id_upload_type { get; set; }
        public string id_upload { get; set; }
        public string address_line1 { get; set; }
        public string address_city { get; set; }
        public string address_state { get; set; }
        public string address_country { get; set; }
        public string status { get; set; }
        public string kyc_status { get; set; }
        public string kyc_level { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
