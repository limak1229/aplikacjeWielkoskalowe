using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSP.Interfaces;

namespace TSP.Classes
{
    public class MapOptimizer : IMapOptimizer
    {
        public void Optimize(Map map)
        {
            Random random = new Random();

            {
                //connect two randomly selected points
                Point pointA = map.GetPoint(random.Next(map.Points.Count));
                Point pointB;
                do
                {
                    pointB = map.GetPoint(random.Next(map.Points.Count));
                } while (pointB == pointA);

                pointA.ConnectTo(pointB);

            }

            int connectedPoints = 2;
            while (map.Points.Any(x => x.IncommingConnection == null || x.OutgoingConnection == null))
            {
                connectedPoints++;
                //find a point without a connection
                Point point;
                do
                {
                    point = map.GetPoint(random.Next(map.Points.Count));
                } while (point.IncommingConnection != null);

                //find the nearest point with a connection
                Point nearestPoint = null;
                foreach (Point testPoint in map.Points.Where(x => x.IncommingConnection != null))
                {
                    if (
                        nearestPoint == null
                        || point.GetConnectionTo(testPoint).Cost < point.GetConnectionTo(nearestPoint).Cost
                    )
                    {
                        nearestPoint = testPoint;
                    }
                }

                //insert the point
                nearestPoint.ConnectTo(point);
            }
        }



    }
}
