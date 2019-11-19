using System;
namespace Labb2
{
    public class Position
    {
        //Properties

        double x = 0;
        public double XValue
        {
            get => x;

            set
            {
                x = value >= 0 ? value : value * -1;
            }
        }

        double y = 0;
        public double YValue
        {
            get => y;

            set
            {
                y = value >= 0 ? value : value * -1;
            }
        }

        // Default constructor // might delete
        public Position()
        {
        }
        // En konstruktor som tar emot ett x-värde och ett y-värde och lagrar dem sedan i lämpliga properties
        public Position(double x, double y)
        {
            XValue = x;
            YValue = y;
        }

        //Methods starts here

        public double Length()
        {
            //pythagoras sats
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public bool Equals(Position p)
        {
            return p.XValue.Equals(this.XValue) && p.YValue.Equals(this.YValue) ? true : false;
        }


        public Position Clone()
        //Skall returnera en ny instans av Position, som har samma X och Y•värden som den nuvarande punkten.
        {
            return new Position(this.x, this.y);
        }


        public override string ToString()
        {
            return $"({x},{y})";
        }

        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length() > p2.Length())
            {
                return true;
            }
            return false;
        }
        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() < p2.Length())
            {
                return true;
            }
            return false;
        }

        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.XValue + p2.XValue, p1.YValue + p2.YValue);
        }

        public static Position operator -(Position p1, Position p2)
        {
            return new Position(p1.XValue - p2.XValue, p1.YValue - p2.YValue);
        }

        public static Position operator *(Position p1, Position p2)
        {
            return new Position(p1.XValue * p2.XValue, p1.YValue * p2.YValue);
        }


        public static double operator %(Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow(p1.XValue - p2.XValue, 2) + Math.Pow(p1.YValue - p2.YValue, 2));
        }

    }
}