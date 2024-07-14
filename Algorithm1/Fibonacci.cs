using System;

class Fibonacci
{
    static void Main()
    {
        Console.WriteLine("Fibonacci dizisinin kaç terimini hesaplamak istiyorsunuz?");
        int n = int.Parse(Console.ReadLine());

        int[] fibonacci = new int[n];
        
        if (n >= 1) fibonacci[0] = 0;
        if (n >= 2) fibonacci[1] = 1;

        for (int i = 2; i < n; i++)
        {
            fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
        }

        Console.WriteLine("Fibonacci dizisinin ilk " + n + " terimi:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(fibonacci[i] + " ");
        }
    }
}