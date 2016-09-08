
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var bits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
		var n = bits[0];
		var k = bits[1];
		var clouds = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

		var c = 0;
		var e = 100;
		do {
			c = (c + k) % n;
			e -= 1;
			if (clouds[c] == 1) { e -= 2; }
		} while (c != 0);

		Console.WriteLine(e);
	}
}

