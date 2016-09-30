
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		var trie = new PrefixTrie();

		var n = int.Parse(Console.ReadLine());
		for (var i = 0; i < n; i++)
		{
			var bits = Console.ReadLine().Split(' ');
			var operation = bits[0];
			var word = bits[1];

			switch (operation)
			{
				case "add":
					trie.Add(word);
					break;

				case "find":
					Console.WriteLine(trie.GetCount(word));
					break;
			}
		}

		// trie.Dump();
	}
}



public class PrefixTrie
{
	private readonly Node _root = new Node();

	public void Add(string word)
	{
		// NOTE: Because strings are immutable, it would be better to pass a pos instead of using substring,
		// but I think the code looks cleaner this way, and the perf hit won't be too bad.
		Add(_root, word);
	}


	public int GetCount(string prefix)
	{
		return GetCount(_root, prefix);
	}


	private void Add(Node node, string word)
	{
		node.Descendants += 1;

		if (word.Length == 0)
		{
			return;
		}

		var c = word[0];
		var child = node.DescribeChild(c);

		Add(child, word.Substring(1));
	}


	private int GetCount(Node node, string prefix)
	{
		if (prefix.Length == 0) { return node.Descendants; }

		var c = prefix[0];
		var child = node.GetChild(c);

		if (child == null) { return 0; }

		return GetCount(child, prefix.Substring(1));
	}


	public void Dump()
	{
		var queue = new Queue<Entry>();
		queue.Enqueue(new Entry { Node = _root, Prefix = string.Empty });

		Console.WriteLine("|---");

		while (queue.Count > 0)
		{
			var entry = queue.Dequeue();
			Console.WriteLine("| {0,3}: \"{1}\", count={2}", entry.Node.Id, entry.Prefix, entry.Node.Descendants);
			for (var i = 0; i < 26; i++)
			{
				var c = (char)((int)'a' + i);
				var child = entry.Node.GetChild(c);
				if (child != null)
				{
					Console.WriteLine("|     {0} -> {1}", c, child.Id);
					queue.Enqueue(new Entry { Node = child, Prefix = entry.Prefix + c });
				}
			}
		}
	}


	// Used by Dump()
	private class Entry
	{
		public Node Node { get; set; }
		public string Prefix { get; set; }
	}


	private class Node
	{
		private static int _nextId = 1;

		private readonly Node[] _children = new Node[26];
		public int Descendants { get; set; }
		public int Id { get; private set; }

		public Node()
		{
			Id = _nextId;
			_nextId += 1;
		}

		public Node GetChild(char c)
		{
			return _children[GetIndex(c)];
		}

		public Node DescribeChild(char c)
		{
			var idx = GetIndex(c);
			if (_children[idx] == null)
			{
				_children[idx] = new Node();
			}
			return _children[idx];
		}

		private int GetIndex(char c)
		{
			return (int)(c - 'a');
		}
	}
}

