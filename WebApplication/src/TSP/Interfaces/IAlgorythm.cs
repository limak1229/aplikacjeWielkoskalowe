using System;
using System.Collections.Generic;
using TSPEngine;

namespace Algorythms.Interfaces
{
    public interface IAlgorythm<in T> where T : new()
    {
        void CalculateRoute(Guid token, T data);
    }
}