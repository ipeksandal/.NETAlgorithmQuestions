using System;

class Array
{
    static void Main()
    {
        Console.WriteLine("Dizinin uzunluğunu giriniz:");
        int n = int.Parse(Console.ReadLine());
        
        int[] dizi = new int[n];
        
        Console.WriteLine("Dizinin elemanlarını giriniz:");
        for (int i = 0; i < n; i++)
        {
            dizi[i] = int.Parse(Console.ReadLine());
        }

        int enKucuk = dizi[0];
        int enBuyuk = dizi[0];
        
        for (int i = 1; i < n; i++)
        {
            if (dizi[i] < enKucuk)
            {
                enKucuk = dizi[i];
            }
            if (dizi[i] > enBuyuk)
            {
                enBuyuk = dizi[i];
            }
        }

        Console.WriteLine("Dizideki en küçük eleman: " + enKucuk);
        Console.WriteLine("Dizideki en büyük eleman: " + enBuyuk);
    }
}