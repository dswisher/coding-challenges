
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var numCases = int.Parse(Console.ReadLine());
		for (var t = 0; t < numCases; t++)
		{
			var n = int.Parse(Console.ReadLine());
			var prices = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

			var maxPrice = int.MinValue;
			var profit = 0;
			for (var i = n - 1; i >= 0; i--)
			{
				if (prices[i] > maxPrice)
				{
					maxPrice = prices[i];
				}
				else if (prices[i] < maxPrice)
				{
					profit += maxPrice - prices[i];
				}
			}

			Console.WriteLine(profit);
		}
	}
}

