using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowRepository _showRepository;

        public ShowController(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Show>> Get()
        {
            return await Task.FromResult( new List<Show> 
            {
                new Show(), new Show() 
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _showRepository.GetById(id);
            
            return result == null 
                ? NotFound() 
                : Ok(result);
        }

        //[HttpGet]
        //public Show Get(int id)
        //{
        //    return new Show();
        //}
    }
}
