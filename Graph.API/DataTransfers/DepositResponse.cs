using System;

namespace Graph.API.DataTransfers;

public class DepositResponse
{
    public object data { get; set; }
    public string message { get; set; }
    public object meta { get; set; }
    public string status { get; set; }
}

