
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var tree = ReadTree();

		// Print(tree);

		Console.WriteLine(GetMinHeight(tree));
	}


	private static int GetMinHeight(TreeNode node)
	{
		if (node == null) return 0;

		return 1 + Math.Min(GetMinHeight(node.Left), GetMinHeight(node.Right));
	}


    private static TreeNode ReadTree()
    {
        var numNodes = int.Parse(Console.ReadLine());
        var nodeList = new List<TreeNode>();
        var root = new TreeNode { Data = 1 };
        nodeList.Add(root);
        for (var n = 0; n < numNodes; n++)
        {
            var kids = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            if (kids[0] != -1)
            {
                var child = new TreeNode { Data = kids[0] };
                nodeList[n].Left = child;
                child.Parent = nodeList[n];
                nodeList.Add(child);
            }

            if (kids[1] != -1)
            {
                var child = new TreeNode { Data = kids[1] };
                nodeList[n].Right = child;
                child.Parent = nodeList[n];
                nodeList.Add(child);
            }
        }
        return root;
    }


    private static void Print(TreeNode node, int depth = 0)
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



    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Parent { get; set; }
        public int Data { get; set; }
    }
}

