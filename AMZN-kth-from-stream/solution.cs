
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
		return Get(_root, 1, val);
	}


	private int Get(Node node, int leftSum, int val)
	{
		if (val == node.Data)
		{
			return leftSum + node.NumLeft;
		}
		else if (val < node.Data)
		{
			if (node.Left == null) return -1;
			return Get(node.Left, leftSum, val);
		}
		else // if (val > node.Data)
		{
			if (node.Right == null) return -1;
			return Get(node.Right, leftSum + node.NumLeft + 1, val);
		}
	}


	private void Add(Node parent, Node child)
	{
		if (child.Data < parent.Data)
		{
			parent.NumLeft += 1;
			if (parent.Left == null)
			{
				parent.Left = child;
			}
			else
			{
				Add(parent.Left, child);
			}
		}
		else if (child.Data > parent.Data)
		{
			if (parent.Right == null)
			{
				parent.Right = child;
			}
			else
			{
				Add(parent.Right, child);
			}
		}

		// TODO - how to handle equality?
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

