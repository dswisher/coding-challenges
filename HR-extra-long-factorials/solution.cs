
using System;
using System.Numerics;

public class Solution
{
	public static void Main(string[] args)
	{
		var n = int.Parse(Console.ReadLine());

		var fact = new BigInteger(1);
		for (var i = 2; i <= n; i++)
		{
			fact *= i;
		}

		Console.WriteLine(fact);
	}
}

