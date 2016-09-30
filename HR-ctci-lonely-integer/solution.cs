
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var n = int.Parse(Console.ReadLine());
		var arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();

		Console.WriteLine(FindUnique(n, arr));
	}

	private static int FindUnique(int n, int[] arr)
	{
		var result = 0;
		for (var i = 0; i < n; i += 1)
		{
			result ^= arr[i];
		}
		return result;
	}
}

