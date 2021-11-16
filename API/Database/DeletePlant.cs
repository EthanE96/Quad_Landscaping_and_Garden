using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class DeletePlant : IDeletePlant
    {
        public void RemovePlant(int id){
             //open and create connection to database
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //injects sql statment into database to remove row where user selected id
            string stm = @"DELETE FROM plants WHERE id=@id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            //prvents sql injection
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}