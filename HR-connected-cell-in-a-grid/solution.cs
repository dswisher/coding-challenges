
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var rows = int.Parse(Console.ReadLine());
		var cols = int.Parse(Console.ReadLine());
		var cells = new int[rows, cols];

		for (var r = 0; r < rows; r++)
		{
			var rawRow = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
			for (var c = 0; c < cols; c++)
			{
				cells[r, c] = rawRow[c];
			}
		}

		var regions = FindRegions(cells);

		Console.WriteLine(regions.Max());
	}


	private static List<int> FindRegions(int[,] cells)
	{
		var regions = new List<int>();

		for (var r = 0; r < cells.GetLength(0); r++)
		{
			for (var c = 0; c < cells.GetLength(1); c++)
			{
				if (cells[r, c] == 1)
				{
					regions.Add(RegionSize(cells, r, c));
				}
			}
		}

		return regions;
	}


	private static int RegionSize(int[,] cells, int r, int c)
	{
		if (r < 0 || c < 0 || r > cells.GetLength(0) - 1 || c > cells.GetLength(1) - 1) return 0;
		if (cells[r, c] != 1) return 0;

		cells[r, c] = 8;	// mark as visited

		var size = 1;
		for (var i = -1; i <= 1; i++)
		{
			for (var j = -1; j <= 1; j++)
			{
				size += RegionSize(cells, r + i, c + j);
			}
		}

		return size;
	}
}

