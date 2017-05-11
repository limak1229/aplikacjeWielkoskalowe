using System;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public abstract class RouteCalculator<T>
    {
        public abstract Guid GenerateToken();
        public abstract void SetInputData(T data);
        public abstract void SetOutputData(Guid token);
        public abstract bool IsValidInputData();
        public abstract bool IsValidOutputData();
        public abstract Task Calculate();
        public abstract T GetResponseData();
    }
}