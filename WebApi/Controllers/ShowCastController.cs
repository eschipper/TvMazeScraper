using Microsoft.AspNetCore.Mvc;
using System.Globalization;
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

            var result = new FeaturedShow
            {
                Id = id,
                Name = show.name,
                Cast = new List<CastMember>(showCast.Cast.Select(
                    c => new CastMember
                    {
                        Id = c.person.id,
                        Name = c.person.name,
                        BirthDay = !string.IsNullOrEmpty(c.person.birthday) 
                            ? DateTime.ParseExact(c.person.birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture) 
                            : null
                    }))
                .OrderByDescending(c => c.BirthDay)
                
            };

            return Ok(result);
        }


        

        //[HttpGet]
        //public Show Get(int id)
        //{
        //    return new Show();
        //}
    }
}
