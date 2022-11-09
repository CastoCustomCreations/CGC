using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using CGC.Models;
using Microsoft.AspNetCore.Hosting;

namespace CGC.Services
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

        public IEnumerable<Product> GetProducts()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public void AddRating(string productProduct_id, int rating)
        {
            var products = GetProducts();

            if (products.First(x => x.Product_id == productProduct_id).Ratings == null)
            {
                products.First(x => x.Product_id == productProduct_id).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = products.First(x => x.Product_id == productProduct_id).Ratings.ToList();
                ratings.Add(rating);
                products.First(x => x.Product_id == productProduct_id).Ratings = ratings.ToArray();
            }

            using var outputStream = File.OpenWrite(JsonFileName);

            JsonSerializer.Serialize<IEnumerable<Product>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                products
            );
        }
    }
}
