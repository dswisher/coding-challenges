
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var line1 = Console.ReadLine().Split(' ');
		var n = int.Parse(line1[0]);
		var k = int.Parse(line1[1]);

		var costs = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		var bCharged = int.Parse(Console.ReadLine());

		var aAte = 0;
		for (var i = 0; i < n; i++)
		{
			if (i != k) aAte += costs[i];
		}

		var aShare = aAte / 2;

		if (aShare == bCharged)
		{
			Console.WriteLine("Bon Appetit");
		}
		else
		{
			Console.WriteLine(bCharged - aShare);
		}
	}
}

