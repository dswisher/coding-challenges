
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var n = int.Parse(Console.ReadLine());
		var a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		var min = int.MaxValue;
		for (var i = 0; i < n - 1; i++)
		{
			for (var j = i + 1; j < n; j++)
			{
				if ((a[i] == a[j]) && (j - i < min))
				{
					min = j - i;
				}
			}
		}

		Console.WriteLine(min == int.MaxValue ? -1 : min);
	}
}

