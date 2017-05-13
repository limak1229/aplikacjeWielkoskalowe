using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSPClientRepository.Models
{
    public class UserSettings
    {
        private static UserSettings instance;
        public string token { get; set; }
        public DateTime latestUse { get; set; }
        public static UserSettings Instance()
        {
            if (instance == null)
            {
                instance = new UserSettings();
            }
            return instance;
        }

    }
}