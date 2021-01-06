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
        public async Task<IActionResult> Index(Guid businessId, ProductRequest request)
        {
            var res = await ProductService.Add(businessId, request);
            return Ok(res);
        }
    }
}