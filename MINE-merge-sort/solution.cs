
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var list = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

		list = Sort(list);

		Console.WriteLine(string.Join(" ", list));
	}


	private static List<int> Sort(List<int> list)
	{
		// Base case
		if (list.Count == 1) return list;

		// Divide in half and sort each piece
		var left = new List<int>();
		var right = new List<int>();
		foreach (var item in list.Select((x,i) => new { x, i }))
		{
			if ((item.i % 2) == 0)
			{
				left.Add(item.x);
			}
			else
			{
				right.Add(item.x);
			}
		}

		// Sort each piece
		left = Sort(left);
		right = Sort(right);

		// Merge back together and return result
		return Merge(left, right);
	}


	private static List<int> Merge(List<int> left, List<int> right)
	{
		var result = new List<int>();
		var l = 0;
		var r = 0;

		while (l < left.Count && r < right.Count)
		{
			if (left[l] < right[r])
			{
				result.Add(left[l]);
				l += 1;
			}
			else
			{
				result.Add(right[r]);
				r += 1;
			}
		}

		while (l < left.Count)
		{
			result.Add(left[l]);
			l += 1;
		}

		while (r < right.Count)
		{
			result.Add(right[r]);
			r += 1;
		}

		return result;
	}
}

