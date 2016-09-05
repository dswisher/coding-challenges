
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		var counts1 = GetCounts(Console.ReadLine());
		var counts2 = GetCounts(Console.ReadLine());

		var removals = 0;
		for (var i = 0; i < 26; i++)
		{
			removals += Math.Abs(counts1[i] - counts2[i]);
		}

		Console.WriteLine(removals);
	}


	private static int[] GetCounts(string s)
	{
		var counts = new int[26];

		foreach (var c in s)
		{
			counts[c - 'a'] += 1;
		}

		return counts;
	}
}

