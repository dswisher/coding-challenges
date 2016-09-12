
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		// Load the map
		var n = int.Parse(Console.ReadLine());
		var map = new int[n,n];
		for (var i = 0; i < n; i++)
		{
			var line = Console.ReadLine();
			for (var j = 0; j < n; j++)
			{
				map[i,j] = int.Parse(line[j].ToString());
			}
		}

		for (var i = 0; i < n; i++)
		{
			for (var j = 0; j < n; j++)
			{
				var d = map[i,j];
				if (i == 0 || j == 0 || i == n - 1 || j == n - 1
					|| d <= map[i - 1, j] || d <= map[i + 1, j] || d <= map[i, j - 1] || d <= map[i, j + 1])
				{
					Console.Write(d);
				}
				else
				{
					Console.Write('X');
				}
			}
			Console.WriteLine();
		}
	}
}

