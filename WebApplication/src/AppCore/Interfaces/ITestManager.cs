using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataBaseContext;

namespace AppCore.Interfaces
{
    public interface ITestManager
    {
        List<TestTable> GetTestValues();
    }
}
