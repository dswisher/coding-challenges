
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		var T = int.Parse(Console.ReadLine());
		for (var i = 0; i < T; i++)
		{
			// RunTest(Console.ReadLine());
			BruteForce(Console.ReadLine());
		}
	}


	private static bool IsPalindrome(string s, int ignore = -1)
	{
		var i = 0;
		var j = s.Length - 1;

		while (i < j)
		{
			if (i == ignore) i++;
			if (j == ignore) j--;

			if (s[i] != s[j]) return false;

			i++;
			j--;
		}

		return true;
	}


	private static void BruteForce(string s)
	{
		if (IsPalindrome(s))
		{
			Console.WriteLine(-1);
			return;
		}

		for (var i = 0; i < s.Length; i++)
		{
			if (IsPalindrome(s, i))
			{
				Console.WriteLine(i);
				return;
			}
		}

		Console.WriteLine(-1);
	}


	private static void RunTest(string s)
	{
		// TODO - more efficient version
	}
}

