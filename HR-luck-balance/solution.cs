
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var bits = Console.ReadLine().Split(' ');
		var N = int.Parse(bits[0]);
		var K = int.Parse(bits[1]);

		var important = new List<int>();
		var luck = 0;
		for (var i = 0; i < N; i++)
		{
			bits = Console.ReadLine().Split(' ');
			var Li = int.Parse(bits[0]);
			var Ti = int.Parse(bits[1]);

			if (Ti == 1)
			{
				important.Add(Li);
			}
			else
			{
				luck += Li;
			}
		}

		important.Sort();

		var wins = important.Take(important.Count - K).Sum();
		var losses = important.Skip(important.Count - K).Sum();

		luck = luck + losses - wins;

		Console.WriteLine(luck);
	}
}

