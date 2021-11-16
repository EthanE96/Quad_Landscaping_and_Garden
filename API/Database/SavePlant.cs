using MySql.Data.MySqlClient;
using System;
namespace api.Database
{
    public class SavePlant : ISavePlant
    {
        public void CreatePlant(Plant myPlant){
            //open and create connection to database
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //injects sql statment into database to create a single post (database row)
            string stm = @"INSERT INTO plants(name, description, water, sunlight, season) VALUES (@name, @description, @water, @sunlight, @season)";
            using var cmd = new MySqlCommand(stm, con);
            //prevents sql injection
            cmd.Parameters.AddWithValue("@id", plants.plantID);
            cmd.Parameters.AddWithValue("@name", plants.plantName);
            cmd.Parameters.AddWithValue("@description", plants.plantDescription);
            cmd.Parameters.AddWithValue("@water", plants.plantWater);
            cmd.Parameters.AddWithValue("@sunlight", plants.plantSunlight);
            cmd.Parameters.AddWithValue("@season", plants.plantSeason);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void EditPost(int id, string name, string description, int water, int sunlight, string season){
            //open and create connection to database
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //injects sql statment into database to create update a post text
            string stm = @"UPDATE plants SET name=@name, description=@description, water=@water, sunlight=@sunlight, season=@season WHERE id=@id";
            using var cmd = new MySqlCommand(stm, con);
            //prevents sql injection
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@water", water);
            cmd.Parameters.AddWithValue("@sunlight", sunlight);
            cmd.Parameters.AddWithValue("@season", season);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}