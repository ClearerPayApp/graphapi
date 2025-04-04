using System;

namespace Graph.API.DataTransfers;

public class ResolveBankAccountResponse
{
    public ResolveBankData data { get; set; }
    public string message { get; set; }
    public object meta { get; set; }
    public string status { get; set; }
}


    public class ResolveBank
    {
        public string name { get; set; }
        public string code { get; set; }
        public string currency { get; set; }
    }

    public class ResolveBankData
    {
        public string account_name { get; set; }
        public string account_number { get; set; }
        public ResolveBank bank { get; set; }
    }



