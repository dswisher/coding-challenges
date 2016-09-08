
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var a = Console.ReadLine();
		var b = Console.ReadLine();

		Console.WriteLine(CheckPermutation(a, b) ? "yes" : "no");
	}


	private static bool CheckPermutation(string a, string b)
	{
		if (a.Length != b.Length) return false;

		// Assume ASCII: could use dictionary
		var checks = new int[256];
		for (var i = 0; i < a.Length; i++)
		{
			checks[a[i]] += 1;
			checks[b[i]] -= 1;
		}

		return !checks.Any(x => x != 0);
	}
}

