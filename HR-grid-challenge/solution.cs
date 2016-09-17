
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var numTests = int.Parse(Console.ReadLine());
		for (var t = 0; t < numTests; t++)
		{
			var n = int.Parse(Console.ReadLine());
			var g = new char[n][];
			for (var i = 0; i < n; i++)
			{
				g[i] = Console.ReadLine().ToCharArray().OrderBy(x => x).ToArray();
			}

			Console.WriteLine(AreColumnsSorted(g, n) ? "YES" : "NO");
		}
	}


	private static bool AreColumnsSorted(char[][] g, int n)
	{
		for (var i = 1; i < n; i++)
		{
			for (var j = 0; j < n; j++)
			{
				if (g[i][j] < g[i-1][j]) return false;
			}
		}

		return true;
	}
}

