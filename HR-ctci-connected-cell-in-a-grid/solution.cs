
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var n = int.Parse(Console.ReadLine());
		var m = int.Parse(Console.ReadLine());
		var arr = new int[n,m];

		for (var i = 0; i < n; i++)
		{
			var bits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
			for (var j = 0; j < m; j++) { arr[i, j] = bits[j]; }
		}

		var largest = FindLargest(arr, n, m);

		Console.WriteLine(largest);
	}


	private static int FindLargest(int[,] arr, int n, int m)
	{
		var largest = 0;
		for (var i = 0; i < n; i++)
		{
			for (var j = 0; j < m; j++)
			{
				if (arr[i,j] == 1)
				{
					var size = TallyUp(arr, n, m, i, j);
					if (size > largest) largest = size;
				}
			}
		}

		return largest;
	}


	private static int TallyUp(int[,] arr, int n, int m, int x, int y)
	{
		if (x < 0 || y < 0 || x >= n || y >= m) return 0;
		if (arr[x,y] != 1) return 0;

		arr[x,y] = 2;

		var tally = 1;

		tally += TallyUp(arr, n, m, x - 1, y - 1);
		tally += TallyUp(arr, n, m, x - 1, y);
		tally += TallyUp(arr, n, m, x - 1, y + 1);

		tally += TallyUp(arr, n, m, x + 1, y - 1);
		tally += TallyUp(arr, n, m, x + 1, y);
		tally += TallyUp(arr, n, m, x + 1, y + 1);

		tally += TallyUp(arr, n, m, x, y - 1);
		tally += TallyUp(arr, n, m, x, y + 1);

		return tally;
	}
}

