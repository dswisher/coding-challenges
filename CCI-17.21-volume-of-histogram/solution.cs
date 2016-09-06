
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var heights = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		var n = heights.Length;
		var lefts = new int[n];
		var rights = new int[n];

		lefts[0] = heights[0];
		for (var i = 1; i < n; i++) { lefts[i] = Math.Max(lefts[i - 1], heights[i]); }

		rights[n - 1] = heights[n - 1];
		for (var i = n - 2; i >= 0; i--) { rights[i] = Math.Max(rights[i + 1], heights[i]); }

		var volume = 0;
		for (var i = 0; i < n; i++)
		{
			volume += Math.Min(lefts[i], rights[i]) - heights[i];
		}

		// Console.WriteLine("Heights: {0}", string.Join(", ", heights));
		// Console.WriteLine("Lefts:   {0}", string.Join(", ", lefts));
		// Console.WriteLine("Rights:  {0}", string.Join(", ", rights));
		Console.WriteLine(volume);
	}
}

