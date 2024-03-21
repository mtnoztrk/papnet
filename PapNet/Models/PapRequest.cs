using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PapNet.Models;

public record PapRequest
{
    [JsonPropertyName("C")]
    public string ClassName { get; set; }

    [JsonPropertyName("M")]
    public string MethodName { get; set; }

    [JsonPropertyName("S")]
    public string? SessionId { get; set; }

    [JsonPropertyName("fields")]
    public List<List<string?>> Fields { get; set; }

    private PapRequest(string className, string method)
    {
        ClassName = className;
        MethodName = method;
        Fields = new List<List<string?>>();
    }

    public static PapRequest Login(string username, string password)
    {
        var request = new PapRequest("Pap_Api_AuthService", "authenticate");
        request.Fields.Add(new List<string?> { "name", "value", "values", "error" });
        request.Fields.Add(new List<string?> { "username", username, null, "" });
        request.Fields.Add(new List<string?> { "password", password, null, "" });
        request.Fields.Add(new List<string?> { "roleType", "M", null, "" });
        request.Fields.Add(new List<string?> { "isFromApi", "Y", null, "" });
        request.Fields.Add(new List<string?> { "apiVersion", "c278cce45ba296bc421269bfb3ddff74", null, "" });
        return request;
    }

    public FormUrlEncodedContent ToFormData()
    {
        var values = new Dictionary<string, string>
        {
            {"D", JsonSerializer.Serialize(this)}
        };
        return new FormUrlEncodedContent(values);
    }
}
