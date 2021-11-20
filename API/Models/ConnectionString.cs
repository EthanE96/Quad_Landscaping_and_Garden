namespace API.Models
{
    public class ConnectionString
    {
        public string cs { get; set; }
        public ConnectionString()
        {
            string server = "";
            string port = "3306";
            string database = "";
            string uid = "zkuuftcznv";
            string pwd = "AMD5N134HKY1HPY6$";

            cs = $@"Server={server}; Port={port}; Database={database}; Uid={uid}; Pwd={pwd};";
        }
    
    }
}