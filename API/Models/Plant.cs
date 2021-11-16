using API.Data;
using API.Interfaces;

namespace API.Model
{
    public class Plant
    {
        public int plantID { get; set; }
        public string plantName { get; set; }
        public string plantDescription { get; set; }
        public int plantWater{get; set;}
        public int plantSunlight{get; set;}
        public string season{get; set;}
        public ISavePlant Save { get; set; }
        public IDeletePlant Delete { get; set; }

        public Plant(){
            Save = new SavePlant();
            Delete = new DeletePlant();
        }
    }
}