using System;
using System.Collections.Generic;
using System.Linq;
/*class Program
{
    static void Main()
    {
        int N, M;
        string[] input = Console.ReadLine().Split();
        N = int.Parse(input[0]);
        M = int.Parse(input[1]);

        //Создаем список смежности для хранения графа
        List<int>[] adjList = new List<int>[N];
        for (int i = 0; i < N; i++)
            adjList[i] = new List<int>();

        for (int i = 0; i < M; i++)
        {
            input = Console.ReadLine().Split();
            if(input.Length != 2) // Проверяем, что в строке есть два элемента
            {
                Console.WriteLine("Неверный формат ввода");
                return;
            }
            int city1, city2;
            if (!int.TryParse(input[0], out city1) || !int.TryParse(input[1], out city2)) // Проверяем, что оба элемента являются числами
            {
                Console.WriteLine("Неверный формат ввода");
                return;
            }
            city1--; //города нумеруются с 1, поэтому вычитаем 1
            city2--;
            adjList[city1].Add(city2);
            adjList[city2].Add(city1);
        }

        //Массив для отслеживания посещенных городов
        bool[] visited = new bool[N];
        int count = 0;

        //Обходим все города и запускаем обход в глубину для каждого непосещенного города
        for (int i = 0; i < N; i++)
        {
            if (!visited[i])
            {
                DFS(i, adjList, visited);
                count++;
            }
        }

        //Выводим количество изолированных областей
        Console.WriteLine(count);
    }

    //Обход в глубину для поиска связанных городов
    static void DFS(int v, List<int>[] adjList, bool[] visited)
    {
        visited[v] = true;
        foreach (int u in adjList[v])
        {
            if (!visited[u])
                DFS(u, adjList, visited);
        }
    }
}


class Program
{
    public static List<List<Node>> FindConnectedComponents(Graph graph)
    {
        var result = new List<List<Node>>();
        var markedNodes = new HashSet<Node>();
        while (true)
        {
            var nextNode = graph.Nodes.FirstOrDefault(node => !markedNodes.Contains(node));
            if (nextNode == null) break;
            var breadthSearch = nextNode.BreadthSearch().ToList();
            result.Add(breadthSearch);
            foreach (var node in breadthSearch)
                markedNodes.Add(node);
        }
        return result;
    }
 
    public static void Main()
    {
        var graph = Graph.MakeGraph(
            1, 2,
            3, 4,
            4, 5,
            5, 3);
 
        var connected = FindConnectedComponents(graph);
        Console.WriteLine(
            connected
                .Select(component => component.Select(node => node.NodeNumber.ToString()).Aggregate((a, b) => a + " " + b))
                .Aggregate((a, b) => a + "\n" + b));
    }
}

class Node
{
    public int NodeNumber { get; }
    public List<Node> AdjacentNodes { get; } = new List<Node>();
 
    public Node(int number)
    {
        NodeNumber = number;
    }
 
    public void AddEdgeTo(Node node)
    {
        AdjacentNodes.Add(node);
        node.AdjacentNodes.Add(this);
    }
 
    public IEnumerable<Node> BreadthSearch()
    {
        var visited = new HashSet<Node>();
        var queue = new Queue<Node>();
        queue.Enqueue(this);
        visited.Add(this);
 
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            yield return current;
 
            foreach (var node in current.AdjacentNodes)
            {
                if (!visited.Contains(node))
                {
                    queue.Enqueue(node);
                    visited.Add(node);
                }
            }
        }
    }
}

class Graph
{
    public List<Node> Nodes { get; } = new List<Node>();
 
    public void AddEdge(int from, int to)
    {
        var fromNode = Nodes.FirstOrDefault(node => node.NodeNumber == from);
        var toNode = Nodes.FirstOrDefault(node => node.NodeNumber == to);
        if (fromNode == null)
        {
            fromNode = new Node(from);
            Nodes.Add(fromNode);
        }
        if (toNode == null)
        {
            toNode = new Node(to);
            Nodes.Add(toNode);
        }
        fromNode.AddEdgeTo(toNode);
    }
 
    public static Graph MakeGraph(params int[] edges)
    {
        var graph = new Graph();
        for (int i = 0; i < edges.Length; i += 2)
            graph.AddEdge(edges[i], edges[i + 1]);
        return graph;
    }
}*/

class Program
{
    public class Solution
    {
        public static int FindIsolatedRegions(Graph graph)
        {
            var connected = FindConnectedComponents(graph);
            return connected.Count;
        }

        public static List<List<Node>> FindConnectedComponents(Graph graph)
        {
            var result = new List<List<Node>>();
            var markedNodes = new HashSet<Node>();
            while (true)
            {
                var nextNode = graph.Nodes.FirstOrDefault(node => !markedNodes.Contains(node));
                if (nextNode == null) break;
                var breadthSearch = nextNode.BreadthSearch().ToList();
                result.Add(breadthSearch);
                foreach (var node in breadthSearch)
                    markedNodes.Add(node);
            }
            return result;
        }
    }

    public static void Main()
    {
        var graph = Graph.MakeGraph(
            1, 2,
            2, 3,
            3, 5);

        var isolatedRegions = Solution.FindIsolatedRegions(graph);
        Console.WriteLine(isolatedRegions);
    }
}

class Node
{
    public int NodeNumber { get; }
    public List<Node> AdjacentNodes { get; } = new List<Node>();

    public Node(int number)
    {
        NodeNumber = number;
    }

    public void AddEdgeTo(Node node)
    {
        AdjacentNodes.Add(node);
        node.AdjacentNodes.Add(this);
    }

    public IEnumerable<Node> BreadthSearch()
    {
        var visited = new HashSet<Node>();
        var queue = new Queue<Node>();
        queue.Enqueue(this);
        visited.Add(this);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            yield return current;

            foreach (var node in current.AdjacentNodes)
            {
                if (!visited.Contains(node))
                {
                    queue.Enqueue(node);
                    visited.Add(node);
                }
            }
        }
    }
}

class Graph
{
    public List<Node> Nodes { get; } = new List<Node>();

    public void AddEdge(int from, int to)
    {
        var fromNode = Nodes.FirstOrDefault(node => node.NodeNumber == from);
        var toNode = Nodes.FirstOrDefault(node => node.NodeNumber == to);
        if (fromNode == null)
        {
            fromNode = new Node(from);
            Nodes.Add(fromNode);
        }
        if (toNode == null)
        {
            toNode = new Node(to);
            Nodes.Add(toNode);
        }
        fromNode.AddEdgeTo(toNode);
    }

    public static Graph MakeGraph(params int[] edges)
    {
        var graph = new Graph();
        for (int i = 0; i < edges.Length; i += 2)
            graph.AddEdge(edges[i], edges[i + 1]);
        return graph;
    }
}
