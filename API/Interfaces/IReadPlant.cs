using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IReadPlant
    {
        public List<Plant> GetAllPlants();
        public Plant GetPlant(int id);
    }
}