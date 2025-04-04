using System;

namespace Graph.API.DataTransfers;

public class CreatePayoutRequest
{
    public string destination_id { get; set; }
    public int amount { get; set; }
    public string description { get; set; }
    public string supporting_document { get; set; }
}



