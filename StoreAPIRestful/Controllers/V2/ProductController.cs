using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAPIRestful.DTO;
using System.Text.Json;

namespace StoreAPIRestful.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/V{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private const string ApiTestURL = "https://fakestoreapi.com/products?limit=30";

        private readonly HttpClient _httpClient;

        public ProductController (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetProductData")]
        public async Task<IActionResult> GetProductDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();

            var response = await _httpClient.GetStreamAsync(ApiTestURL);

            var product = await JsonSerializer.DeserializeAsync<ProductV2[]>(response);

            return Ok(product);
        }
    }
}
