using System;
using System.Collections.Generic;
using System.Text;
using TSP.Interfaces;

namespace TSP.Classes
{
    public class StaticMapCreator : IMapCreator
    {
        public Map CreateMap(string data)
        {
            Map map = new Map();

            Point a = new Point(0);
            Point b = new Point(1);
            Point c = new Point(2);
            Point d = new Point(3);
            Point e = new Point(4);

            Connection ab = new Connection(a, b, 1);
            Connection ac = new Connection(a, c, 1);
            Connection ad = new Connection(a, d, 2);
            Connection ae = new Connection(a, e, 5);
            a.AddPossibleConnection(ab)
                .AddPossibleConnection(ac)
                .AddPossibleConnection(ad)
                .AddPossibleConnection(ae);

            Connection ba = new Connection(b, a, 1);
            Connection bc = new Connection(b, c, 2);
            Connection bd = new Connection(b, d, 1);
            Connection be = new Connection(b, e, 1);
            b.AddPossibleConnection(ba)
                .AddPossibleConnection(bc)
                .AddPossibleConnection(bd)
                .AddPossibleConnection(be);

            Connection ca = new Connection(c, a, 1);
            Connection cb = new Connection(c, b, 2);
            Connection cd = new Connection(c, d, 1);
            Connection ce = new Connection(c, e, 5);
            c.AddPossibleConnection(ca)
                .AddPossibleConnection(cb)
                .AddPossibleConnection(cd)
                .AddPossibleConnection(ce); ;

            Connection da = new Connection(d, a, 2);
            Connection db = new Connection(d, b, 1);
            Connection dc = new Connection(d, c, 1);
            Connection de = new Connection(d, e, 1);
            d.AddPossibleConnection(da)
                .AddPossibleConnection(db)
                .AddPossibleConnection(dc)
                .AddPossibleConnection(de);

            Connection ea = new Connection(e, a, 5);
            Connection eb = new Connection(e, b, 1);
            Connection ec = new Connection(e, c, 5);
            Connection ed = new Connection(e, d, 1);
            e.AddPossibleConnection(ea)
                .AddPossibleConnection(eb)
                .AddPossibleConnection(ec)
                .AddPossibleConnection(ed);

            map.AddPoint(a)
                .AddPoint(b)
                .AddPoint(c)
                .AddPoint(d)
                .AddPoint(e);

            return map;
        }


    }
}