using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSP.Interfaces;

namespace TSP.Classes
{
    public class Map
    {
        public IList<Point> Points { get; private set; }

        public Map() : this(new List<Point>()) { }

        public Map(IList<Point> points)
        {
            Points = points;
        }

        public Map AddPoint(Point point)
        {
            Points.Add(point);
            return this;
        }

        public Point GetPoint(int id)
        {
            return Points.Single(x => x.Id == id);
        }

        public void Optimize(MapOptimizer optimizer)
        {
            optimizer.Optimize(this);
        }

        public float GetCostOfWholeRoute()
        {
            Point startingPoint = Points.First();
            float cost = startingPoint.OutgoingConnection.Cost;

            Point currentPoint = startingPoint.OutgoingConnection.To;
            while (currentPoint != startingPoint)
            {
                cost += currentPoint.OutgoingConnection.Cost;
                currentPoint = currentPoint.OutgoingConnection.To;
            }

            return cost;
        }
    }
}
