using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PapNet.Models;

public record PapGenericResponse
{
    [JsonPropertyName("fields")]
    public List<List<string?>> Fields { get; set; } = new List<List<string?>>();

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("e")]
    public string? Error { get; set; }

    public bool Success => string.IsNullOrEmpty(Error);
}

public abstract record PapResponse
{
    public PapResponse(PapGenericResponse response)
    {

    }
}
