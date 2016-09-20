
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		var counts = new int[100];

		var n = int.Parse(Console.ReadLine());
		for (var i = 0; i < n; i++)
		{
			var bits = Console.ReadLine().Split(' ');
			var x = int.Parse(bits[0]);
			counts[x] += 1;
		}

		var sum = 0;
		for (var i = 0; i < 100; i++)
		{
			if (i > 0) Console.Write(" ");
			sum += counts[i];
			Console.Write(sum);
		}
		Console.WriteLine();
	}
}

