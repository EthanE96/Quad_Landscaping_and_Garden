using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using API.interfaces;
using API.models;

namespace API.Database
{
    public class ReadPlant : IReadPlant
    {
        public List<Plant> GetAllPlants(){
            //open and create connection to database
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //injects sql statment into database to gather all data
            string stm = "SELECT * FROM plants ORDER BY id DESC";
            using var cmd = new MySqlCommand(stm, con); cmd.Prepare();          
            MySqlDataReader reader = cmd.ExecuteReader();

           List<Plant> readPlant = new List<Plant>(); //list to hold each plant and their data
           while (reader.Read()){
               readPlant.Add(new Plant(){plantID=reader.GetInt32(0),plantName=reader.GetString(1),plantDescription=reader.GetString(2),plantWater=reader.GetInt32(3),plantSunlight=reader.GetInt32(4),plantSeason=reader.GetString(5)});
           } //continues till entire database is read
            return readPlant; //returns full list to be read out to console
        }
    }
}