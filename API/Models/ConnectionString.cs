namespace API.Models
{
    public class ConnectionString
    {
        public string cs { get; set; }
        public ConnectionString()
        {
            string server = "en1ehf30yom7txe7.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "pdtfkfwr9pv14mn0";
            string port = "3306";
            string userName = "gtokn48w1l8gymjj";
            string password = "jeew77ht4kgz3cxh";

            cs = $@"server={server}; user={userName}; database={database}; port={port}; password={password}";
        }
    
    }
}