using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAPIRestful.DTO;
using System.Text.Json;

namespace StoreAPIRestful.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/V{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private const string ApiTestURL = "https://fakestoreapi.com/products?limit=10";

        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetProductData")]
        public async Task<IActionResult> GetProductDataAsync()
        {
            // Clear the Headers
            _httpClient.DefaultRequestHeaders.Accept.Clear();

            var response = await _httpClient.GetStreamAsync(ApiTestURL);
            var productData = await JsonSerializer.DeserializeAsync<Product[]>(response);

            return Ok(productData);
        }
    }
}
