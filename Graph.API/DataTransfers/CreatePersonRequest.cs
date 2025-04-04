namespace Graph.API.DataTransfers;

public class CreatePersonRequest
{
    public string name_first { get; set; } 
    public string name_last { get; set; }
    public string name_other { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public string dob { get; set; }
    public string id_level { get; set; }
    public string id_type { get; set; }
    public string id_number { get; set; }
    public string id_country { get; set; }
    public string bank_id_number { get; set; }
    public string kyc_level { get; set; }
    public Address address { get; set; }
    public BackgroundInformation background_information { get; set; }
    public List<Document> documents { get; set; }
}


    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
    }

    public class BackgroundInformation
    {
        public string details { get; set; }
    }

    public class Document
    {
        public string type { get; set; }
        public string document_number { get; set; }
        public string expiry_date { get; set; }
    }

  

