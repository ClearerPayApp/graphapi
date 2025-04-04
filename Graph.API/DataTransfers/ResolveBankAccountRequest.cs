using System;

namespace Graph.API.DataTransfers;

public class ResolveBankAccountRequest
{
    public string currency { get; set; }
    public string account_number { get; set; }
    public string bank_code { get; set; }
}


