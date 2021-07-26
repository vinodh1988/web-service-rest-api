using System.Collections.Generic;
using rest_service.Models;
namespace rest_service.Services{
    public interface IPersonService{
        public IEnumerable<Person> GetPeople();
    }
}