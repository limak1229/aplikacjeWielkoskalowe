using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataBaseContext;

namespace DataAccessLayer.Interfaces
{
    public interface ITestRepository
    {
        List<TestTable> GetTestValues();
    }
}
