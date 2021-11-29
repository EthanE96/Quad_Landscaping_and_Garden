namespace API.Models
{
    public class ConnectionString
    {
        public string cs { get; set; }
        public ConnectionString()
        {
            string server = "yjo6uubt3u5c16az.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "n0f49rs3obnijmmo";
            string port = "3306";
            string userName = "ikq3ovpbfvzmta53";
            string password = "px6dfc5j02dvnzwj";

            cs = $@"server={server}; user={userName}; database={database}; port={port}; password={password}";
        }
    
    }
}