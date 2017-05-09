using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface IRouteCalculator
    {
        void SetData(Guid token, string data);
        bool ValidateData();
        Task Calculate();
        string GetResponseData();
    }
}
