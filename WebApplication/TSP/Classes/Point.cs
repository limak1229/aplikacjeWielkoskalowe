using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSP.Classes
{
    public class Point
    {
        public int Id { get; private set; }
        public IList<Connection> PossibleConnections { get; private set; }
        public Connection IncommingConnection { get; private set; }
        public Connection OutgoingConnection { get; private set; }

        public Point(int id) : this(id, new List<Connection>()) { }

        public Point(int id, IList<Connection> possibleConnections)
        {
            Id = id;
            PossibleConnections = possibleConnections;
        }

        public Point AddPossibleConnection(Connection connection)
        {
            PossibleConnections.Add(connection);
            return this;
        }

        /// <summary>
        /// Inserts a new point between an existing connection
        /// this => B becomes this => point > B
        /// </summary>
        public void ConnectTo(Point point)
        {
            //Is this not part of a connection?
            if (this.IncommingConnection == null)
            {
                CreateNewRouteTo(point);
            }
            else
            {
                InsertIntoExistingRoute(point);
            }
        }

        private void CreateNewRouteTo(Point point)
        {
            this.OutgoingConnection = this.GetConnectionTo(point);
            Console.Write(this.Id + " => " + point.Id + ", ");

            this.IncommingConnection = point.GetConnectionTo(this);
            Console.Write(this.Id + " <= " + point.Id + ", ");


            point.OutgoingConnection = point.GetConnectionTo(this);
            Console.Write(point.Id + " => " + this.Id + ", ");

            point.IncommingConnection = this.GetConnectionTo(point);
            Console.Write(point.Id + " <= " + this.Id);

            Console.WriteLine();
        }

        private void InsertIntoExistingRoute(Point point)
        {
            if (this.IncommingConnection.From.GetConnectionTo(point).Cost < point.GetConnectionTo(this.OutgoingConnection.To).Cost)
            {
                Console.WriteLine("The incoming connection is used");

                //Use the incoming connection
                point.IncommingConnection = this.IncommingConnection.From.GetConnectionTo(point);
                Console.Write(point.Id + " <= " + this.IncommingConnection.From.Id + ", ");
                point.IncommingConnection.From.OutgoingConnection = point.IncommingConnection;
                Console.Write(point.IncommingConnection.From.Id + " => " + point.Id + ", ");

                //set the outgoing connection to THIS
                point.OutgoingConnection = point.GetConnectionTo(this);
                Console.Write(point.Id + " => " + this.Id + ", ");
                point.OutgoingConnection.To.IncommingConnection = point.OutgoingConnection;
                Console.Write(point.OutgoingConnection.To.Id + " <= " + point.Id);

                Console.WriteLine();
                Console.WriteLine();
            }
            //v-- the outgoing connection is better
            else
            {
                Console.WriteLine("The outgoing connection is used");

                //use the outgoing connection
                point.OutgoingConnection = point.GetConnectionTo(this.OutgoingConnection.To);
                Console.Write(point.Id + " => " + this.OutgoingConnection.To.Id + ", ");
                point.OutgoingConnection.To.IncommingConnection = point.OutgoingConnection;
                Console.Write(point.OutgoingConnection.To.Id + " <= " + point.Id + ", ");

                //set the incoming connection to THIS
                point.IncommingConnection = this.GetConnectionTo(point);
                Console.Write(point.Id + " <= " + this.Id + ", ");
                point.IncommingConnection.From.OutgoingConnection = point.IncommingConnection;
                Console.Write(point.IncommingConnection.From.Id + " => " + point.Id);

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public Connection GetConnectionTo(Point point)
        {
            return PossibleConnections.Single(x => x.To == point);
        }
    }
}
