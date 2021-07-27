using System.Collections.Generic;
using rest_service.Models;
namespace rest_service.Services{
    public interface IPersonService{
        public IEnumerable<Person> GetPeople();
        public void Add(Person person);
        public Person Get(int Sno);
        public void Remove(Person person);
    }
}