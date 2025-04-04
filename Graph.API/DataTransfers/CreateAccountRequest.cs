using System;

namespace Graph.API.DataTransfers;

public class CreateAccountRequest
{
    public string business_id { get; set; }
    public string person_id { get; set; }
    public string label { get; set; }
    public string currency { get; set; }
    public bool autosweep_enabled { get; set; }
    public bool whitelist_enabled { get; set; }
    public CreateAccountWhitelist whitelist { get; set; }
}


public class CreateAccountWhitelist
{
    public string account_number { get; set; }
    public string bank_id { get; set; }
}

