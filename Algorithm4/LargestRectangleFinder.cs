using System;
using System.Collections.Generic;

public class LargestRectangleFinder
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

        var result = FindLargestRectangle(points);

        if (result != null)
        {
            Console.WriteLine($"En büyük dikdörtgenin köşe noktaları: " +
                              $"({result.Item1.X}, {result.Item1.Y}), " +
                              $"({result.Item2.X}, {result.Item2.Y}), " +
                              $"({result.Item3.X}, {result.Item3.Y}), " +
                              $"({result.Item4.X}, {result.Item4.Y})");

            Console.WriteLine($"Dikdörtgenin alanı: {result.Item5}");
        }
        else
        {
            Console.WriteLine("Verilen nokta bulutu üzerinde dikdörtgen bulunamadı.");
        }
    }

    public static Tuple<Point, Point, Point, Point, double> FindLargestRectangle(List<Point> points)
    {
        int n = points.Count;
        if (n < 3)
            return null;

        double maxArea = 0;
        Tuple<Point, Point, Point, Point, double> maxRectangle = null;

        // İki nokta arasındaki tüm kombinasyonları dene
        for (int i = 0; i < n - 2; i++)
        {
            for (int j = i + 1; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    Point p1 = points[i];
                    Point p2 = points[j];
                    Point p3 = points[k];

                    // p1 ve p2 noktaları bir kenarı oluşturacak şekilde dikdörtgeni oluştur
                    if (IsRectanglePossible(p1, p2, p3))
                    {
                        // p4'ü belirle
                        Point p4 = FindFourthPoint(p1, p2, p3, points);

                        // Dikdörtgenin alanını hesapla
                        double area = CalculateRectangleArea(p1, p2, p3, p4);

                        // Alan en büyükse güncelle
                        if (area > maxArea)
                        {
                            maxArea = area;
                            maxRectangle = Tuple.Create(p1, p2, p3, p4, area);
                        }
                    }
                }
            }
        }

        return maxRectangle;
    }

    // Dikdörtgen oluşturulabilir mi kontrol et
    public static bool IsRectanglePossible(Point p1, Point p2, Point p3)
    {
        // Herhangi üç nokta doğru bir dikdörtgen yapar mı?
        // İki vektörün iç çarpımı 0'a eşitse, dikdörtgen oluşturulabilir.
        double dotProduct = (p2.X - p1.X) * (p3.X - p2.X) + (p2.Y - p1.Y) * (p3.Y - p2.Y);
        return dotProduct == 0;
    }

    // Dördüncü noktayı bul
    public static Point FindFourthPoint(Point p1, Point p2, Point p3, List<Point> points)
    {
        foreach (var point in points)
        {
            if (point != p1 && point != p2 && point != p3)
                return point;
        }
        return null;
    }

    // Dikdörtgenin alanını hesapla (Shoelace formülü kullanarak)
    public static double CalculateRectangleArea(Point p1, Point p2, Point p3, Point p4)
    {
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
