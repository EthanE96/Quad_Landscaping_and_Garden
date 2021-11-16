using System.Data;
namespace API.Model
{
    public class ConnectionString
    {
        public class ConnectionString
    {
        public string cs { get; set; }

        public ConnectionString(){ //connection from heroku
            string server = "x8autxobia7sgh74.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "zutqg7ciwj8ud0gy";
            string port = "3306";
            string userName = "zlmbjr4vlveppcw1";
            string password = "wsxe3v7hyda23ddv";

            cs = $@"server={server}; user={userName}; database={database}; port={port}; password={password}";
        }
    }
    }
}