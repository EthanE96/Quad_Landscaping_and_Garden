using API.Interfaces;

namespace API.Models
{
    public class Plant
    {
        public int id { get; set; }
        public string imageUrl{get; set;}
        public string plantName { get; set; }
        public string plantDescrip { get; set; }
        public int plantWater{get; set;}
        public int plantSunlight{get; set;}
        public string season{get; set;}
    }
}