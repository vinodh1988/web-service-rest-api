using System.Collections.Generic;
using rest_service.Models;
namespace rest_service.Services{
    class PersonService : IPersonService{

        List<Person> list=new List<Person>(){
            new Person() {Sno=1,Name="Ganesh",City="Chennai"},
            new Person() {Sno=2,Name="Kiran",City="Chennai"}
        };
        public IEnumerable<Person> GetPeople(){
             return list;     
        }

        public void Add(Person person){
                 this.list.Add(person);
        }

        public Person Get(int Sno){
            foreach(var x in list){
                if(x.Sno == Sno) 
                    return x;
            }
            return null;
        }

        public void Remove(Person person){
            this.list.Remove(person);
        }
    }
}