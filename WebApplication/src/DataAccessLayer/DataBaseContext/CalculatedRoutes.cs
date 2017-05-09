using System;
using System.Collections.Generic;

namespace DataAccessLayer.DataBaseContext
{
    public partial class CalculatedRoutes
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public string DataVersion { get; set; }
        public string Data { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
