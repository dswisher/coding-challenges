
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var s = Console.ReadLine();
		var n = long.Parse(Console.ReadLine());

		// Calculate how many "whole" strings go into n
		var wholes = n / s.Length;

		// Calculate how much of the prefix we'll need to tack on to complete
		var prefix = (int)(n % s.Length);

		// Count the parts
		var numWholes = s.Where(x => x == 'a').Count() * wholes;
		var numPrefs = s.Substring(0, prefix).Where(x => x == 'a').Count();

		// Print the result
		Console.WriteLine(numWholes + numPrefs);
	}
}

