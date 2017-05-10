using System;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public abstract class RouteCalculator
    {
        public abstract void SetData(Guid token, string jsonData);
        public abstract bool IsValidInputData(string jsonData);
        public abstract bool IsValidOutputData(string jsonData);
        public abstract Task Calculate();
        public abstract string GetResponseData();
    }
}