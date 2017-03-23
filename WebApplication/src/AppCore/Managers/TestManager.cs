using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using DataAccessLayer.DataBaseContext;
using DataAccessLayer.Interfaces;

namespace AppCore.Managers
{
    public class TestManager: ITestManager
    {
        private readonly ITestRepository _testRepository;

        public TestManager(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public List<TestTable> GetTestValues()
        {
            return _testRepository.GetTestValues();
        }
    }
}
