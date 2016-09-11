
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		var t = long.Parse(Console.ReadLine());
		var val = 3L;

		while (t > val)
		{
			t -= val;
			val *= 2;
		}

		Console.WriteLine(val - t + 1);
	}
}

