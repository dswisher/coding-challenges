
using System;
using System.Collections.Generic;

public class Solution
{
	public static void Main(string[] args)
	{
		var n = int.Parse(Console.ReadLine());
		var half = n / 2;

		var data = new List<string>[100];
		for (var i = 0; i < 100; i++)
		{
			data[i] = new List<string>();
		}

		for (var i = 0; i < n; i++)
		{
			var bits = Console.ReadLine().Split(' ');
			var x = int.Parse(bits[0]);
			var s = bits[1];

			if (i < half)
			{
				data[x].Add("-");
			}
			else
			{
				data[x].Add(s);
			}
		}
		
		var first = true;
		for (var i = 0; i < 100; i++)
		{
			foreach (var s in data[i])
			{
				if (first) first = false; else Console.Write(" ");
				Console.Write(s);
			}
		}
		Console.WriteLine();
	}
}

