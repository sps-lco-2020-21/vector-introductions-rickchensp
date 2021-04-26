using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEx.Lib
{
    public class Vector<T> : IEquatable<Vector<T>>
    {
        int _dimension;
        List<T> _values = new List<T> { };
        public Vector(int n, List<T> entries)
        {
            _dimension = n;
            _values = entries;
        }

        public int Dimension { get => _dimension; set => _dimension = value; }

        public List<T> Values { get => _values; }

        public double Magnitude
        {
            get
            {
                double sum = 0;
                foreach(T value in Values)
                {
                    sum += (dynamic)value * value;
                }
                return Math.Sqrt(sum);
            }

        }
        

        public bool HaveEqualDimensions(Vector<T> v2)
        {
            return Dimension == v2.Dimension;
        }

        public override string ToString()
        {
            string str = string.Empty;
            foreach(T entry in Values)
            {
                str += $"{entry}, ";
            }
            return str.Substring(0, str.Length - 2);
        }

        public Vector<T> Add(Vector<T> v2)
        {
            if (HaveEqualDimensions(v2))
            {
                List<T> newVector = new List<T> { };
                for (int i = 0; i < _dimension; ++i)
                {
                    newVector.Add((dynamic)Values[i] + v2.Values[i]);
                }
                return new Vector<T>(_dimension, newVector);
            }
            throw new VectorException(1, "Dimensions of the vectors were not equal");
        }

        public Vector<T> ScalarMultiply(T multiplier)
        {
            List<T> newValues = Values.Select(x => (T)((dynamic)x * (dynamic)multiplier)).ToList();
            return new Vector<T>(Dimension, newValues);
        }

        public double Dot(Vector<T> v2)
        {
            if (HaveEqualDimensions(v2))
            {
                double dotProduct = 0;
                for (int i = 0; i < Dimension; ++i)
                {
                    dotProduct += (dynamic)Values[i] * v2.Values[i];
                }
                return dotProduct;
            }
            throw new VectorException(1, "Dimensions of the vectors were not equal");
        }

        public double GeometricDot(Vector<T> v2)
        {
            return Magnitude * v2.Magnitude * Math.Cos(AngleBetween(v2));
        }

        public Vector<T> ConvexCombination(T a, Vector<T> v2)
        {
            T b = (dynamic)1 - a;
            Vector<T> newV1 = ScalarMultiply(a);
            Vector<T> newV2 = v2.ScalarMultiply(b);
            return newV1.Add(newV2);
        }

        public double AngleBetween(Vector<T> v2, bool UseDegree = false)
        {
            if (HaveEqualDimensions(v2))
            {
                double CosOfAngle = Dot(v2) / (Magnitude * v2.Magnitude);
                if (UseDegree)
                    return Math.Acos(CosOfAngle) * (180 / Math.PI);
                return Math.Acos(CosOfAngle);
            }
            throw new VectorException(1, "Dimensions of the Vector<T>s were not equal");
        }

        public bool Equals(Vector<T> other)
        {
            for(int i = 0; i < Dimension; ++i)
            {
                if((dynamic)Values[i] != other.Values[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

