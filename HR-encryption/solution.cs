
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		string s = Console.ReadLine().Replace(" ", string.Empty);

		// Determine the number of rows and columns. We don't actually need to know the rows, though...
		var sqrt = Math.Sqrt(s.Length);
		var lb = (int)Math.Floor(sqrt); var ub = (int)Math.Ceiling(sqrt);
		var cols = lb;
		if (lb * lb < s.Length)
		{
			cols = ub;
		}

		// Print encrypted text...
		for (var i = 0; i < cols; i++)
		{
			if (i > 0) { Console.Write(' '); }
			for (var j = i; j < s.Length; j += cols) { Console.Write(s[j]); }
		}

		Console.WriteLine();
	}
}

