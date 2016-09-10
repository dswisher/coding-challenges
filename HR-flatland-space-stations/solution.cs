
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var bits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		var n = bits[0];
		// var m = bits[1];

		var c = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();

		// Edges
		var max = Math.Max(c[0], n - c[c.Length - 1] - 1);

		// Middles
		for (var i = 0; i < c.Length - 1; i++)
		{
			var dist = (c[i + 1] - c[i]) / 2;

			max = Math.Max(max, dist);
		}

		Console.WriteLine(max);
	}
}

