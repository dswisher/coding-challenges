
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
	private readonly Dictionary<K,V> _map = new Dictionary<K,V>();

	public void Put(K key, V value)
	{
		// TODO!
		_map.Add(key, value);
	}


	public V Get(K key)
	{
		if (_map.Count == 0) return default(V);

		var maxKey = default(K);
		var minVal = default(V);
		var found = false;

		foreach (var pair in _map)
		{
			     // pair.Key < key                                pair.Key < minKey
			if ((pair.Key.CompareTo(key) < 0) && (!found || (pair.Key.CompareTo(maxKey) > 0)))
			{
				maxKey = pair.Key;
				minVal = pair.Value;
				found = true;
			}
		}
		
		return minVal;
	}
}

