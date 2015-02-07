using System;
using System.Collections.Generic;

namespace PolygonCalc
{

    public class Verticle
    {
        public double x { get; set; }
        public double y { get; set; }

        public Verticle(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Polygon
    {
        public Verticle[] v;

        public Polygon(List<Verticle> vList)
        {
            v = new Verticle[vList.Count];
            vList.CopyTo(v);
        }
        
        public double calculateArea()
        {
            int n = v.Length;

            double matrix = 0D; // assign the type and set matrix to (type)0

            for (int i = 0; i < n; i++)
                matrix += (i != n-1) ? v[i].x * v[i + 1].y - v[i + 1].x * v[i].y : v[i].x * v[0].y - v[0].x * v[i].y;

            return 0.5D * matrix;
        }
        
    }

    class Program
    {
        static T ReadLine<T>()
        {
            String r = Console.ReadLine();
            T ret = default(T);

            try
            {
                ret = (T)Convert.ChangeType(r, typeof(T));  
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Nie można przekonwertować typu String na {0}", typeof(T));
            }
            catch (FormatException)
            {
                Console.WriteLine("Podano zły format, podaj format dla typu {0}", typeof(T));
            }
            catch (OverflowException)
            {
                Console.WriteLine("Liczba jest zbyt duża dla formatu {0}", typeof(T));
            }

            return ret;
        }

        static void Main(string[] args)
        {
            List<Verticle> verticles = new List<Verticle>();
            
            Console.WriteLine("========= Polygonminator 2015 =========");
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Podaj punkty");
            Console.WriteLine("2. Oblicz utworzony polygon");
            Console.WriteLine("3. Wyjscie");

            var choose = ReadLine<int>();

            if (choose==1)
            {
                Polygon p;
                Console.Clear();
                Console.WriteLine("Podaj liczbe wierzchołków");
                var n = ReadLine<int>();

                for(int v=0; v<n; v++)
                {
                    Console.WriteLine("Podaj wierzchołek: {0}", v + 1);
                    Console.WriteLine("X: ");
                    var x = ReadLine<double>();

                    Console.WriteLine("Y: ");
                    var y = ReadLine<double>();

                    verticles.Add(new Verticle(x, y));
                }

                Console.Clear();

                p = new Polygon(verticles);
                Console.WriteLine("Pole figury wynosi: {0}", p.calculateArea());
            }

            Console.ReadKey();
        }
    }
}
