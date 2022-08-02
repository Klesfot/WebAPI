using Newtonsoft.Json;
namespace DotNetClient.Models;

public class Category
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("categoryName")]
    public string? CategoryName { get; set; }
    [JsonProperty("description")]
    public string? Description { get; set; }
    [JsonProperty("imageLink")]
    public string? ImageLink { get; set; }
}