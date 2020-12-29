using System;
using System.Threading.Tasks;
using Domain.DTO.Request;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        public BrandController(IBrandService brandService)
        {
            BrandService = brandService;
        }

        public IBrandService BrandService { get; set; }

        /// <summary>
        /// add new brand
        /// </summary>
        /// <param name="businessId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{businessId}/create")]
        public async Task<IActionResult> Create(Guid businessId, BrandRequest request)
        {
            var res = await BrandService.Add(businessId, request);
            return Ok(res);
        }
    }
}