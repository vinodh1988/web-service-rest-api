using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rest_service.Services;
using rest_service.Models;

namespace rest_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        IPersonService pservice;
        public  PersonController(IPersonService service){
                this.pservice = service;
         }

        private readonly ILogger<WeatherForecastController> _logger;

      

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return this.pservice.GetPeople();
        }
    }
}
