using System;

namespace Graph.API.DataTransfers;

public class DepositRequest
{
    public string account_id { get; set; }
    public string description { get; set; }
    public string sender_name { get; set; }
    public int amount { get; set; }
}


