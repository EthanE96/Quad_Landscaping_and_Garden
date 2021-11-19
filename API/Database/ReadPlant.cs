using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class ReadPlant : IReadPlant
    {
        public List<Plant> GetAllPlants()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
    
            //sorts in desc timestamp order
            string stm = "SELECT * FROM plants ORDER BY id DESC";
            using var cmd = new MySqlCommand(stm, con); cmd.Prepare();          
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Plant> readPost = new List<Plant>();
            while (reader.Read())
            {
                readPost.Add(new Plant(){
                    id=reader.GetInt32(0),
                    plantName=reader.GetString(1),
                    plantDescrip=reader.GetString(2),
                    plantWater=reader.GetInt32(3),
                    plantSunlight=reader.GetInt32(4),
                    season=reader.GetString(5),});
            } 
            return readPost; 
        }

        public Plant GetPlant(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM plants WHERE id=@id";
            using var cmd = new MySqlCommand(stm, con);  
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return new Plant(){
                    id=reader.GetInt32(0),
                    plantName=reader.GetString(1),
                    plantDescrip=reader.GetString(2),
                    plantWater=reader.GetInt32(3),
                    plantSunlight=reader.GetInt32(4),
                    season=reader.GetString(5),};
        }
    }
}