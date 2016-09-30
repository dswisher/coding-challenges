
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		var map = new TreeMap();

		// Input: lines of the following form
		// 	A <val>
		//  G <val>
		// where
		//  a 'A' line puts a new value into the map
		//  a 'G' line prints the position of the item with the specified value
		string line;
		while ((line = Console.ReadLine()) != null)
		{
			var bits = line.Split(' ');
			var command = bits[0].Trim();
			var val = int.Parse(bits[1]);
			switch (command)
			{
				case "A":
					map.Add(val);
					break;

				case "G":
					var result = map.Get(val);
					Console.WriteLine(result);
					break;
			}
		}
	}
}


public class TreeMap
{
	private Node _root;

	public void Add(int val)
	{
		var node = new Node { Data = val };

		if (_root == null)
		{
			_root = node;
		}
		else
		{
			Add(_root, node);
		}
	}


	public int Get(int val)
	{
		// TODO
		return -1;
	}


	private void Add(Node parent, Node child)
	{
		// TODO
	}


	private class Node
	{
		public int Data { get; set; }
		public int NumLeft { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
	}
}


public class ListMap
{
	public List<int> _list = new List<int>();

	public void Add(int val)
	{
		// TODO
		_list.Add(val);
		_list.Sort();
	}


	public int Get(int val)
	{
		// TODO
		for (var i = 0; i < _list.Count; i++)
		{
			if (_list[i] == val)
			{
				return i + 1;
			}
		}

		return -1;
	}
}

