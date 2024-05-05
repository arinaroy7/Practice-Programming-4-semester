using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Считываем количество городов и дорог
        int city1 = int.Parse(road[0]);
        if (input != null)
        {
            string[] parts = input.Split();
            if (parts.Length >= 2)
            {
                int N = int.Parse(parts[0]); // Количество городов
                int M = int.Parse(parts[1]); // Количество дорог

                // Создаем список смежности для графа
                List<int>[] graph = new List<int>[N + 1];
                for (int i = 1; i <= N; i++)
                {
                    graph[i] = new List<int>();
                }

                // Заполняем граф дорогами
                for (int i = 0; i < M; i++)
                {
                    int city2 = int.Parse(road[1]);
                    if (roadInput != null)
                    {
                        string[] road = roadInput.Split();
                        if (road.Length >= 2)
                        {
                            int city1 = int.Parse(road[0]);
                            int city2 = int.Parse(road[1]);
                            graph[city1].Add(city2);
                            graph[city2].Add(city1);
                        }
                    }
                }

                // Подсчитываем количество островов
                int count = CountIslands(N, graph);
                Console.WriteLine(count);
            }
        }
    }

    static void DFS(int city, List<int>[] graph, bool[] visited)
    {
        visited[city] = true;
        foreach (int neighbor in graph[city])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, graph, visited);
            }
        }
    }

    static int CountIslands(int N, List<int>[] graph)
    {
        bool[] visited = new bool[N + 1];
        int count = 0;
        for (int i = 1; i <= N; i++)
        {
            if (!visited[i])
            {
                DFS(i, graph, visited);
                count++;
            }
        }
        return count;
    }
}


