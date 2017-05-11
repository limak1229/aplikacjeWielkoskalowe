using System;

namespace AppCore.Interfaces
{
    public interface IRouteManager<T>
    {
        T GetRouteData(Guid token);
        Guid CalculateRoute(T data);
    }
}