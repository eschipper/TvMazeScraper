using Microsoft.AspNetCore.Mvc;
using Models;
using System.Net;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ShowController : ControllerBase
    {
        private readonly IShowRepository _showRepository;

        public ShowController(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Show>> Get(int page = 1)
        {
            var result = await _showRepository.GetAll(page);
            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Show))]
        public async Task<IActionResult> GetById(string id)
        {
            var show = await _showRepository.GetById(id);
            
            return show == null 
                ? NotFound() 
                : Ok(show);
        }
    }
}
