using backend.Service;
using backend.Models;
using backend.Entity;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity;


namespace backend.Controllers
{

    [ApiController]
    [Route("horses")]
    public class HorseEndpointController : ControllerBase
    {

        private readonly ILogger<HorseEndpointController> _logger;
        private IHorseService _service;

        public HorseEndpointController(ILogger<HorseEndpointController> logger, IHorseService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public List<HorseDTO> getHorses()
        {
            return _service.getAll();
        }

    }


}