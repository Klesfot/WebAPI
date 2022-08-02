using Newtonsoft.Json;

namespace DotNetClient.Models;

public class Product
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("productName")]
    public string? ProductName { get; set; }
    [JsonProperty("categoryId")]
    public int CategoryId { get; set; }
    [JsonProperty("unitPrice")]
    public decimal UnitPrice { get; set; }
    [JsonProperty("unitsInStock")]
    public short UnitsInStock { get; set; }
}