using System.Text.Json.Serialization;

namespace proyecto.Tests.Test.API.Dtos;


public class PostDto
{
    public int id { get; set; }
    public string title { get; set; }  = string.Empty;
    public double price { get; set; }
    public string description { get; set; } = string.Empty;
    public string category { get; set; } = string.Empty;
    public string image { get; set; } = string.Empty;


}
