using System;
using System.Net.Http;

namespace TSPClientRepository.Classes
{
    public class ConnectionInitial
    {
        private static ConnectionInitial instance;
        HttpClient httpClient;
        private ConnectionInitial()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://79.137.74.214:60/");
            //httpClient.BaseAddress = new Uri("http://localhost:54640/");
        }
        public static ConnectionInitial Instance()
        {
            if (instance == null) { 
                instance =  new ConnectionInitial();
            }
            return instance;
        }
        public static HttpClient GetServer()
        {
            return Instance().httpClient;
        }
    }
}