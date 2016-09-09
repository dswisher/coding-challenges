
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var bits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		var n = bits[0];
		var k = bits[1];
		var q = bits[2];
		var a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		for (var i = 0; i < q; i++)
		{
			var m = int.Parse(Console.ReadLine());

			var idx = m - k;
			while (idx < 0) { idx += n; }

			Console.WriteLine(a[idx]);
		}
	}
}

