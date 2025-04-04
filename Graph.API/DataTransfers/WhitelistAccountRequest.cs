using System;

namespace Graph.API.DataTransfers;

public class WhitelistAccountRequest
{
     public string account_number { get; set; }
     public string bank_id { get; set; }
}
