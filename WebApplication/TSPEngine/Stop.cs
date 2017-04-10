﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TSPEngine
{
    public class Stop
    {
        public Stop(City city)
        {
            City = city;
        }


        public Stop Next { get; set; }

        public City City { get; set; }


        public Stop Clone()
        {
            return new Stop(City);
        }


        public static double Distance(Stop first, Stop other)
        {
            return Math.Sqrt(
                Math.Pow(first.City.x - other.City.x, 2) +
                Math.Pow(first.City.y - other.City.y, 2));
        }

        public IEnumerable<Stop> CanGetTo()
        {
            var current = this;
            while (true)
            {
                yield return current;
                current = current.Next;
                if (current == this) break;
            }
        }


        public override bool Equals(object obj)
        {
            return City == ((Stop)obj).City;
        }


        public override int GetHashCode()
        {
            return City.GetHashCode();
        }


        public override string ToString()
        {
            return City.cityName.ToString();
        }
    }
}
