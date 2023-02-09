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
    [Route("owners")]
    public class OwnerEndpointController : ControllerBase
    {

        private readonly ILogger<OwnerEndpointController> _logger;
        private IOwnerService _service;

        public OwnerEndpointController(ILogger<OwnerEndpointController> logger, IOwnerService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public List<OwnerDTO> getOwners()
        {
            return _service.getAll();
        }



        [HttpGet("{id}")]
        public OwnerDetailDTO getOwnerByID(long id){
            return _service.getById(id);
        }


        [HttpPost]
        public OwnerDetailDTO createOwner(OwnerDetailDTO toCreate){
            return _service.create(toCreate);
        }

        [HttpDelete("{id}")]
        public OwnerDetailDTO deleteOwner(OwnerDetailDTO toDelete){
            return _service.delete(toDelete);
        }

        [HttpPut("{id}")]
        public OwnerDetailDTO updateOwner(long id, OwnerDetailDTO toUpdate){
            return _service.update(id,toUpdate);
        }


        [HttpPost("search")]
        public List<OwnerDTO> searchOwner([FromBody]string searchParams){
            return _service.search(searchParams);
        } 

    }


}