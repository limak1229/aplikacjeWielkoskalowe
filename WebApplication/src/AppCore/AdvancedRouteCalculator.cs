using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppCore.Interfaces;

namespace AppCore
{
    public class AdvancedRouteCalculator: IRouteCalculator
    {
        public void SetData(Guid token, string inputData)
        {
            throw new NotImplementedException();
        }

        public bool IsValidData(string inputData)
        {
            throw new NotImplementedException();
        }

        public Task Calculate()
        {
            throw new NotImplementedException();
        }

        public string GetResponseData()
        {
            throw new NotImplementedException();
        }
    }
}
