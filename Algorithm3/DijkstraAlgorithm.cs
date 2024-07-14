using System;
using System.Collections.Generic;

class DijkstraAlgorithm
{
    static int MinDistance(int[] dist, bool[] sptSet, int V)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < V; v++)
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }

        return minIndex;
    }

    static void PrintSolution(int[] dist, int V)
    {
        Console.WriteLine("Düğüm\t Uzaklık");
        for (int i = 0; i < V; i++)
            Console.WriteLine(i + "\t " + dist[i]);
    }

    static void Dijkstra(int[,] graph, int src, int V)
    {
        int[] dist = new int[V];
        bool[] sptSet = new bool[V];

        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }

        dist[src] = 0;

        for (int count = 0; count < V - 1; count++)
        {
            int u = MinDistance(dist, sptSet, V);
            sptSet[u] = true;

            for (int v = 0; v < V; v++)
                if (!sptSet[v] && Convert.ToBoolean(graph[u, v]) && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }

        PrintSolution(dist, V);
    }

    static void Main()
    {
        int[,] graph = new int[,] {
            { 0, 10, 20, 0, 0, 0 },
            { 10, 0, 0, 50, 10, 0 },
            { 20, 0, 0, 20, 33, 0 },
            { 0, 50, 20, 0, 20, 2 },
            { 0, 10, 33, 20, 0, 1 },
            { 0, 0, 0, 2, 1, 0 }
        };

        int V = 6; // Grafikteki düğüm sayısı
        int src = 0; // Başlangıç düğümü

        Dijkstra(graph, src, V);
    }
}