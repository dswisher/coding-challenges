
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var bits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		var N = bits[0];
		var K = bits[1];

		var ar = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();

		var num = 0;
		for (var i = 0; i < N; i++)
		{
			// Look forward for diff of K
			for (var j = i + 1; j < N; j++)
			{
				var diff = ar[j] - ar[i];
				if (diff == K) { num += 1; }
				if (diff >= K) { break; }
			}
		}

		Console.WriteLine(num);
	}
}

