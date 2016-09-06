
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		string data;
		while ((data = Console.ReadLine()) != null)
		{
			var bits = data.Split(' ').Select(x => int.Parse(x)).ToArray();
			DoSwap(bits[0], bits[1]);
		}
	}


	public static void DoSwap(int a, int b)
	{
		a += b;
		b = a - b;
		a -= b;

		Console.WriteLine("{0} {1}", a, b);
	}
}

