namespace Graph.API.DataTransfers;

public class UpdateAccountResponse
{
    public UpdateAccountData data { get; set; }
    public string message { get; set; }
    public object meta { get; set; }
    public string status { get; set; }
}


    public class UpdateAccountBankAddress
    {
        public string line1 { get; set; }
        public object line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
    }

    public class UpdateAccountBeneficiaryAddress
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
    }

    public class UpdateAccountData
    {
        public string id { get; set; }
        public string holder_id { get; set; }
        public string holder_type { get; set; }
        public string label { get; set; }
        public string account_name { get; set; }
        public string account_number { get; set; }
        public string routing_number { get; set; }
        public object iban { get; set; }
        public object swift_code { get; set; }
        public object check_number { get; set; }
        public string bank_name { get; set; }
        public object bank_code { get; set; }
        public UpdateAccountBankAddress bank_address { get; set; }
        public UpdateAccountBeneficiaryAddress beneficiary_address { get; set; }
        public string currency { get; set; }
        public string currency_settlement { get; set; }
        public int balance { get; set; }
        public int credit_pending { get; set; }
        public int debit_pending { get; set; }
        public object block_expiry { get; set; }
        public bool autosweep_enabled { get; set; }
        public bool whitelist_enabled { get; set; }
        public string type { get; set; }
        public string kind { get; set; }
        public string status { get; set; }
        public object status_description { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }


