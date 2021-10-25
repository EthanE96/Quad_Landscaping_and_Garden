using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using System.Dynamic;
using System.Collections.Generic;
using api.Data;
using API.Interfaces;
using API.Model;

namespace API.Data
{
    public class PersonDataHandler : IPersonDataHandler
    {
        private Database db;
    
        public PersonDataHandler()
        {
            db = new Database();
        }

        public void Delete(Person person){
            throw new System.NotImplementedException();
        }

        public void Insert(Person person){
            throw new System.NotImplementedException();
        }

        public List<Person> Select(){
            db.Open();
            string sql = "SELECT * FROM person";
            List<ExpandoObject> results = db.Select(sql);

            List<Person> people = new List<Person>();
            foreach (dynamic item in results){
                Person temp = new Person(){
                  ID= item.id,
                  FirstName= item.first_name,
                  LastName= item.last_name,
                  Major= item.major
                };
                people.Add(temp);
            }
            db.Close();
            return people;
        }

        public void Update(Person person){
            throw new System.NotImplementedException();
        }
    }
}