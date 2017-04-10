using System;
using System.Collections.Generic;
using System.Text;

namespace TSPEngine
{
    public class City
    {
        public Double x { get; private set; }

        public Double y { get; private set; }

        public Int32 cityName { get; private set; }


        public City(Int32 cityName, Double x, Double y)
        {
            this.x = x;
            this.y = y;
            this.cityName = cityName;
        }



    }
}
