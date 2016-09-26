
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var tree = TreeLib.ReadTree();

		// TreeLib.Print(tree);

		Console.WriteLine(GetMinHeight(tree));
	}


	private static int GetMinHeight(TreeLib.Node node)
	{
		if (node == null) return 0;

		return 1 + Math.Min(GetMinHeight(node.Left), GetMinHeight(node.Right));
	}
}

