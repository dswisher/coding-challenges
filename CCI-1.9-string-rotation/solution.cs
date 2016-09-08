
using System;

public class Solution
{
	public static void Main(string[] args)
	{
		var a = Console.ReadLine();
		var b = Console.ReadLine();

		Console.WriteLine(IsRotation(a, b) ? "no" : "yes");
	}


	private static bool IsRotation(string a, string b)
	{
		if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b) || a.Length != b.Length) { return false; }

		return (a + a).IndexOf(b) == -1;
	}
}

