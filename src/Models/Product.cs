using System.Text.Json;
using System.Text.Json.Serialization;

namespace CGC.Models
{
    public class Product
    {
        public string? Product_id { get; set; }
        public string? Product_catagory { get; set; }

        
        public string? Image { get; set; }
        public double Product_price { get; set; }
        public string? Product_title { get; set; }
        public string? Product_description { get; set; }
        public int[]? Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
