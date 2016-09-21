
using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
	public static void Main(string[] args)
	{
		var n = int.Parse(Console.ReadLine());
		var half = n / 2;

		var data = new List<string>[100];
		var empt = new int[100];
		for (var i = 0; i < 100; i++) { data[i] = new List<string>(); }

		for (var i = 0; i < n; i++)
		{
			var bits = Console.ReadLine().Split(' ');
			var x = int.Parse(bits[0]);
			var s = bits[1];

			if (i < half) { empt[x] += 1; }
			else { data[x].Add(s); }
		}

		// Turns out: building the string and then writing it out en masse is faster that writing it piecemeal
		var builder = new StringBuilder();
		var first = true;
		for (var i = 0; i < 100; i++)
		{
			for (var j = 0; j < empt[i]; j++)
			{
				if (first) first = false; else builder.Append(" ");
				builder.Append("-");
			}

			foreach (var s in data[i])
			{
				if (first) first = false; else builder.Append(" ");
				builder.Append(s);
			}
		}
		Console.WriteLine(builder.ToString());
	}
}

