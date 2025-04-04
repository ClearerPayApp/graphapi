using System;

namespace Graph.API.DataTransfers;

public class ListBankReponse
{
    public List<ListBankDatum> data { get; set; }
    public string message { get; set; }
    public object meta { get; set; }
    public string status { get; set; }
}

    public class ListBankDatum
    {
        public string name { get; set; }
        public string code { get; set; }
        public string currency { get; set; }
    }

