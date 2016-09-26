
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var trips = int.Parse(Console.ReadLine());
		for (var t = 0; t < trips; t++)
		{
			var bits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
			var n = bits[0];
			var c = bits[1];
			var m = bits[2];

			var wrappers = 0;
			var total = 0;
			while (n >= c || wrappers >= m)
			{
				var buy = n / c;
				wrappers += buy;
				n -= buy * c;
				total += buy;

				var trade = wrappers / m;
				wrappers -= (trade * m);
				wrappers += trade;
				total += trade;
			}

			Console.WriteLine(total);
		}
	}
}

