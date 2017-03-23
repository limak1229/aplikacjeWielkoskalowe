using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataBaseContext;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class TestRepository : ITestRepository
    {
        public List<TestTable> GetTestValues()
        {
            using (var db = new AplikacjeWielkoskaloweContext())
            {
                return db.TestTable.ToList();
            }
        }
    }
}
