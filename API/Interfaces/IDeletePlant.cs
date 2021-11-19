namespace API.Interfaces
{
    public interface IDeletePlant
    {
        public void DropPlantsTable();
        public void RemovePlant(int postID); 
    }
}