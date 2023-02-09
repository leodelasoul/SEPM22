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

        [HttpGet("{id}")]
        public HorseDetailDTO getHorseByID(long id){
            return _service.getById(id);
        }


        [HttpPost]
        public HorseDetailDTO createHorse(HorseDetailDTO toCreate){
            return _service.create(toCreate);
        }

        [HttpDelete("{id}")]
        public void deleteHorse(long id){
             _service.delete(id);
        }

        [HttpPut("{id}")]
        public HorseDetailDTO updateHorse(long id, HorseDetailDTO toUpdate){
            return _service.update(id, toUpdate);

        }

        [HttpPost("search")]
        public List<HorseSearchDTO> searchHorse([FromBody] string searchText){
            return _service.search(searchText);
        }





    }


}