
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var numTests = int.Parse(Console.ReadLine());
		for (var t = 0; t < numTests; t++)
		{
			var bits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
			var N = bits[0];
			var M = bits[1];
			var S = bits[2] - 1;	// zero-based indexing

			var extras = M % (N + 1);
			var prisoner = (S + extras) % N;

			Console.WriteLine(prisoner + 1);
		}
	}
}

