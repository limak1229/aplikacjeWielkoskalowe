using System;
using System.Collections.Generic;
using System.Text;
using TSP.Classes;

namespace TSP.Interfaces
{
    public interface IMapCreator
    {
        Map CreateMap(string data);
    }
}
