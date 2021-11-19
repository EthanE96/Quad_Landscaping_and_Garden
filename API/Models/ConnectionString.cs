namespace API.Models
{
    public class ConnectionString
    {
        public string cs { get; set; }
        public ConnectionString()
        {
            string server = "plant-database.mysql.database.azure.com";
            string port = "3306";
            string database = "plant_database";
            string uid = "QuadLG@plant-database";
            string pwd = "Password123";
            string sslMode = "Preferred";

            cs = $@"Server={server}; Port={port}; Database={database}; Uid={uid}; Pwd={pwd}; SslMode={sslMode};";
        }
    
    }
}