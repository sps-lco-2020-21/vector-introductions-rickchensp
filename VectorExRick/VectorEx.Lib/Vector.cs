using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEx.Lib
{
    public class Vector
    {
        int _dimension;
        List<double> _values = new List<double> { };
        public Vector(int n, List<double> entries)
        {
            _dimension = n;
            _values = entries;
        }

        public int Dimension { get => _dimension; set => _dimension = value; }

        public List<double> Values { get => _values; }

        public double Magnitude { get => Values.Sum(x => x * x); }

        public bool HaveEqualDimensions(Vector v2)
        {
            return Dimension == v2.Dimension;
        }

        public override string ToString()
        {
            string str = string.Empty;
            foreach(double entry in Values)
            {
                str += $"{entry}, ";
            }
            return str.Substring(0, str.Length - 2);
        }

        public Vector Add(Vector v2)
        {
            if (HaveEqualDimensions(v2))
            {
                List<double> newVector = new List<double> { };
                for (int i = 0; i < _dimension; ++i)
                {
                    newVector.Add(Values[i] + v2.Values[i]);
                }
                return new Vector(_dimension, newVector);
            }
            throw new Exception();
        }

        public Vector ScalarMultiply(double multiplier)
        {
            List<double> newValues = Values.Select(x => x * multiplier).ToList();
            return new Vector(Dimension, Values);
        }

        public double Dot(Vector v2)
        {
            if (HaveEqualDimensions(v2))
            {
                double dotProduct = 1;
                for (int i = 0; i < Dimension; ++i)
                {
                    dotProduct += Values[i] * v2.Values[i];
                }
                return dotProduct;
            }
            throw new Exception();
        }

        public double GeometricDot(Vector v2)
        {
            return Magnitude * v2.Magnitude * Math.Cos(AngleBetween(v2));
        }

        public Vector ConvexCombination(double a, Vector v2)
        {
            double b = 1 - a;
            Vector newV1 = this.ScalarMultiply(a);
            Vector newV2 = v2.ScalarMultiply(b);
            return newV1.Add(newV2);
        }

        public double AngleBetween(Vector v2, bool UseDegree = false)
        {
            if (HaveEqualDimensions(v2))
            {
                double CosOfAngle = Dot(v2) / (Magnitude * v2.Magnitude);
                if (UseDegree)
                    return Math.Acos(CosOfAngle) * (180 / Math.PI);
                return Math.Acos(CosOfAngle);
            }
            throw new Exception();
        }

    }
}

