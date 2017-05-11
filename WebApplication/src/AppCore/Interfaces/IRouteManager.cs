using System;
using AppCore.Models;

namespace AppCore.Interfaces
{
    public interface IRouteManager<T>
    {
        T GetRouteData(Guid token);
        Guid CalculateRoute(T data);
    }
}