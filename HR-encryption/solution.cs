
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		string s = Console.ReadLine().Replace(" ", string.Empty);

		// Determine the number of rows and columns (L = s.Length):
		var sqrt = Math.Sqrt(s.Length);
		var lb = (int)Math.Floor(sqrt); var ub = (int)Math.Ceiling(sqrt);
		var rows = lb;
		var cols = lb;
		if (lb * lb < s.Length)
		{
			if ((lb * ub) >= s.Length) { cols = ub; }
			else { rows = ub; cols = ub; }
		}

		// Print the encryption
		for (var i = 0; i < cols; i++)
		{
			if (i > 0) { Console.Write(' '); }
			for (var j = i; j < s.Length; j += cols) { Console.Write(s[j]); }
		}

		Console.WriteLine();
	}
}

