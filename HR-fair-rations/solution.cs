
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var N = int.Parse(Console.ReadLine());
		var b = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		if (b.Sum() % 2 == 1)
		{
			Console.WriteLine("NO");
		}
		else
		{
			var count = 0;
			for (var i = 0; i < N - 1; i++)
			{
				if (b[i] % 2 == 1)
				{
					b[i] += 1;
					b[i+1] += 1;
					count += 2;
				}
			}
			Console.WriteLine(count);
		}
	}
}

