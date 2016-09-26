
using System;
using System.Collections.Generic;
using System.Linq;

public static class TreeLib
{
    public static Node ReadTree()
    {
        var numNodes = int.Parse(Console.ReadLine());
        var nodeList = new List<Node>();
        var root = new Node { Data = 1 };
        nodeList.Add(root);
        for (var n = 0; n < numNodes; n++)
        {
            var kids = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            if (kids[0] != -1)
            {
                var child = new Node { Data = kids[0] };
                nodeList[n].Left = child;
                child.Parent = nodeList[n];
                nodeList.Add(child);
            }

            if (kids[1] != -1)
            {
                var child = new Node { Data = kids[1] };
                nodeList[n].Right = child;
                child.Parent = nodeList[n];
                nodeList.Add(child);
            }
        }
        return root;
    }



    public static void Print(Node node, int depth = 0)
    {
        if (node.Right != null)
        {
            Print(node.Right, depth + 1);
        }

        Console.WriteLine("| {0} {1}", new String(' ', depth * 3), node.Data);

        if (node.Left != null)
        {
            Print(node.Left, depth + 1);
        }
    }




    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
        public int Data { get; set; }
    }
}

