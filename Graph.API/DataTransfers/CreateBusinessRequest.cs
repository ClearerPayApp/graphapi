using System;

namespace Graph.API.DataTransfers;

public class CreateBusinessRequest
{
    public string owner_id { get; set; }
    public string name { get; set; }
    public string business_type { get; set; }
    public string industry { get; set; }
    public string id_type { get; set; }
    public string id_number { get; set; }
    public string id_country { get; set; }
    public string id_upload { get; set; }
    public string id_level { get; set; }
    public string dof { get; set; }
    public string contact_phone { get; set; }
    public string contact_email { get; set; }
    public CreateBusinessAddress address { get; set; }

}


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CreateBusinessAddress
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
    }

    public class Root
    {
        
    }


