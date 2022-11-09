using System.Collections.Generic;
using CGC.Models;
using CGC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CGC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService) => 
            ProductService = productService;

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get() => ProductService.GetProducts();

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            if (request?.ProductProduct_id == null)
                return BadRequest();

            ProductService.AddRating(request.ProductProduct_id, request.Rating);

            return Ok();
        }

        public class RatingRequest
        {
            public string? ProductProduct_id { get; set; }
            public int Rating { get; set; }
        }
    }
}
