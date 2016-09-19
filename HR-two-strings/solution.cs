
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		var numPairs = int.Parse(Console.ReadLine());
		for (var p = 0; p < numPairs; p++)
		{
			var a = Console.ReadLine();
			var b = Console.ReadLine();

			Console.WriteLine(ShareSubset(a, b) ? "YES" : "NO");
		}
	}


	private static bool ShareSubset(string a, string b)
	{
		var chars = new HashSet<char>();
		foreach (var c in a)
		{
			chars.Add(c);
		}

		foreach (var c in b)
		{
			if (chars.Contains(c))
			{
				return true;
			}
		}

		return false;
	}
}

