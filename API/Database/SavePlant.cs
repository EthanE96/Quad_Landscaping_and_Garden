using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class SavePlant : ISavePlant, ISeedPlant
    {
        public void CreatePostsTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE plants(
                id INTEGER PRIMARY KEY AUTO_INCREMENT, 
                plantName TEXT, 
                plantDescrip TEXT,
                plantWater INTEGER,
                plantSunlight INTEGER,
                season TEXT)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void SeedData()
        {
            IDeletePlant deleteTemp = new DeletePlant();
            deleteTemp.DropPlantsTable();
            
            ISeedPlant seedTemp = new SavePlant();
            seedTemp.CreatePostsTable();

            Plant tempPlant = new Plant(){
                plantName="Rose",
                plantDescrip="Rose's are very pretty and hurt",
                plantWater=100,
                plantSunlight=5,
                season="All Seasons" 
            };

            Plant tempPlant2 = new Plant(){
                plantName="Fern",
                plantDescrip="Ferns are fun and cool, yay for ferns",
                plantWater=100,
                plantSunlight=5,
                season="All Seasons" 
            };

            ISavePlant saveTemp = new SavePlant(){};
            saveTemp.CreatePlant(tempPlant);
            saveTemp.CreatePlant(tempPlant2);
        }

        public void CreatePlant(Plant allPlants)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO plants(id, plantName, plantDescrip, plantWater, plantSunlight, season) VALUES (@id, @plantName, @plantDescrip, @plantWater, @plantSunlight, @season)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", allPlants.id);
            cmd.Parameters.AddWithValue("@plantName", allPlants.plantName);
            cmd.Parameters.AddWithValue("@plantDescrip", allPlants.plantDescrip);
            cmd.Parameters.AddWithValue("@plantWater", allPlants.plantWater);
            cmd.Parameters.AddWithValue("@plantSunlight", allPlants.plantSunlight);
            cmd.Parameters.AddWithValue("@season", allPlants.season);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void EditPlant(int id, string plantName, string plantDescrip, int plantWater, int plantSunlight, string season)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            
            string stm = @"UPDATE plants SET plantName=@plantName, plantDescrip=@plantDescrip, plantWater=@plantWater, plantSunlight=@plantSunlight, season=@season WHERE id=@id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@plantName", plantName);
            cmd.Parameters.AddWithValue("@plantDescrip", plantDescrip);
            cmd.Parameters.AddWithValue("@plantWater", plantWater);
            cmd.Parameters.AddWithValue("@plantSunlight", plantSunlight);
            cmd.Parameters.AddWithValue("@season", season);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}