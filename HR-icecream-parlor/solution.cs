
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var trips = int.Parse(Console.ReadLine());

		for (var t = 0; t < trips; t++)
		{
			var m = int.Parse(Console.ReadLine());
			var n = int.Parse(Console.ReadLine());
			var costs = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

			bool found = false;
			for (var i = 0; (i < n) && !found; i++)
			{
				for (var j = i + 1; (j < n) && !found; j++)
				{
					if (costs[i] + costs[j] == m)
					{
						Console.WriteLine("{0} {1}", i + 1, j + 1);
						found = true;
					}
				}
			}
		}
	}
}

