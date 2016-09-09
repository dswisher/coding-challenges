
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		var tests = int.Parse(Console.ReadLine());
		for (var t = 0; t < tests; t++)
		{
			var n = int.Parse(Console.ReadLine());
			var h = 1;
			for (var i = 1; i <= n; i++)
			{
				if ((i % 2) == 0)
				{
					h += 1;
				}
				else
				{
					h *= 2;
				}
			}
			Console.WriteLine(h);
		}
	}
}

