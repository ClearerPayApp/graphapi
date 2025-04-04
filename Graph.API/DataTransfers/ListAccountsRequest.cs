namespace Graph.API.DataTransfers;

public class ListAccountsRequest
{
    public int Page { get; set; } = 1;
    public int PerPage { get; set; } = 20;
    public string? From { get; set; } 
    public string? To { get; set; }  
    public string? SettlementCurrency { get; set; }
    public string? Currency { get; set; }
    public string? Label { get; set; }
    public string? Status { get; set; }
    public string? Provider { get; set; }
    public string? Kind { get; set; }
    public string? Type { get; set; }
    public string? HolderType { get; set; }
    public bool? AutoSweepEnabled { get; set; }
}