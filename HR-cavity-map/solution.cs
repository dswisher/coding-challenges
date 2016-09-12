
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

		// Cavity search!
		for (var i = 1; i < n - 1; i++)
		{
			for (var j = 1; j < n - 1; j++)
			{
				if (IsCavity(map, i, j))
				{
					map[i,j] = 0;
				}
			}
		}

		// Print the map
		for (var i = 0; i < n; i++)
		{
			for (var j = 0; j < n; j++)
			{
				if (map[i,j] == 0)
				{
					Console.Write('X');
				}
				else
				{
					Console.Write(map[i,j]);
				}
			}
			Console.WriteLine();
		}
	}


	private static bool IsCavity(int[,] map, int i, int j)
	{
		for (var di = -1; di <= 1; di++)
		{
			for (var dj = -1; dj <= 1; dj++)
			{
				if (di == 0 && dj == 0)
				{
					continue;
				}

				if (map[i + di, j + dj] > 0 && map[i + di, j + dj] > map[i,j])
				{
					return false;
				}
			}
		}

		return true;
	}
}

