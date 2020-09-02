using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ApplicationMonitor
{
    public struct Point
    {
        private int X { get; set; }
        private int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void UpdatePoint(ref Point p1, ref Point p2)
        {
            Point tempPoint = new Point(p1.X, p1.Y);
            p1 = p2;
            p2 = tempPoint;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
