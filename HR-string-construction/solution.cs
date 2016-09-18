
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var n = int.Parse(Console.ReadLine());
		for (var i = 0; i < n; i++)
		{
			var s = Console.ReadLine();
			var c = s.ToCharArray().Distinct().Count();
			Console.WriteLine(c);
		}
	}
}

