using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTF
{
    public class DatabaseConfig
    {
        public string ServerIp { get; }
        public string DatabaseName { get; }
        public string Username { get; }
        public string Password { get; }

        public int ConnectTimeout { get; }
        public DatabaseConfig(string ServerIp, string DatabaseName, string Username, string Password, int ConnectTimeout)
        {
            this.ServerIp = ServerIp;
            this.DatabaseName = DatabaseName;
            this.Username = Username;
            this.Password = Password;
            this.ConnectTimeout = ConnectTimeout;
        }
    }
}
