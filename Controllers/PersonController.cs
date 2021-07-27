using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
        [HttpPost]
        public ActionResult<Person> Post(Person person){
        
             ActionResult<Person> validate=Validate(person);
            if(validate==null){
                this.pservice.Add(person);
                return person;
            }
            return validate;
        }
        [HttpPatch]
        public ActionResult<Person> Patch(Person person){
            ActionResult<Person> validate=Validate(person);
            if(validate==null){
                 Person p=this.pservice.Get(person.Sno);
                 if(p==null)
                    return  StatusCode(StatusCodes.Status500InternalServerError, new { message = "No Such Person exists" });
                 else
                 {
                     p.Name = person.Name;
                     p.City = person.City;
                     return p;
                 }
                    
            }
            return validate;
        }
        [HttpDelete("{Sno}")]
        public ActionResult<Person> Delete(int Sno){
             Person p=this.pservice.Get(Sno);
                 if(p==null)
                    return  StatusCode(StatusCodes.Status500InternalServerError, new { message = "No Such Person exists" });
                 else
                 {
                    this.pservice.Remove(p);
                     return p;
                 }
        }


        public ActionResult<Person> Validate(Person person){
          if(person.Name==null || person.Name.Length <=2)
             return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Name is too short" });
        
           if(person.City==null || person.City.Length<=2)
             return StatusCode(StatusCodes.Status500InternalServerError, new { message = "City is too short" });
        
            return null;
        }


    }
}
