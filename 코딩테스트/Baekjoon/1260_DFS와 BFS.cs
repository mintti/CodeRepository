using System;
using System.Collections.Generic;
using static Program;

public class Program
{
    public class Node
    {
        public bool CheckedBFS { get; set; }
        public bool CheckedDFS { get; set; }
        public int Value { get; }
        public SortedList<int, Node> ConnectedNodes { get; set; }

        public Node(int value)
        {
            Value = value;
            ConnectedNodes = new SortedList<int, Node>();
        }

        public void Connect(Node node)
        {
            if(!ConnectedNodes.Values.Contains(node))
            {
                ConnectedNodes.Add(node.Value, node);
            }
        }
    }

    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var n = Convert.ToInt32(input.Split(' ')[0]);
        var m = Convert.ToInt32(input.Split(' ')[1]);
        var v = Convert.ToInt32(input.Split(' ')[2]);


        Node[] nodes = new Node[1001];
        if (nodes[v] == null) nodes[v] = new Node(v);

        // 추가
        for (int i = 0; i < m; i++)
        {
            input = Console.ReadLine();
            var first = Convert.ToInt32(input.Split(' ')[0]);
            var second = Convert.ToInt32(input.Split(' ')[1]);

            if (nodes[first] == null) nodes[first] = new Node(first);
            if (nodes[second] == null) nodes[second] = new Node(second);

            if(first != second)
            {
                nodes[first].Connect(nodes[second]);
                nodes[second].Connect(nodes[first]);
            }
        }

        // DFS
        DFS(nodes[v]);
        Console.WriteLine();

        // BFS
        BFS(nodes[v]);
    }

    static void DFS(Node curNode)
    {
        Console.Write(curNode.Value);
        curNode.CheckedDFS = true;

        foreach (var node in curNode.ConnectedNodes?.Values)
        {
            if(!node.CheckedDFS)
            {
                Console.Write($" ");
                DFS(node);
            }
        }
    }

    static void BFS(Node firstNode)
    {
       var q = new Queue<Node>();

        q.Enqueue(firstNode);
        firstNode.CheckedBFS = true;

        while (q.Count > 0)
        {
            var val = q.Dequeue();
            Console.Write($"{val.Value} ");

            foreach (var node in val.ConnectedNodes?.Values)
            {
                if(!node.CheckedBFS)
                {
                    node.CheckedBFS = true;
                    q.Enqueue(node);
                }
            }
        }
    }
}