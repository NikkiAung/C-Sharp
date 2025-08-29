using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok("GetProducts");
        }

        [HttpPost]
        public IActionResult CreateProducts()
        {
            return Ok("CreateProducts");
        }

        [HttpPut]
        public IActionResult CreateOrUpdateProducts()
        {
            return Ok("CreateOrUpdateProducts");
        }

        [HttpPatch]
        public IActionResult UpdateProducts()
        {
            return Ok("UpdateProducts");
        }
    }
}
