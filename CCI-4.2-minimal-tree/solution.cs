
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var nums = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();

		var root = MakeTree(nums, 0, nums.Length - 1);

		Console.WriteLine(Height(root));
	}


	private static Node MakeTree(int[] nums, int lo, int hi)
	{
		if (lo > hi) { return null; }

		var idx = lo + (hi - lo) / 2;
		var node = new Node { Data = nums[idx] };

		node.Left = MakeTree(nums, lo, idx - 1);
		node.Right = MakeTree(nums, idx + 1, hi);

		return node;
	}


	private static int Height(Node node)
	{
		if (node == null) { return 0; }

		return 1 + Math.Max(Height(node.Left), Height(node.Right));
	}


	public class Node
	{
		public Node Left { get; set; }
		public Node Right { get; set; }
		public int Data { get; set; }
	}
}

