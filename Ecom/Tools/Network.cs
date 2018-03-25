using System;
using System.Net.NetworkInformation;
using System.Data.Entity;
using System.Net;
using System.Data.Entity.Core.EntityClient;
using System.Configuration;
using System.Data.SqlClient;

namespace Ecom.Tools
{
    class Network
    {
    
        public Network()
        {
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(AdressChangedCallBack);
        }

        private void AdressChangedCallBack(object sender, EventArgs e)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface n in adapters)
            {
                Console.WriteLine("{0} is {1}", n.Name, n.OperationalStatus);
            }
        }
        public static bool BddConnection()
        {
            using (DbContext dbContext = new DbContext("ModelCezar"))
            {  
                if (dbContext.Database.Exists())
                    return true;
                else
                    return false;
            }
        }
        public static bool WebConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
