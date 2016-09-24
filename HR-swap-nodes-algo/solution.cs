
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution
{
	public static void Main(string[] args)
	{
		var tree = ReadTree();

		var T = int.Parse(Console.ReadLine());
		for (var i = 0; i < T; i++)
		{
			var K = int.Parse(Console.ReadLine());
			Swap(tree, K);

			var builder = new StringBuilder();
			InOrder(tree, builder);
			Console.WriteLine(builder.ToString().Trim());
		}
	}


	private static void Swap(TreeNode node, int K, int depth = 0)
	{
		if (node == null)
		{
			return;
		}

		Swap(node.Left, K, depth + 1);
		Swap(node.Right, K, depth + 1);

		if (((depth + 1) % K) == 0)
		{
			var temp = node.Left;
			node.Left = node.Right;
			node.Right = temp;
		}
	}


	private static void InOrder(TreeNode node, StringBuilder builder)
	{
		if (node == null)
		{
			return;
		}

		InOrder(node.Left, builder);
		builder.AppendFormat(" {0}", node.Data);
		InOrder(node.Right, builder);
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

