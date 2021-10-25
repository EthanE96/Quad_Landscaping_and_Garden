using System.Collections.Generic;
using API.Model;

namespace API.Interfaces
{
    public interface IPersonDataHandler
    {
         //anything that handles person data, will make one for plants
         public List<Person> Select();
         public void Delete(Person person);
         public void Insert(Person person);
         public void Update(Person person);
    }
}