using API.Models;

namespace API.Interfaces
{
    public interface ISavePlant
    {
        public void CreatePlant(Plant allPlants);
        public void EditPlant(int id, string plantName, string plantDescrip, int plantWater, int plantSunlight, string season, string imageUrl);
    }
}
