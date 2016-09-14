
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var line1 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		// var freewayLen = line1[0];		// aka N, 2 <= N <= 100000
		var numTests = line1[1];		// aka T, 1 <= T <= 1000

		var widths = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		for (var t = 0; t < numTests; t++)
		{
			var tline = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
			var enter = tline[0];	// aka i
			var exit = tline[1];	// aka j

			var min = 3;
			for (var i = enter; i <= exit; i++)
			{
				if (widths[i] < min) { min = widths[i]; }
			}
			Console.WriteLine(min);
		}
	}
}

