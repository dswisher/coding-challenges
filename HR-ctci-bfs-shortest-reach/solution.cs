
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var q = int.Parse(Console.ReadLine());
		for (var i = 0; i < q; i++)
		{
			RunTest();
		}
	}


	private static void RunTest()
	{
		int n;	// num nodes
		int m;	// num edges
		ReadPair(out n, out m);

		var nodes = new Node[n];
		for (var i = 0; i < n; i++) { nodes[i] = new Node(i + 1); }

		for (var i = 0; i < m; i++)
		{
			int p, c;
			ReadPair(out p, out c);
			nodes[p - 1].Children.Add(nodes[c - 1]);
			nodes[c - 1].Children.Add(nodes[p - 1]);
		}

		var s = int.Parse(Console.ReadLine()) - 1;

		var dist = new int[n];
		for (var i = 0; i < n; i++) { dist[i] = -1; }

		DoBfs(nodes[s], dist);

		Console.WriteLine(string.Join(" ", dist.Where(x => x != 0)));
	}


	private static void DoBfs(Node start, int[] dist)
	{
		var visited = new HashSet<int>();	// ids of visited nodes
		var queue = new Queue<Node>();

		queue.Enqueue(start);
		dist[start.Id - 1] = 0;

		while (queue.Count > 0)
		{
			var node = queue.Dequeue();
			if (visited.Contains(node.Id)) continue;
			visited.Add(node.Id);
			foreach (var child in node.Children)
			{
				if (!visited.Contains(child.Id))
				{
					queue.Enqueue(child);
					var d = 6 + dist[node.Id - 1];
					if (d < dist[child.Id - 1] || dist[child.Id - 1] == -1)
					{
						dist[child.Id - 1] = d;
					}
				}
			}
		}
	}


	private static void ReadPair(out int a, out int b)
	{
		var bits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		a = bits[0];
		b = bits[1];
	}


	private class Node
	{
		private List<Node> _children = new List<Node>();

		public Node(int id)
		{
			Id = id;
		}

		public IList<Node> Children { get { return _children; } }
		public int Id { get; private set; }
	}
}

