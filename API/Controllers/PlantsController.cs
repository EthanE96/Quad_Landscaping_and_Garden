using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        // GET: api/plants
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Plant> Get()
        {
            IReadPlant readObject = new ReadPlant();
            return readObject.GetAllPlants();
        }

        // GET: api/plants/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Plant Get(int id)
        {
          IReadPlant readPlant = new ReadPlant();
          return readPlant.GetPlant(id);
        }

        // POST: api/plants
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Plant value)
        {
            ISavePlant newPlant = new SavePlant();
            newPlant.CreatePlant(value);
        }

        // PUT: api/plants/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string plantName)
        {
            //need to edit
            if (plantName == "reseed")
            {
                ISeedPlant seedPlants = new SavePlant();
                seedPlants.SeedData();
            }
            else
            {
                //ISavePlant savePlant = new SavePlant();
                //savePlant.EditPlant(id, plantName);
            }
        }

        // DELETE: api/plants/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeletePlant deletePlant = new DeletePlant();
            deletePlant.RemovePlant(id);
        }
    }
}
        //for future reference => 
        //the [FromBody] is the body: JSON.stringify(value)
        //the [HttpDelete("{id}")] the added data to the https request ...
        //which can also be sent to the constructor