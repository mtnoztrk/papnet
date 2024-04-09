using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace PapNet.Models;

public record PapParamRequest
{
    [JsonPropertyName("visitorId")]
    public string VisitorId { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("sale")]
    public SaleRequest Sale { get; set; }

    [JsonPropertyName("accountId")]
    public string AccountId { get; set; } = "default1";

    [JsonPropertyName("tracking")]
    public string Tracking { get; set; } = "1";

    [JsonPropertyName("isInFrame")]
    public bool InFrame { get; set; } = false;

    [JsonConstructor]
    private PapParamRequest(string visitorId, string url, SaleRequest sale, string accountId, string tracking, bool isInFrame)
    {
        VisitorId = visitorId;
        Url = url;
        Sale = sale;
        AccountId = accountId;
        Tracking = tracking;
        InFrame = isInFrame;
    }

    public PapParamRequest(string visitorId, string url, SaleRequest sale)
    {
        VisitorId = visitorId;
        Url = url;
        Sale = sale;
    }

    public string ToQueryParameters()
    {
        var properties = from p in GetType().GetProperties()
                         where p.GetValue(this, null) != null
                         select p.GetCustomAttribute<JsonPropertyNameAttribute>()!.Name
                                + "=" + HttpUtility.UrlEncode(p.GetValue(this, null)!.ToString());
        return string.Join("&", properties.OrderBy(c => c).ToArray());
    }
}

public record SaleRequest
{
    [JsonPropertyName("ac")]
    public string Action { get; set; }
    [JsonPropertyName("t")]
    public decimal? TotalCost { get; set; }
    [JsonPropertyName("o")]
    public string? OrderId { get; set; }
    [JsonPropertyName("p")]
    public string? ProductId { get; set; }
    [JsonPropertyName("d1")]
    public string? Data1 { get; set; }
    [JsonPropertyName("d2")]
    public string? Data2 { get; set; }
    [JsonPropertyName("d3")]
    public string? Data3 { get; set; }
    [JsonPropertyName("d4")]
    public string? Data4 { get; set; }

    /// <summary>
    /// User register
    /// </summary>
    /// <param name="email"></param>
    public SaleRequest(long id, string email)
    {
        Action = "reg";
        OrderId = $"USR_{id}";
        Data1 = email;
    }

    /// <summary>
    /// sale comission
    /// </summary>
    /// <param name="totalCost"></param>
    /// <param name="orderId"></param>
    /// <param name="productName"></param>
    /// <param name="email"></param>
    public SaleRequest(decimal totalCost, Guid orderId, string productName, string email)
    {
        Action = "";
        TotalCost = totalCost;
        OrderId = $"ORD_{orderId}";
        ProductId = productName;
        Data1 = email;
    }

    public override string ToString()
    {
        return $"[{JsonSerializer.Serialize(this, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull })}]";
    }

    [JsonConstructor]
    private SaleRequest(string ac, decimal? t, string o, string p, string d1, string d2, string d3, string d4)
    {
        Action = ac;
        TotalCost = t;
        OrderId = o;
        ProductId = p;
        Data1 = d1;
        Data2 = d2;
        Data3 = d3;
        Data4 = d4;
    }
}
