using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface IRouteCalculator
    {
        void SetData(Guid token, string inputData);
        bool IsValidData(string inputData);
        Task Calculate();
        string GetResponseData();
    }
}
