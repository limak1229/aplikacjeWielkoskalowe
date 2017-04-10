using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSPEngine
{
    public static class Config
    {
        public static void Connect(this IEnumerable<Stop> stops, bool loop)
        {
            Stop prev = null, first = null;
            foreach (var stop in stops)
            {
                if (first == null) first = stop;
                if (prev != null) prev.Next = stop;
                prev = stop;
            }

            if (loop)
            {
                prev.Next = first;
            }
        }
        public static T MinBy<T, TComparable>(
        this IEnumerable<T> xs,
        Func<T, TComparable> func)
        where TComparable : IComparable<TComparable>
            {
                return xs.DefaultIfEmpty().Aggregate(
                    (maxSoFar, elem) =>
                    func(elem).CompareTo(func(maxSoFar)) > 0 ? maxSoFar : elem);
            }


        public static IEnumerable<Stop> NearestNeighbors(this IEnumerable<Stop> stops)
        {
            var stopsLeft = stops.ToList();
            for (var stop = stopsLeft.First();
                 stop != null;
                 stop = stopsLeft.MinBy(s => Stop.Distance(stop, s)))
            {
                stopsLeft.Remove(stop);
                yield return stop;
            }
        }
    }
}
