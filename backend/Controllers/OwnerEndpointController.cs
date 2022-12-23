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

    }


}