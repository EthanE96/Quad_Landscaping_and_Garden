using API.Data;
using API.Interfaces;

namespace API.Model
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }         
        public string Major { get; set; }

        IPersonDataHandler dataHandler { get; set; }

        public Person(){
            this.dataHandler = new PersonDataHandler();
        }
    }
}