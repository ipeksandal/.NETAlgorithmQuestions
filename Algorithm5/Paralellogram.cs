using System;
using System.Collections.Generic;

public class Parallelogram
{
    public static void Main()
    {
        List<Point> points = new List<Point>
        {
            new Point(1, 1),
            new Point(2, 2),
            new Point(3, 4),
            new Point(5, 1),
            new Point(6, 3),
            new Point(7, 2),
            new Point(8, 5),
            new Point(9, 3)
        };

        var result = FindLargestParallelogram(points);

        if (result != null)
        {
            Console.WriteLine($"En büyük paralel kenarın köşe noktaları: " +
                              $"({result.Item1.X}, {result.Item1.Y}), " +
                              $"({result.Item2.X}, {result.Item2.Y}), " +
                              $"({result.Item3.X}, {result.Item3.Y}), " +
                              $"({result.Item4.X}, {result.Item4.Y})");

            Console.WriteLine($"Paralel kenarın alanı: {result.Item5}");
        }
        else
        {
            Console.WriteLine("Verilen nokta bulutu üzerinde paralel kenar bulunamadı.");
        }
    }

    public static Tuple<Point, Point, Point, Point, double> FindLargestParallelogram(List<Point> points)
    {
        int n = points.Count;
        if (n < 4)
            return null;

        double maxArea = 0;
        Tuple<Point, Point, Point, Point, double> maxParallelogram = null;

        // İki nokta arasındaki tüm kombinasyonları dene
        for (int i = 0; i < n - 3; i++)
        {
            for (int j = i + 1; j < n - 2; j++)
            {
                for (int k = j + 1; k < n - 1; k++)
                {
                    for (int l = k + 1; l < n; l++)
                    {
                        Point p1 = points[i];
                        Point p2 = points[j];
                        Point p3 = points[k];
                        Point p4 = points[l];

                        // p1-p2 ve p3-p4 kenarları paralel mi?
                        if (AreEdgesParallel(p1, p2, p3, p4))
                        {
                            // Paralel kenarın alanını hesapla
                            double area = CalculateParallelogramArea(p1, p2, p3, p4);

                            // Alan en büyükse güncelle
                            if (area > maxArea)
                            {
                                maxArea = area;
                                maxParallelogram = Tuple.Create(p1, p2, p3, p4, area);
                            }
                        }
                    }
                }
            }
        }

        return maxParallelogram;
    }

    // Kenarlar paralel mi kontrol et
    public static bool AreEdgesParallel(Point p1, Point p2, Point p3, Point p4)
    {
        // p1-p2 ve p3-p4 kenarları paralel mi?
        double slope1 = CalculateSlope(p1, p2);
        double slope2 = CalculateSlope(p3, p4);
        return Math.Abs(slope1 - slope2) < 0.0001; // Küçük bir tolerans ile kontrol ediyoruz
    }

    // Eğimi hesapla
    public static double CalculateSlope(Point p1, Point p2)
    {
        if (p2.X - p1.X == 0)
            return double.MaxValue; // Dikey doğru, sonsuz eğim
        return (double)(p2.Y - p1.Y) / (p2.X - p1.X);
    }

    // Paralel kenarın alanını hesapla (Shoelace formülü kullanarak)
    public static double CalculateParallelogramArea(Point p1, Point p2, Point p3, Point p4)
    {
        // p1, p2, p3, p4 noktalarının Shoelace formülü ile alanını hesapla
        double area = Math.Abs(0.5 * (
            p1.X * p2.Y + p2.X * p3.Y + p3.X * p4.Y + p4.X * p1.Y -
            p2.X * p1.Y - p3.X * p2.Y - p4.X * p3.Y - p1.X * p4.Y));
        return area;
    }

    // Nokta sınıfı tanımı
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
