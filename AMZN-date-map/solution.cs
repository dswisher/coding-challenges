
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var map = new TreeMap<DateTime, string>();

		// Input: lines of the following form
		// 	P <date> <val>
		//  G <date>
		// where
		//  a 'P' line puts a new value into the map
		//  a 'G' line gets an existing value out of the map and print it
		string line;
		while ((line = Console.ReadLine()) != null)
		{
			var bits = line.Split(' ');
			var command = bits[0].Trim();
			var date = DateTime.Parse(bits[1]);
			switch (command)
			{
				case "P":
					map.Put(date, bits[2]);
					break;

				case "G":
					var result = map.Get(date);
					Console.WriteLine(result == null ? "nil" : result);
					break;
			}
		}
	}
}


public class TreeMap<K,V> where K : IComparable<K>
{
	private Node _root;


	public void Put(K key, V value)
	{
		var node = new Node { Key = key, Value = value };

		if (_root == null)
		{
			_root = node;
		}
		else
		{
			Add(_root, node);
		}
	}


	private void Add(Node parent, Node child)
	{
		if (parent.Key.Equals(child.Key))
		{
			throw new Exception("Duplicate key.");	// TODO - better exception
		}

		if (parent.Key.CompareTo(child.Key) < 0)
		{
			// Add to left
			if (parent.Left == null)
			{
				parent.Left = child;
			}
			else
			{
				Add(parent.Left, child);
			}
		}
		else
		{
			// Add to right
			if (parent.Right == null)
			{
				parent.Right = child;
			}
			else
			{
				Add(parent.Right, child);
			}
		}
	}


	public V Get(K key)
	{
		return Get(_root, key);
	}


	private V Get(Node parent, K key)
	{
		if (parent == null) { return default(V); }
		if (parent.Key.Equals(key)) { return parent.Value; }

		if (parent.Key.CompareTo(key) < 0)
		{
			return Get(parent.Left, key);
		}
		else
		{
			return Get(parent.Right, key);
		}
	}


	private class Node
	{
		public K Key { get; set; }
		public V Value { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
	}
}

