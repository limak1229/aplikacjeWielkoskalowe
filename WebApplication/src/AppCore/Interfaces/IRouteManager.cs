using System;

namespace AppCore.Interfaces
{
    public interface IRouteManager
    {
        string GetRouteData(Guid token);
        Guid CalculateRoute(string version, string jsonString);
    }
}