
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var n = int.Parse(Console.ReadLine());
		var c = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
		
		var num = 0;
		var i = 0;
		while (i < n - 1)
		{
			if (c[i] == c[i+1])
			{
				num += 1;
				i += 2;
			}
			else
			{
				i += 1;
			}
		}

		Console.WriteLine(num);
	}
}

