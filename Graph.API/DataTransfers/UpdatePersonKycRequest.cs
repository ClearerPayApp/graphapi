using System;

namespace Graph.API.DataTransfers;

public class UpdatePersonKycRequest
{
    public int PersonId { get; set; }
    public string IdType { get; set; } = string.Empty; 
    public string IdNumber { get; set; } = string.Empty; 
    public string IdCountry { get; set; } = string.Empty; 
    public string IdUpload { get; set; } = string.Empty; 
}
