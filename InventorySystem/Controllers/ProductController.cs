using System;
using System.Threading.Tasks;
using Domain.DTO.Request;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        public IProductService ProductService { get; set; }

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="businessId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{businessId}/create")]
        public async Task<IActionResult> Add(Guid businessId, ProductRequest request)
        {
            var res = await ProductService.Add(businessId, request);
            return Ok(res);
        }

        /// <summary>
        /// Get products
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>

        [HttpGet("{businessId}/products")]
        public async Task<IActionResult> GetProducts([FromRoute] Guid businessId)
        {
            var response = await ProductService.GetProducts(businessId);
            return Ok(response);
        }
    }
}