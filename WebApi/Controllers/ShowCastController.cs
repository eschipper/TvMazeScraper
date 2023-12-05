using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebApi.Logic;
using WebApi.Model;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ShowCastController : ControllerBase
    {
        private readonly IShowRepository _showRepository;
        private readonly IShowCastRepository _showCastRepository;

        public ShowCastController(IShowRepository showRepository, IShowCastRepository showCastRepository)
        {
            _showRepository = showRepository;
            _showCastRepository = showCastRepository;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var show = await _showRepository.GetById(id);

            if (show == null)
            {
                return NotFound();
            }

            var showCast = await _showCastRepository.GetById(id);

            FeaturedShow result = FeaturedShowFactory.Create(show, showCast);

            return Ok(result);
        }
    }
}
