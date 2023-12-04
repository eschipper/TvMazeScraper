﻿using Microsoft.AspNetCore.Http;
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
        public async Task<IEnumerable<Show>> Get(int page = 1)
        {
            var result = await _showRepository.GetAll(page);
            return result;
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
