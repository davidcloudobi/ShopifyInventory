using System.Threading.Tasks;
using Domain.DTO.Request;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : Controller
    {
        public BusinessController(IBusinessService businessService)
        {
            BusinessService = businessService;
        }

        public IBusinessService BusinessService { get; set; }

        [HttpPost("create")]
        [ProducesResponseType((StatusCodes.Status200OK))]
        [ProducesResponseType((StatusCodes.Status400BadRequest))]
        public async Task<IActionResult> Create([FromBody]BusinessRequest request)
        {
            var res = await BusinessService.Add( request);
            return Ok(res);
        }
    }
}