
using System;
using System.Linq;

public class Solution
{
	public static void Main(string[] args)
	{
		var N = int.Parse(Console.ReadLine());
		for (var i = 0; i < N; i++)
		{
			var data = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
			var a = data[0];
			var b = data[1];

			var sum = Add(a, b);

			Console.WriteLine(sum);
		}
	}


	public static int Add(int a, int b)
	{
		var sum = a ^ b;
		var carry = (a & b) << 1;
		
		if (carry == 0) return sum;

		return Add(sum, carry);
	}
}

