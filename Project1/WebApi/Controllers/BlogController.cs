using System;
using Domain.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataBase.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        // private readonly AppDbContext _dbContext;

        // public BlogController(AppDbContext dbContext)
        // {
        //     _dbContext = dbContext;
        // }
        
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var model = _blogService.GetBlogs();
            return Ok(model);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public IActionResult GetBlogs(int pageNo = 1, int pageSize = 10)
        {
            var model = _blogService.GetBlogs(pageNo, pageSize);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var model = _blogService.GetBlog(id);
            if (!model.IsSuccess)
            {
                return NotFound(model.Message);
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateBlog([FromBody] TblBlog blog)
        {
            var model = _blogService.CreateBlog(blog);
            if (!model.IsSuccess)
            {
                return BadRequest(model.Message);
            }
            return Ok(model);
        }


    }
}
